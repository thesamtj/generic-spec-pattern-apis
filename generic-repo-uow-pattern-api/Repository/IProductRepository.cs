using generic_repo_uow_pattern_api.Entity;

namespace generic_repo_uow_pattern_api.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByName(string productName);
        //Task<PaginatedList<Product>> GetAllProuctsWithPagging(int page, int pageSize, string searchTerm);
        //Task<Product> GetProuductsByProductId(int productId);
    }
}
