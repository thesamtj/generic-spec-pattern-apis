using expression_generic_repo_pattern_api.Data;
using expression_generic_repo_pattern_api.Entity;
using expression_generic_repo_pattern_api.Interface;
using Microsoft.EntityFrameworkCore;

namespace expression_generic_repo_pattern_api.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string productName)
        {
            return await _dbSet.Where(p => p.ProductName.Contains(productName)).ToListAsync();
        }
    }
}
