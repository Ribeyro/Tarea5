using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Tarea5.Data.Repository;

public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
{
    private readonly TiendaActividadContext _context;

    public GenericRepository(TiendaActividadContext context)
    {
        _context = context;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity of type {typeof(TEntity).Name} with ID {id} was not found.");
        }
        return entity;
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
        await _context.Set<TEntity>().Where(predicate).ToListAsync();
    public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
    public void UpdateAsync(TEntity entity) => _context.Set<TEntity>().Update(entity);
    public void DeleteAsync(TEntity entity) => _context.Set<TEntity>().Remove(entity);
}