using Microsoft.Data.SqlClient;
using Models;

namespace Essencia.Backend.Repositories
{
    public class AlergenosCafeteriaRepository : IAlergenosCafeteriaRepository
    {

        private readonly string _connectionString;

        public AlergenosCafeteriaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
        }


        public async Task<IEnumerable<AlergenosCafeteria>> GetAllAsync()
        {
            var alergenos = new List<AlergenosCafeteria>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"SELECT a.ID, a.ProductoID, a.Alergeno,
                        p.Nombre as ProductoNombre, p.Categoria, p.ImagenRuta, p.Descripcion, p.PrecioEuros
                FROM AlergenosCafeteria a
                LEFT JOIN ProductosCafeteria p On a.ProductoID = p.ID",
            connection);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                alergenos.Add(MapToAlergeno(reader));
            }
            return alergenos;
        }


        public async Task<AlergenosCafeteria?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
                @"SELECT a.ID, a.ProductoID, a.Alergeno,
                    p.Nombre as ProductoNombre, p.Categoria, p.ImagenRuta, p.Descripcion, p.PrecioEuros
                FROM AlergenosCafeteria a
                LEFT JOIN ProductosCafeteria p ON a.ProductoID = p.ID
                WHERE a.ID = @Id",
                connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapToAlergeno(reader);
            }
            return null;

        }


        public async Task<AlergenosCafeteria> AddAsync(AlergenosCafeteria alergeno)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand(
              @"INSERT INTO AlergenosCafeteria (ProductoID, Alergeno)
              VALUES (@ProductoId, @Alergeno)",
              connection);
            
            command.Parameters.AddWithValue("@ProductoId", alergeno.ProductoId);
            command.Parameters.AddWithValue("@Alergeno", alergeno.Alergeno);

            await command.ExecuteNonQueryAsync();
            return alergeno;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await  connection.OpenAsync();

            var command = new SqlCommand("DELETE FROM AlergenosCafeteria WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

    
        public async Task<int> GetMaxIdAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new SqlCommand("SELECT ISNULL(MAX(ID), 0) FROM AlergenosCafeteria", connection);
            var result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }


        private AlergenosCafeteria MapToAlergeno(SqlDataReader r)
        {
            var producto = !r.IsDBNull(r.GetOrdinal("ProductoID"))
            ? new ProductosCafeteria
            {
                ProductosCafeteriaId = r.GetInt32(r.GetOrdinal("ProductoID")),
                Nombre = r.GetString(r.GetOrdinal("ProductoNombre")),
                Categoria = r.IsDBNull(r.GetOrdinal("Categoria")) ? "" : r.GetString(r.GetOrdinal("Categoria")),
                ImagenRuta = r.IsDBNull(r.GetOrdinal("ImagenRuta")) ? "" : r.GetString(r.GetOrdinal("ImagenRuta")),
                Descripcion = r.IsDBNull(r.GetOrdinal("Descripcion")) ? "" : r.GetString(r.GetOrdinal("Descripcion")),
                PrecioEuros = r.IsDBNull(r.GetOrdinal("PrecioEuros")) ? 0 : r.GetDecimal(r.GetOrdinal("PrecioEuros"))
            }
            : null;
        return new AlergenosCafeteria(
            r.GetInt32(r.GetOrdinal("ID")),
            r.IsDBNull(r.GetOrdinal("ProductoID")) ? 0 : r.GetInt32(r.GetOrdinal("ProductoID")),
            producto,
            r.GetString(r.GetOrdinal("Alergeno"))
        );

        }
    }
}