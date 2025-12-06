using Essencia.Backend.Dtos;
using Essencia.Backend.Repositories;
using Models;

namespace Essencia.Backend.Services
{
    public class MesasService : IMesasService
    {
        private readonly IMesasRepository _mesasRepository;

        public MesasService(IMesasRepository mesasRepository)
        {
            _mesasRepository = mesasRepository;
        }

        public async Task<IEnumerable<MesasResponseDto>> GetAllMesasAsync()
        {
            var mesas = await _mesasRepository.GetAllAsync();

            return mesas.Select(m => new MesasResponseDto
            {
                MesasId = m.MesasId,
                NumeroMesa = m.NumeroMesa,
                Capacidad = m.Capacidad,
                Disponible = m.Disponible,
                Ubicacion = m.Ubicacion
            }).ToList();
        }

        public async Task<MesasResponseDto?> GetMesaByIdAsync(int id)
        {
            var m = await _mesasRepository.GetByIdAsync(id);
            if (m == null) return null;

            return new MesasResponseDto
            {
                MesasId = m.MesasId,
                NumeroMesa = m.NumeroMesa,
                Capacidad = m.Capacidad,
                Disponible = m.Disponible,
                Ubicacion = m.Ubicacion
            };
        }

        public async Task<MesasResponseDto> CreateMesaAsync(MesasCreateDto dto)
        {
            
            var maxId = await _mesasRepository.GetMaxIdAsync();
            var nuevaMesa = new Mesas
            {
                MesasId = maxId + 1,
                NumeroMesa = dto.NumeroMesa,
                Capacidad = dto.Capacidad,
                Disponible = dto.Disponible,
                Ubicacion = dto.Ubicacion
            };

            await _mesasRepository.AddAsync(nuevaMesa);

            return new MesasResponseDto
            {
                MesasId = nuevaMesa.MesasId,
                NumeroMesa = nuevaMesa.NumeroMesa,
                Capacidad = nuevaMesa.Capacidad,
                Disponible = nuevaMesa.Disponible,
                Ubicacion = nuevaMesa.Ubicacion
            };
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es válido para la eliminación.");

            await _mesasRepository.DeleteAsync(id);
        }
    }
}
