using System.IO;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLExample.Infrastructure;

namespace GraphQLExample.GraphQL
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ProductReviewRepository reviewRepository,
            IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced");
            Field(t => t.PhotoFileName);
            Field(t => t.Price);
            Field(t => t.Rating);
            Field(t => t.Stock);
            Field<ProductTypesEnumType>("Type", "The type of product");

            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                resolve: ctx =>
                    {
                        var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                            "GetReviewsByProductId", reviewRepository.GetForProducts);
                        return loader.LoadAsync(ctx.Source.Id);
                    }
                );

        }
    }
}