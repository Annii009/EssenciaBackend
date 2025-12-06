using Essencia.Backend.DTOs.DetallesPedido;
using Essencia.Backend.Repositories;
using Models;

namespace Essencia.Backend.Services
{
    public class DetallePedidoService : IDetallePedidoService
    {
        private readonly IDetallePedidoRepository _detallePedidoRepository;

        public DetallePedidoService(IDetallePedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        public async Task<IEnumerable<DetallePedidoResponseDto>> GetDetallesByPedidoAsync(int pedidoId)
        {
            var detalles = await _detallePedidoRepository.GetAllByPedidoAsync(pedidoId);

            return detalles.Select(d => new DetallePedidoResponseDto
            {
                DetallePedidoId = d.DetallePedidoId,
                PedidoId = d.PedidoId,
                ProductoCafeteriaId = d.ProductoCafeteriaId,
                ProductoFloristeriaId = d.ProductoFloristeriaId,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Cantidad * d.PrecioUnitario
            }).ToList();
        }

        public async Task<DetallePedidoResponseDto?> GetDetalleByIdAsync(int id)
        {
            var d = await _detallePedidoRepository.GetByIdAsync(id);
            if (d == null) return null;

            return new DetallePedidoResponseDto
            {
                DetallePedidoId = d.DetallePedidoId,
                PedidoId = d.PedidoId,
                ProductoCafeteriaId = d.ProductoCafeteriaId,
                ProductoFloristeriaId = d.ProductoFloristeriaId,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Cantidad * d.PrecioUnitario
            };
        }

        public async Task<DetallePedidoResponseDto> CreateDetalleAsync(DetallePedidoCreateDto dto)
        {
            var detalle = new DetallePedido
            {
                PedidoId = dto.PedidoId,
                ProductoCafeteriaId = dto.ProductoCafeteriaId,
                ProductoFloristeriaId = dto.ProductoFloristeriaId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario
            };

            var creado = await _detallePedidoRepository.AddAsync(detalle);

            return new DetallePedidoResponseDto
            {
                DetallePedidoId = creado.DetallePedidoId,
                PedidoId = creado.PedidoId,
                ProductoCafeteriaId = creado.ProductoCafeteriaId,
                ProductoFloristeriaId = creado.ProductoFloristeriaId,
                Cantidad = creado.Cantidad,
                PrecioUnitario = creado.PrecioUnitario,
                Subtotal = creado.Cantidad * creado.PrecioUnitario
            };
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es válido para la eliminación.");

            await _detallePedidoRepository.DeleteAsync(id);
        }
    }
}
