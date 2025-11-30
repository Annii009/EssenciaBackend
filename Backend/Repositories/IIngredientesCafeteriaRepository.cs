using Models;

namespace Essencia.Backend.Repositories
{
    public interface IIngredientesCafeteriaRepository
    {
        Task<IEnumerable<IngredientesCafeteria>> GetAllAsync();
        Task<IngredientesCafeteria?> GetByIdAsync(int id);
        Task<IngredientesCafeteria> AddAsync(IngredientesCafeteria ingrediente);
        Task DeleteAsync(int id);
        Task<int> GetMaxIdAsync();
    }
}