using Essencia.Backend.Repositories;
using Microsoft.Data.SqlClient;
using Models;

public class PedidosRepository : IPedidosRepository
{
    private readonly string _connectionString;

    public PedidosRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
    }

    public async Task<IEnumerable<Pedidos>> GetAllAsync()
    {
        var pedidos = new List<Pedidos>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(
            @"SELECT ID, MesaID, FechaHoraPedido, PedidoCompletado, Total, Notas
              FROM Pedidos", connection);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            pedidos.Add(MapToPedido(reader));
        }

        return pedidos;
    }

    public async Task<Pedidos?> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(
            @"SELECT ID, MesaID, FechaHoraPedido, PedidoCompletado, Total, Notas
              FROM Pedidos
              WHERE ID = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);

        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return MapToPedido(reader);
        }

        return null;
    }

    public async Task<Pedidos> AddAsync(Pedidos pedido)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(
            @"INSERT INTO Pedidos (MesaID, FechaHoraPedido, PedidoCompletado, Total, Notas)
              VALUES (@MesaID, @FechaHoraPedido, @PedidoCompletado, @Total, @Notas);
              SELECT CAST(SCOPE_IDENTITY() AS INT);",
            connection);

        command.Parameters.AddWithValue("@MesaID", pedido.MesaId);
        command.Parameters.AddWithValue("@FechaHoraPedido", pedido.FechaHoraPedido);
        command.Parameters.AddWithValue("@PedidoCompletado", pedido.PedidoCompletado);
        command.Parameters.AddWithValue("@Total", pedido.Total);
        command.Parameters.AddWithValue("@Notas", (object?)pedido.Notas ?? DBNull.Value);

        var newId = (int)await command.ExecuteScalarAsync();
        pedido.PedidoId = newId;

        return pedido;
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var command = new SqlCommand(
            @"DELETE FROM Pedidos WHERE ID = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);

        await command.ExecuteNonQueryAsync();
    }

    private Pedidos MapToPedido(SqlDataReader r)
    {
        return new Pedidos
        {
            PedidoId = r.GetInt32(r.GetOrdinal("ID")),
            MesaId = r.GetInt32(r.GetOrdinal("MesaID")),
            FechaHoraPedido = r.GetDateTime(r.GetOrdinal("FechaHoraPedido")),
            PedidoCompletado = r.GetBoolean(r.GetOrdinal("PedidoCompletado")),
            Total = r.GetDecimal(r.GetOrdinal("Total")),
            Notas = r.IsDBNull(r.GetOrdinal("Notas"))
                ? string.Empty
                : r.GetString(r.GetOrdinal("Notas"))
        };
    }


}
