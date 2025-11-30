using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace Essencia.Backend.Repositories
{
    public interface IProductosFloristeriaRepository
    {
        Task<IEnumerable<ProductosFloristeria>> GetAllAsync();
        Task<ProductosFloristeria?> GetByIdAsync(int id);
        Task<ProductosFloristeria> AddAsync(ProductosFloristeria producto);
        Task DeleteAsync(int id);
        Task<int> GetMaxIdAsync();
    }
}