using Models;

public interface IDetallePedidoRepository
{
    Task<IEnumerable<DetallePedido>> GetAllByPedidoAsync(int pedidoId);
    Task<DetallePedido?> GetByIdAsync(int id);
    Task<DetallePedido> AddAsync(DetallePedido detalle);
    Task DeleteAsync(int id);
}
