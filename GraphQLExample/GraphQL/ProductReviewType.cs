using GraphQL.Types;
using GraphQLExample.Infrastructure;

namespace GraphQLExample.GraphQL
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}