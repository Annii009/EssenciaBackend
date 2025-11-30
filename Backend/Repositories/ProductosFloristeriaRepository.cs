using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace Essencia.Backend.Repositories
{
    public class ProductosFloristeriaRepository : IProductosFloristeriaRepository
    {
        private readonly string _connectionString;

        public ProductosFloristeriaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
        }

        public async Task<IEnumerable<ProductosFloristeria>> GetAllAsync()
        {
            var productos = new List<ProductosFloristeria>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT ID, Nombre, ImagenRuta, Detalle, DescripcionCuidados, PrecioEuros FROM ProductosFloristeria", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        productos.Add(MapToProducto(reader));
                    }
                }
            }

            return productos;
        }

        public async Task<ProductosFloristeria?> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT ID, Nombre, ImagenRuta, Detalle, DescripcionCuidados, PrecioEuros FROM ProductosFloristeria WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToProducto(reader);
                    }
                }
            }

            return null;
        }

        public async Task<ProductosFloristeria> AddAsync(ProductosFloristeria producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    @"INSERT INTO ProductosFloristeria (ID, Nombre, ImagenRuta, Detalle, DescripcionCuidados, PrecioEuros) 
                      VALUES (@Id, @Nombre, @ImagenRuta, @Detalle, @DescripcionCuidados, @PrecioEuros)", 
                    connection);

                command.Parameters.AddWithValue("@Id", producto.ProductosFloristeriaId);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@ImagenRuta", producto.ImagenRuta ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Detalle", producto.Detalle ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DescripcionCuidados", producto.DescripcionCuidados ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PrecioEuros", producto.PrecioEuros);

                await command.ExecuteNonQueryAsync();
            }

            return producto;
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("DELETE FROM ProductosFloristeria WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> GetMaxIdAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT ISNULL(MAX(ID), 0) FROM ProductosFloristeria", connection);

                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }

        private ProductosFloristeria MapToProducto(SqlDataReader reader)
        {
            return new ProductosFloristeria(
                reader.GetInt32(reader.GetOrdinal("ID")),
                reader.GetString(reader.GetOrdinal("Nombre")),
                reader.IsDBNull(reader.GetOrdinal("ImagenRuta")) ? "" : reader.GetString(reader.GetOrdinal("ImagenRuta")),
                reader.IsDBNull(reader.GetOrdinal("Detalle")) ? "" : reader.GetString(reader.GetOrdinal("Detalle")),
                reader.IsDBNull(reader.GetOrdinal("DescripcionCuidados")) ? "" : reader.GetString(reader.GetOrdinal("DescripcionCuidados")),
                reader.GetDecimal(reader.GetOrdinal("PrecioEuros"))
            );
        }
    }
}