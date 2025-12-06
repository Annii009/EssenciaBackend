using Essencia.Backend.Dtos;
using Essencia.Backend.Repositories;
using Models;

namespace Essencia.Backend.Services
{
    public class AlergenosCafeteriaService : IAlergenosCafeteriaService
    {
        private readonly IAlergenosCafeteriaRepository _alergenosCafeteriaRepository;

        public AlergenosCafeteriaService(IAlergenosCafeteriaRepository alergenosCafeteriaRepository)
        {
            _alergenosCafeteriaRepository = alergenosCafeteriaRepository;
        }

        public async Task<IEnumerable<AlergenosCafeteriaResponseDto>> GetAllalergenosCafeteriaAsync()
        {
            var alergenos = await _alergenosCafeteriaRepository.GetAllAsync();
            return alergenos.Select(a => new AlergenosCafeteriaResponseDto
            {
                AlergenoId = a.AlergenosId,
                ProductoId = a.ProductoId,
                ProductoNombre = a.Producto?.Nombre,
                Alergeno = a.Alergeno
            }).ToList();
        }

        public async Task<AlergenosCafeteriaResponseDto?> GetalergenoCafeteriaByIdAsync(int id)
        {
            var a = await _alergenosCafeteriaRepository.GetByIdAsync(id);
            if (a == null)
            {
                return null;
            }

            return new AlergenosCafeteriaResponseDto
            {
                AlergenoId = a.AlergenosId,
                ProductoId = a.ProductoId,
                ProductoNombre = a.Producto?.Nombre,
                Alergeno = a.Alergeno
            };
        }

        public async Task<AlergenosCafeteria> CreatalergenoCafeteriaAsync(AlergenosCafeteriaCreateDto dto)
        {
            var maxId = await _alergenosCafeteriaRepository.GetMaxIdAsync();
            var nuevoAlergeno = new AlergenosCafeteria
            {
                AlergenosId = maxId + 1,
                ProductoId = dto.ProductoId,
                Alergeno = dto.Alergeno
            };

            await _alergenosCafeteriaRepository.AddAsync(nuevoAlergeno);
            return nuevoAlergeno;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es valido para la eliminacion.");
            await _alergenosCafeteriaRepository.DeleteAsync(id);
        }
    }

}