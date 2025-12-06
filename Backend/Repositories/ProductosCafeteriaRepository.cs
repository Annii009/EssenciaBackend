using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace Essencia.Backend.Repositories
{
    public class ProductosCafeteriaRepository : IProductosCafeteriaRepository
    {
        private readonly string _connectionString;

        public ProductosCafeteriaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaConexionEssencia");
        }

        public async Task<IEnumerable<ProductosCafeteria>> GetAllAsync()
        {
            var productos = new List<ProductosCafeteria>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    "SELECT ID, Nombre, Categoria, ImagenRuta, Descripcion, PrecioEuros FROM ProductosCafeteria",
                    connection);

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

        public async Task<ProductosCafeteria?> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    "SELECT ID, Nombre, Categoria, ImagenRuta, Descripcion, PrecioEuros FROM ProductosCafeteria WHERE ID = @Id",
                    connection);
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

        public async Task<ProductosCafeteria> AddAsync(ProductosCafeteria producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    @"INSERT INTO ProductosCafeteria (ID, Nombre, Categoria, ImagenRuta, Descripcion, PrecioEuros) 
                      VALUES (@Id, @Nombre, @Categoria, @ImagenRuta, @Descripcion, @PrecioEuros)",
                    connection);

                command.Parameters.AddWithValue("@Id", producto.ProductosCafeteriaId);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Categoria", producto.Categoria ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ImagenRuta", producto.ImagenRuta ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@PrecioEuros", producto.PrecioEuros);

                await command.ExecuteNonQueryAsync();
            }

            return producto;
        }

        public async Task<ProductosCafeteria> UpdateAsync(ProductosCafeteria producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(
                    @"UPDATE ProductosCafeteria 
                      SET Nombre = @Nombre, 
                          Categoria = @Categoria, 
                          ImagenRuta = @ImagenRuta, 
                          Descripcion = @Descripcion, 
                          PrecioEuros = @PrecioEuros
                      WHERE ID = @Id",
                    connection);

                command.Parameters.AddWithValue("@Id", producto.ProductosCafeteriaId);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Categoria", producto.Categoria ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ImagenRuta", producto.ImagenRuta ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? (object)DBNull.Value);
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
                var command = new SqlCommand("DELETE FROM ProductosCafeteria WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> GetMaxIdAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT ISNULL(MAX(ID), 0) FROM ProductosCafeteria", connection);

                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }

        private ProductosCafeteria MapToProducto(SqlDataReader reader)
        {
            return new ProductosCafeteria(
                reader.GetInt32(reader.GetOrdinal("ID")),
                reader.GetString(reader.GetOrdinal("Nombre")),
                reader.IsDBNull(reader.GetOrdinal("Categoria")) ? "" : reader.GetString(reader.GetOrdinal("Categoria")),
                reader.IsDBNull(reader.GetOrdinal("ImagenRuta")) ? "" : reader.GetString(reader.GetOrdinal("ImagenRuta")),
                reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "" : reader.GetString(reader.GetOrdinal("Descripcion")),
                reader.GetDecimal(reader.GetOrdinal("PrecioEuros"))
            );
        }

        public async Task<IEnumerable<ProductosCafeteria>> SearchAsync(string? categoria, decimal? minPrecio, decimal? maxPrecio, string? ordenarPor, bool ordenarDesc)
        {
            var productos = new List<ProductosCafeteria>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sql = @"SELECT ID, Nombre, Categoria, ImagenRuta, Descripcion, PrecioEuros
                FROM ProductosCafeteria
                WHERE 1 = 1";

            var command = new SqlCommand();
            command.Connection = connection;

            if (!string.IsNullOrWhiteSpace(categoria))
            {
                sql += " AND Categoria = @Categoria";
                command.Parameters.AddWithValue("@Categoria", categoria);
            }

            if (minPrecio.HasValue)
            {
                sql += " AND PrecioEuros >= @MinPrecio";
                command.Parameters.AddWithValue("@MinPrecio", minPrecio.Value);
            }

            if (maxPrecio.HasValue)
            {
                sql += " AND PrecioEuros <= @MaxPrecio";
                command.Parameters.AddWithValue("@MaxPrecio", maxPrecio.Value);
            }

            string columnaOrden = "Nombre";
            if (!string.IsNullOrWhiteSpace(ordenarPor))
            {
                if (ordenarPor.Equals("precio", StringComparison.OrdinalIgnoreCase))
                    columnaOrden = "PrecioEuros";
                else if (ordenarPor.Equals("nombre", StringComparison.OrdinalIgnoreCase))
                    columnaOrden = "Nombre";
            }

            var direccion = ordenarDesc ? "DESC" : "ASC";
            sql += $" ORDER BY {columnaOrden} {direccion}";

            command.CommandText = sql;

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                productos.Add(MapToProducto(reader));
            }

            return productos;
        }

    }
}