
using Essencia.Backend.Dtos;
using Models;

namespace Essencia.Backend.Services
{
    public interface IAlergenosCafeteriaService
    {
        Task<IEnumerable<AlergenosCafeteriaResponseDto>> GetAllalergenosCafeteriaAsync();
        Task<AlergenosCafeteriaResponseDto?> GetalergenoCafeteriaByIdAsync(int id);
        Task<AlergenosCafeteria> CreatalergenoCafeteriaAsync(AlergenosCafeteriaCreateDto dto);
        Task DeleteAsync(int id);
    }
}
