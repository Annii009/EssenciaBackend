using Essencia.Backend.Dtos;

public interface IMesasService
{
    Task<IEnumerable<MesasResponseDto>> GetAllMesasAsync();
    Task<MesasResponseDto?> GetMesaByIdAsync(int id);
    Task<MesasResponseDto> CreateMesaAsync(MesasCreateDto dto);
    Task DeleteAsync(int id);
}
