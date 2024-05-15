using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace generic_repo_uow_pattern_api.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void SetDbContext(DbContext dbContext);
    }
}
