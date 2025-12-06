using Essencia.Backend.Dtos;
using Essencia.Backend.Repositories;
using Models;

namespace Essencia.Backend.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IMesasRepository _mesasRepository;

        public PedidosService(IPedidosRepository pedidosRepository,
                              IMesasRepository mesasRepository)
        {
            _pedidosRepository = pedidosRepository;
            _mesasRepository = mesasRepository;
        }

        public async Task<IEnumerable<PedidosResponseDto>> GetAllPedidosAsync()
        {
            var pedidos = await _pedidosRepository.GetAllAsync();

            var result = new List<PedidosResponseDto>();

            foreach (var p in pedidos)
            {
                result.Add(new PedidosResponseDto
                {
                    PedidoId = p.PedidoId,
                    MesaId = p.MesaId,
                    FechaHoraPedido = p.FechaHoraPedido,
                    PedidoCompletado = p.PedidoCompletado,
                    Total = p.Total,
                    Notas = p.Notas
                });
            }

            return result;
        }

        public async Task<PedidosResponseDto?> GetPedidoByIdAsync(int id)
        {
            var p = await _pedidosRepository.GetByIdAsync(id);
            if (p == null) return null;

            return new PedidosResponseDto
            {
                PedidoId = p.PedidoId,
                MesaId = p.MesaId,
                FechaHoraPedido = p.FechaHoraPedido,
                PedidoCompletado = p.PedidoCompletado,
                Total = p.Total,
                Notas = p.Notas
            };
        }

        public async Task<PedidosResponseDto> CreatePedidoAsync(PedidosCreateDto dto)
        {
            var pedido = new Pedidos
            {
                MesaId = dto.MesaId,
                FechaHoraPedido = dto.FechaHoraPedido,
                PedidoCompletado = dto.PedidoCompletado,
                Total = dto.Total,
                Notas = dto.Notas
            };

            var creado = await _pedidosRepository.AddAsync(pedido);

            return new PedidosResponseDto
            {
                PedidoId = creado.PedidoId,
                MesaId = creado.MesaId,
                FechaHoraPedido = creado.FechaHoraPedido,
                PedidoCompletado = creado.PedidoCompletado,
                Total = creado.Total,
                Notas = creado.Notas
            };
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es válido para la eliminación.");

            await _pedidosRepository.DeleteAsync(id);
        }
    }
}
