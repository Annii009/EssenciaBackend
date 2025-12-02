using Models;

namespace Essencia.Backend.Repositories
{
    public interface IAlergenosCafeteriaRepository
    {
        Task<IEnumerable<AlergenosCafeteria>> GetAllAsync();
        Task<AlergenosCafeteria?> GetByIdAsync(int id);
        Task<AlergenosCafeteria> AddAsync(AlergenosCafeteria alergeno);
        Task DeleteAsync(int id);
        Task<int> GetMaxIdAsync();
    }
}