using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace Essencia.Backend.Repositories
{
    public class IngredientesCafeteriaRepository : IIngredientesCafeteriaRepository
    {
        private readonly string _connectionString;

        public IngredientesCafeteriaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
        }

        public async Task<IEnumerable<IngredientesCafeteria>> GetAllAsync()
        {
            var ingredientes = new List<IngredientesCafeteria>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var command = new SqlCommand(
                @"SELECT i.ID, i.ProductoID, i.Ingrediente,
                         p.Nombre as ProductoNombre, p.Categoria, p.ImagenRuta, p.Descripcion, p.PrecioEuros
                  FROM IngredientesCafeteria i
                  LEFT JOIN ProductosCafeteria p ON i.ProductoID = p.ID", 
                connection);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                ingredientes.Add(MapToIngrediente(reader));
            }

            return ingredientes;
        }

        public async Task<IngredientesCafeteria?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var command = new SqlCommand(
                @"SELECT i.ID, i.ProductoID, i.Ingrediente,
                         p.Nombre as ProductoNombre, p.Categoria, p.ImagenRuta, p.Descripcion, p.PrecioEuros
                  FROM IngredientesCafeteria i
                  LEFT JOIN ProductosCafeteria p ON i.ProductoID = p.ID
                  WHERE i.ID = @Id", 
                connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return MapToIngrediente(reader);
            }

            return null;
        }

        public async Task<IngredientesCafeteria> AddAsync(IngredientesCafeteria ingrediente)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var command = new SqlCommand(
                @"INSERT INTO IngredientesCafeteria (ProductoID, Ingrediente) 
                  VALUES (@ProductoId, @Ingrediente)", 
                connection);

            command.Parameters.AddWithValue("@ProductoId", ingrediente.ProductoId);
            command.Parameters.AddWithValue("@Ingrediente", ingrediente.Ingrediente);

            await command.ExecuteNonQueryAsync();
            return ingrediente;
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var command = new SqlCommand("DELETE FROM IngredientesCafeteria WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<int> GetMaxIdAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            
            var command = new SqlCommand("SELECT ISNULL(MAX(ID), 0) FROM IngredientesCafeteria", connection);
            var result = await command.ExecuteScalarAsync();
            
            return Convert.ToInt32(result);
        }

        private IngredientesCafeteria MapToIngrediente(SqlDataReader r)
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

            return new IngredientesCafeteria(
                r.GetInt32(r.GetOrdinal("ID")),
                r.IsDBNull(r.GetOrdinal("ProductoID")) ? 0 : r.GetInt32(r.GetOrdinal("ProductoID")),
                producto,
                r.GetString(r.GetOrdinal("Ingrediente"))
            );
        }
    }
}