using spec_generic_repo_pattern_api.Data;
using spec_generic_repo_pattern_api.Entity;
using spec_generic_repo_pattern_api.Interface;
using Microsoft.EntityFrameworkCore;

namespace spec_generic_repo_pattern_api.Repository
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
