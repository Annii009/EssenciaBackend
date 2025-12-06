using Essencia.Backend.Repositories;
using Essencia.Backend.Dtos;
using Models;

namespace Essencia.Backend.Services
{
    public class ProductosCafeteriaService : IProductosCafeteriaService
    {
        private readonly IProductosCafeteriaRepository _productosCafeteriaRepository;

        public ProductosCafeteriaService(IProductosCafeteriaRepository productosCafeteriaRepository)
        {
            _productosCafeteriaRepository = productosCafeteriaRepository;
        }

        public async Task<IEnumerable<ProductosCafeteriaResponseDto>> GetAllProductosCafeteriaAsync()
        {
            var productos = await _productosCafeteriaRepository.GetAllAsync();
            return productos.Select(p => new ProductosCafeteriaResponseDto
            {
                ProductosCafeteriaId = p.ProductosCafeteriaId,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                ImagenRuta = p.ImagenRuta,
                Descripcion = p.Descripcion,
                PrecioEuros = p.PrecioEuros
            }).ToList();
        }

        public async Task<ProductosCafeteriaResponseDto?> GetProductoCafeteriaByIdAsync(int id)
        {
            var p = await _productosCafeteriaRepository.GetByIdAsync(id);
            if (p == null)
            {
                return null;
            }

            return new ProductosCafeteriaResponseDto
            {
                ProductosCafeteriaId = p.ProductosCafeteriaId,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                ImagenRuta = p.ImagenRuta,
                Descripcion = p.Descripcion,
                PrecioEuros = p.PrecioEuros
            };
        }

        public async Task<ProductosCafeteria> CreateProductoCafeteriaAsync(ProductosCafeteriaCreateDto dto)
        {
            var maxId = await _productosCafeteriaRepository.GetMaxIdAsync();
            var nuevoProducto = new ProductosCafeteria
            {
                ProductosCafeteriaId = maxId + 1,
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                ImagenRuta = dto.ImagenRuta,
                Descripcion = dto.Descripcion,
                PrecioEuros = dto.PrecioEuros
            };

            await _productosCafeteriaRepository.AddAsync(nuevoProducto);
            return nuevoProducto;
        }

        public async Task<ProductosCafeteria?> UpdateProductoCafeteriaAsync(int id, ProductosCafeteriaUpdateDto dto)
        {
            var productoExistente = await _productosCafeteriaRepository.GetByIdAsync(id);
            if (productoExistente == null)
            {
                return null;
            }

            productoExistente.Nombre = dto.Nombre;
            productoExistente.Categoria = dto.Categoria;
            productoExistente.ImagenRuta = dto.ImagenRuta;
            productoExistente.Descripcion = dto.Descripcion;
            productoExistente.PrecioEuros = dto.PrecioEuros;

            await _productosCafeteriaRepository.UpdateAsync(productoExistente);
            return productoExistente;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id no es válido para la eliminación.");
            await _productosCafeteriaRepository.DeleteAsync(id);
        }
    }

    
}