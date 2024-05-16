using expression_generic_repo_pattern_api.Entity;

namespace expression_generic_repo_pattern_api.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByName(string productName);
        //Task<PaginatedList<Product>> GetAllProuctsWithPagging(int page, int pageSize, string searchTerm);
        //Task<Product> GetProuductsByProductId(int productId);
    }
}
