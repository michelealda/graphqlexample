using GraphQL.Types;
using GraphQLExample.Infrastructure;

namespace GraphQLExample.GraphQL
{
    public class ProductTypesEnumType : EnumerationGraphType<ProductTypes>
    {
        public ProductTypesEnumType()
        {
            Name = "Type";
            Description = "The type of product";
        }
    }
}