using Microsoft.Data.SqlClient;
using Models;

namespace Essencia.Backend.Repositories
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {

         private readonly string _connectionString;

        public DetallePedidoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
        }

        public async Task<IEnumerable<DetallePedido>> GetAllByPedidoAsync(int pedidoId)
        {
            var detalles = new List<DetallePedido>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"SELECT ID, PedidoID, ProductoCafeteriaID, ProductoFloristeriaID,
                         Cantidad, PrecioUnitario
                  FROM DetallePedido
                  WHERE PedidoID = @PedidoId", connection);

            command.Parameters.AddWithValue("@PedidoId", pedidoId);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                detalles.Add(MapToDetalle(reader));
            }

            return detalles;
        }

        public async Task<DetallePedido?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"SELECT ID, PedidoID, ProductoCafeteriaID, ProductoFloristeriaID,
                         Cantidad, PrecioUnitario
                  FROM DetallePedido
                  WHERE ID = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapToDetalle(reader);
            }

            return null;
        }

        public async Task<DetallePedido> AddAsync(DetallePedido detalle)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"INSERT INTO DetallePedido
                    (PedidoID, ProductoCafeteriaID, ProductoFloristeriaID, Cantidad, PrecioUnitario)
                  VALUES (@PedidoID, @ProductoCafeteriaID, @ProductoFloristeriaID, @Cantidad, @PrecioUnitario);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);",
                connection);

            command.Parameters.AddWithValue("@PedidoID", detalle.PedidoId);
            command.Parameters.AddWithValue("@ProductoCafeteriaID",
                (object?)detalle.ProductoCafeteriaId ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProductoFloristeriaID",
                (object?)detalle.ProductoFloristeriaId ?? DBNull.Value);
            command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
            command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

            var newId = (int)await command.ExecuteScalarAsync();
            detalle.DetallePedidoId = newId;

            return detalle;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"DELETE FROM DetallePedido WHERE ID = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        private DetallePedido MapToDetalle(SqlDataReader r)
        {
            return new DetallePedido
            {
                DetallePedidoId = r.GetInt32(r.GetOrdinal("ID")),
                PedidoId = r.GetInt32(r.GetOrdinal("PedidoID")),
                ProductoCafeteriaId = r.IsDBNull(r.GetOrdinal("ProductoCafeteriaID"))
                    ? null
                    : r.GetInt32(r.GetOrdinal("ProductoCafeteriaID")),
                ProductoFloristeriaId = r.IsDBNull(r.GetOrdinal("ProductoFloristeriaID"))
                    ? null
                    : r.GetInt32(r.GetOrdinal("ProductoFloristeriaID")),
                Cantidad = r.GetInt32(r.GetOrdinal("Cantidad")),
                PrecioUnitario = r.GetDecimal(r.GetOrdinal("PrecioUnitario"))
            };
        }
    }
}