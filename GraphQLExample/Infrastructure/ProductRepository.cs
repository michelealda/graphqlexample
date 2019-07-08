using System.Collections.Generic;
using System.Linq;

namespace GraphQLExample.Infrastructure
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

    public class ProductReviewRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductReviewRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductReview> GetAll(int id)
        {
            return _dbContext.ProductReviews.Where(r => r.ProductId == id);
        }
    }
}