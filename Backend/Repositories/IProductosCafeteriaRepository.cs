using Models;

namespace Essencia.Backend.Repositories
{
    public interface IProductosCafeteriaRepository
    {
        Task<IEnumerable<ProductosCafeteria>> GetAllAsync();
        Task<ProductosCafeteria?> GetByIdAsync(int id);
        Task<ProductosCafeteria> AddAsync(ProductosCafeteria producto);
        Task<ProductosCafeteria> UpdateAsync(ProductosCafeteria producto);
        Task DeleteAsync(int id);
        Task<int> GetMaxIdAsync();
    }
}