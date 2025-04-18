using System.Linq.Expressions;

namespace Tarea5.Data.Repository;

public interface IGenericRepository<TEntity> where TEntity :class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    void UpdateAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
}