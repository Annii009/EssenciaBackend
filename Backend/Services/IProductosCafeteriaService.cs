using Essencia.Backend.Dtos;
using Models;

namespace Essencia.Backend.Services
{
    public interface IProductosCafeteriaService
    {
        Task<IEnumerable<ProductosCafeteriaResponseDto>> GetAllProductosCafeteriaAsync();
        Task<ProductosCafeteriaResponseDto?> GetProductoCafeteriaByIdAsync(int id);
        Task<ProductosCafeteria> CreateProductoCafeteriaAsync(ProductosCafeteriaCreateDto dto);
        Task<ProductosCafeteria?> UpdateProductoCafeteriaAsync(int id, ProductosCafeteriaUpdateDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductosCafeteriaResponseDto>> SearchAsync(ProductosCafeteriaSearchDto filtro);
    }

}