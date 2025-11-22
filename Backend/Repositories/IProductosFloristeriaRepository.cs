using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Essencia.Backend.Repositories
{
    public interface IProductosFloristeriaRepository
    {
        Task<IEnumerable<ProductosFloristeria>> GetAllAsync();
        Task<ProductosFloristeria?> GetByIdAsync(int id);
        Task AddAsync(ProductosFloristeria producto);
    }
}