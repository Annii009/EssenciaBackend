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
        Task<IEnumerable<ProductosFloristeria>> SearchAsync(string? texto, decimal? minPrecio, decimal? maxPrecio, string? ordenarPor, bool ordenarDesc);

    }
}