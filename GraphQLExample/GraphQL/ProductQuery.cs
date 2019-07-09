using GraphQL.Types;
using GraphQLExample.Infrastructure;

namespace GraphQLExample.GraphQL
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(ProductRepository productRepository,
            ProductReviewRepository reviewRepository
            )
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: ctx => productRepository.GetAll()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return productRepository.Get(id);
                }
            );
        }
    }
}