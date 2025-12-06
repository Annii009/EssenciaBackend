using Models;

namespace Essencia.Backend.Repositories
{
    public interface IPedidosRepository
    {
        Task<IEnumerable<Pedidos>> GetAllAsync();
        Task<Pedidos?> GetByIdAsync(int id);
        Task<Pedidos> AddAsync(Pedidos pedido);
        Task DeleteAsync(int id);
    }
}