using Essencia.Backend.Dtos;
using Models;

namespace Essencia.Backend.Services
{
    public interface IIngredientesCafeteriaService
    {

        Task<IEnumerable<IngredientesCafeteriaResponseDto>> GetAllIngredientesCafeteriaAsync();
        Task<IngredientesCafeteriaResponseDto?> GetIngredienteCafeteriaByIdAsync(int id);
        Task<IngredientesCafeteria> CreatIngredienteCafeteriaAsync(IngredientesCafeteriaCreateDto dto);
        Task DeleteAsync(int id);
    }
}
