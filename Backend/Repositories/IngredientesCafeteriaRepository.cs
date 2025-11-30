using Essencia.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Essencia.Backend.Repositories
{
    public class IngredientesCafeteriaRepository : IIngredientesCafeteriaRepository
    {
        private readonly EssenciaDbContext _context;

        public IngredientesCafeteriaRepository(EssenciaDbContext context)
        {
            _context = context;
        }

        public async Task<IngredientesCafeteria> AddAsync(IngredientesCafeteria ingrediente)
        {
            await _context.IngredientesCafeteria.AddAsync(ingrediente);
            await _context.SaveChangesAsync();
            return ingrediente;
        }

        public async Task DeleteAsync(int id)
        {
            var ingrediente = await _context.IngredientesCafeteria.FindAsync(id);

            if (ingrediente != null)
            {
                _context.IngredientesCafeteria.Remove(ingrediente);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IngredientesCafeteria>> GetAllAsync()
        {
            return await _context.IngredientesCafeteria.ToListAsync();
        }

        public async Task<IngredientesCafeteria?> GetByIdAsync(int id)
        {
            return await _context.IngredientesCafeteria.FindAsync(id);
        }

        public async Task<int> GetMaxIdAsync()
        {
            if (!await _context.IngredientesCafeteria.AnyAsync())
            {
                return 0;
            }
            return await _context.IngredientesCafeteria.MaxAsync(p => p.IngredientesId);
        }
    }
}