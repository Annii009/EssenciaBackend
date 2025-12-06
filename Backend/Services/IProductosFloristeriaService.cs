using Essencia.Backend.Dtos;
using Models;

namespace Essencia.Backend.Services
{
    public interface IProductosFloristeriaService
    {
        Task<IEnumerable<ProductosFloristeriaResponseDto>> GetAllProductosFloristeriaAsync();
        Task<ProductosFloristeriaResponseDto?> GetProductoFloristeriaByIdAsync(int id);
        Task<ProductosFloristeria> CreatProductoFloristeriaAsync(ProductosFloristeriaCreateDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductosFloristeriaResponseDto>> SearchAsync(ProductosFloristeriaSearchDto filtro);

    }
}