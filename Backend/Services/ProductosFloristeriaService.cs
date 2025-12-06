using Essencia.Backend.Repositories;
using Essencia.Backend.Dtos;
using Models;

namespace Essencia.Backend.Services
{
    public class ProductosFloristeriaService : IProductosFloristeriaService
    {
        private readonly IProductosFloristeriaRepository _productosFloristeriaRepository;

        public ProductosFloristeriaService(IProductosFloristeriaRepository productosFloristeriaRepository)
        {
            _productosFloristeriaRepository = productosFloristeriaRepository;
        }

        public async Task<IEnumerable<ProductosFloristeriaResponseDto>> GetAllProductosFloristeriaAsync()
        {
            var productos = await _productosFloristeriaRepository.GetAllAsync();
            return productos.Select(p => new ProductosFloristeriaResponseDto
            {
                ProductosFloristeriaId = p.ProductosFloristeriaId,
                Nombre = p.Nombre,
                ImagenRuta = p.ImagenRuta,
                Detalle = p.Detalle,
                DescripcionCuidados = p.DescripcionCuidados,
                PrecioEuros = p.PrecioEuros
            }).ToList();
        }

        public async Task<ProductosFloristeriaResponseDto?> GetProductoFloristeriaByIdAsync(int id)
        {
            var p = await _productosFloristeriaRepository.GetByIdAsync(id);
            if (p == null)
            {
                return null;
            }

            return new ProductosFloristeriaResponseDto
            {
                ProductosFloristeriaId = p.ProductosFloristeriaId,
                Nombre = p.Nombre,
                ImagenRuta = p.ImagenRuta,
                Detalle = p.Detalle,
                DescripcionCuidados = p.DescripcionCuidados,
                PrecioEuros = p.PrecioEuros
            };
        }

        public async Task<ProductosFloristeria> CreatProductoFloristeriaAsync(ProductosFloristeriaCreateDto dto)
        {
            var maxId = await _productosFloristeriaRepository.GetMaxIdAsync();
            var nuevoProducto = new ProductosFloristeria
            {
                ProductosFloristeriaId = maxId + 1,
                Nombre = dto.Nombre,
                ImagenRuta = dto.ImagenRuta,
                Detalle = dto.Detalle,
                DescripcionCuidados = dto.DescripcionCuidados,
                PrecioEuros = dto.PrecioEuros
            };

            await _productosFloristeriaRepository.AddAsync(nuevoProducto);
            return nuevoProducto;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es valido para la eliminacion.");
            await _productosFloristeriaRepository.DeleteAsync(id);
        }


        public async Task<IEnumerable<ProductosFloristeriaResponseDto>> SearchAsync(ProductosFloristeriaSearchDto filtro)
        {
            var ordenarDesc = string.Equals(filtro.OrdenDireccion, "desc", StringComparison.OrdinalIgnoreCase);

            var productos = await _productosFloristeriaRepository.SearchAsync(
                filtro.Texto,
                filtro.MinPrecio,
                filtro.MaxPrecio,
                filtro.OrdenPor,
                ordenarDesc);

            return productos.Select(p => new ProductosFloristeriaResponseDto
            {
                ProductosFloristeriaId = p.ProductosFloristeriaId,
                Nombre = p.Nombre,
                ImagenRuta = p.ImagenRuta,
                Detalle = p.Detalle,
                DescripcionCuidados = p.DescripcionCuidados,
                PrecioEuros = p.PrecioEuros
            }).ToList();
        }

    }
}