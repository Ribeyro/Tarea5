using Tarea5.Data.UnitOfWork;
using Tarea5.Models;
using Tarea5.Services.Interfaces;

namespace Tarea5.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Producto>> GetAllProductsAsync()
    {
        return await _unitOfWork.Repository<Producto>().GetAllAsync();
    }

    public async Task<Producto> GetProductByIdAsync(int id)
    {
        var product = await _unitOfWork.Repository<Producto>().GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }
        return product;
    }

    public async Task AddProductAsync(Producto product)
    {
        await _unitOfWork.Repository<Producto>().AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Producto product)
    {
        var existingProduct = await _unitOfWork.Repository<Producto>().GetByIdAsync(product.Id);
        if (existingProduct == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }

        _unitOfWork.Repository<Producto>().UpdateAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Repository<Producto>().GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }

        _unitOfWork.Repository<Producto>().DeleteAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }
}