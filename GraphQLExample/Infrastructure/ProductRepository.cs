using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        =>_dbContext.Products;

        public Product Get(int id)
            => _dbContext.Products.SingleOrDefault(p => p.Id == id);
    }

    public class ProductReviewRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductReviewRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductReview>> GetForProduct(int id)
            => await _dbContext.ProductReviews.Where(r => r.ProductId == id).ToListAsync();

        public async Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.ProductReviews
                .Where(r => productIds.Contains(r.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }

        public async Task<ProductReview> AddReview(ProductReview review)
        {
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}