﻿using System.Collections.Generic;

namespace GraphQLExample
{
    public class ProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }
    }
}