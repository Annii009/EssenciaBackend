using Essencia.Backend.DTOs.DetallesPedido;

public interface IDetallePedidoService
{
    Task<IEnumerable<DetallePedidoResponseDto>> GetDetallesByPedidoAsync(int pedidoId);
    Task<DetallePedidoResponseDto?> GetDetalleByIdAsync(int id);
    Task<DetallePedidoResponseDto> CreateDetalleAsync(DetallePedidoCreateDto dto);
    Task DeleteAsync(int id);
}
