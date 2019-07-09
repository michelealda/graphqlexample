using GraphQL.Types;
using GraphQLExample.Infrastructure;

namespace GraphQLExample.GraphQL
{
    public class ProductReviewInputType : InputObjectGraphType
    {
        public ProductReviewInputType()
        {
            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("review");
            Field<NonNullGraphType<IntGraphType>>("productId");
        }
    }

    public class ProductReviewMutation : ObjectGraphType
    {
        public ProductReviewMutation(ProductReviewRepository reviewRepository)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>> {Name= "review"}),
                resolve: async ctx =>
                {
                    var review = ctx.GetArgument<ProductReview>("review");
                    return await ctx.TryAsyncResolve(
                        async c => await reviewRepository.AddReview(review));
                }
            );
        }
    }
}