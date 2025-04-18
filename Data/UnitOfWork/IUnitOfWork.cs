using Tarea5.Data.Repository;

namespace Tarea5.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable  
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync();
}