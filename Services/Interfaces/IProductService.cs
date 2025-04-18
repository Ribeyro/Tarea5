using Tarea5.Models;

namespace Tarea5.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Producto>> GetAllProductsAsync();
    Task<Producto> GetProductByIdAsync(int id);
    Task AddProductAsync(Producto product);
    Task UpdateProductAsync(Producto product);
    Task DeleteProductAsync(int id);
}