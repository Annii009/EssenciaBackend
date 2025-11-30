using Essencia.Backend.Dtos;
using Essencia.Backend.Repositories;
using Models;

namespace Essencia.Backend.Services
{
    public class IngredientesCafeteriaService
    {
        private readonly IIngredientesCafeteriaRepository _ingredientesCafeteriaRepository;

        public IngredientesCafeteriaService(IIngredientesCafeteriaRepository ingredientesCafeteriaRepository)
        {
            _ingredientesCafeteriaRepository = ingredientesCafeteriaRepository;
        }

        public async Task<IEnumerable<IngredientesCafeteriaResponseDto>> GetAllIngredientesCafeteriaAsync()
        {
            var ingredientes = await _ingredientesCafeteriaRepository.GetAllAsync();
            return ingredientes.Select(i => new IngredientesCafeteriaResponseDto
            {
                IngredientesId = i.IngredientesId,
                ProductoId = i.ProductoId,
                ProductoNombre = i.Producto?.Nombre,
                Ingrediente = i.Ingrediente
            }).ToList();
        }

        public async Task<IngredientesCafeteriaResponseDto?> GetIngredienteCafeteriaByIdAsync(int id)
        {
            var i = await _ingredientesCafeteriaRepository.GetByIdAsync(id);
            if (i == null)
            {
                return null;
            }

            return new IngredientesCafeteriaResponseDto
            {
                IngredientesId = i.IngredientesId,
                ProductoId = i.ProductoId,
                ProductoNombre = i.Producto?.Nombre,
                Ingrediente = i.Ingrediente
            };
        }

        public async Task<IngredientesCafeteria> CreatIngredienteCafeteriaAsync(IngredientesCafeteriaCreateDto dto)
        {
            var maxId = await _ingredientesCafeteriaRepository.GetMaxIdAsync();
            var nuevoIngrediente = new IngredientesCafeteria
            {
                IngredientesId = maxId + 1,
                ProductoId = dto.ProductoId,
                Ingrediente = dto.Ingrediente
            };

            await _ingredientesCafeteriaRepository.AddAsync(nuevoIngrediente);
            return nuevoIngrediente;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es valido para la eliminacion.");
            await _ingredientesCafeteriaRepository.DeleteAsync(id);
        }
    }
}