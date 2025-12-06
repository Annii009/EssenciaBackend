using Essencia.Backend.Dtos;

public interface IPedidosService
{
    Task<IEnumerable<PedidosResponseDto>> GetAllPedidosAsync();
    Task<PedidosResponseDto?> GetPedidoByIdAsync(int id);
    Task<PedidosResponseDto> CreatePedidoAsync(PedidosCreateDto dto);
    Task DeleteAsync(int id);
}