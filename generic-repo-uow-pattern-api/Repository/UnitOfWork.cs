using generic_repo_uow_pattern_api.Data;
using generic_repo_uow_pattern_api.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace generic_repo_uow_pattern_api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly MyDbContext _myDbContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;

        public IProductRepository ProductRepository { get; }

        public UnitOfWork(
            MyDbContext myDbContext,
            IServiceProvider serviceProvider
            )
        {
            _myDbContext = myDbContext;
            _serviceProvider = serviceProvider;
            _repositories = new Dictionary<Type, object>(); 
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _myDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null!;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _myDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }

            var repository = new Repository<T>(_myDbContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _myDbContext.SaveChangesAsync(); 

        }

        TRepository IUnitOfWork.GetRepository<TRepository, TEntity>()
        {
            var repository = _serviceProvider.GetService<TRepository>();

            if (repository == null)
            {
                throw new InvalidOperationException($"Failed to get repository of type {typeof(TRepository)}");
            }

            // Set the DbContext
            if (repository is IRepository<TEntity> genericRepository)
            {
                genericRepository.SetDbContext(_myDbContext);
            }
            else
            {
                throw new InvalidOperationException($"Repository of type {typeof(TRepository)} does not implement IRepository<TEntity>.");
            }

            return repository;
        }
    }
}
