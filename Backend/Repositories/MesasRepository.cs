using Microsoft.Data.SqlClient;
using Models;

namespace Essencia.Backend.Repositories
{
    public class MesasRepository : IMesasRepository
    {

        private readonly string _connectionString;

        public MesasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
        }

        public async Task<Mesas> AddAsync(Mesas mesa)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"INSERT INTO Mesas (ID, NumeroMesa, Capacidad, Disponible, Ubicacion)
                  VALUES (@Id, @NumeroMesa, @Capacidad, @Disponible, @Ubicacion);",
                connection);

            command.Parameters.AddWithValue("@Id", mesa.MesasId);
            command.Parameters.AddWithValue("@NumeroMesa", mesa.NumeroMesa);
            command.Parameters.AddWithValue("@Capacidad", mesa.Capacidad);
            command.Parameters.AddWithValue("@Disponible", mesa.Disponible);
            command.Parameters.AddWithValue("@Ubicacion", mesa.Ubicacion);

            await command.ExecuteNonQueryAsync();
            return mesa;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"DELETE FROM Mesas WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Mesas>> GetAllAsync()
        {
            var mesas = new List<Mesas>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"SELECT ID, NumeroMesa, Capacidad, Disponible, Ubicacion 
                FROM Mesas", connection);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                mesas.Add(MapToMesa(reader));
            }

            return mesas;

        }

        public async Task<Mesas?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"SELECT ID, NumeroMesa, Capacidad, Disponible, Ubicacion
                  FROM Mesas
                  WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapToMesa(reader);
            }

            return null;
        }

        private Mesas MapToMesa(SqlDataReader r)
        {
            return new Mesas
            {
                MesasId = r.GetInt32(r.GetOrdinal("ID")),
                NumeroMesa = r.GetInt32(r.GetOrdinal("NumeroMesa")),
                Capacidad = r.GetInt32(r.GetOrdinal("Capacidad")),
                Disponible = r.GetBoolean(r.GetOrdinal("Disponible")),
                Ubicacion = r.IsDBNull(r.GetOrdinal("Ubicacion"))
                    ? string.Empty
                    : r.GetString(r.GetOrdinal("Ubicacion"))
            };
        }

        public async Task<int> GetMaxIdAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                "SELECT ISNULL(MAX(ID), 0) FROM Mesas",
                connection);

            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

    }
}