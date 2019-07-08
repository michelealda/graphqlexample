﻿using GraphQL.Types;

namespace GraphQLExample.GraphQL
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(ProductRepository repository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: ctx => repository.GetAll()
            );
        }
    }
}