using Models;

public interface IMesasRepository
{
    Task<IEnumerable<Mesas>> GetAllAsync();
    Task<Mesas?> GetByIdAsync(int id);
    Task<Mesas> AddAsync(Mesas mesa);
    Task DeleteAsync(int id);
    Task<int> GetMaxIdAsync();
}
