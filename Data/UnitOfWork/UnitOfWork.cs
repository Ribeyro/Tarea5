using System.Collections;
using Tarea5.Data.Repository;

namespace Tarea5.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;
    private readonly TiendaActividadContext _context;

    public UnitOfWork(TiendaActividadContext context)
    {
        _context = context;
        _repositories = new Hashtable();
    }
    
    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var typeName = typeof(TEntity).Name;

        if (_repositories.ContainsKey(typeName))
        {
            return (IGenericRepository<TEntity>)_repositories[typeName]!;
        }

        var repositoryType = typeof(GenericRepository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(typeName, repositoryInstance);
            return (IGenericRepository<TEntity>)repositoryInstance;
        }

        throw new Exception($"Could not create repository for type {typeName}");
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync(); 
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}