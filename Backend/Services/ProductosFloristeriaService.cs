using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Essencia.Backend.Repositories;
using Essencia.Backend.Dtos;

namespace Essencia.Backend.Services
{
    public class ProductosFloristeriaService
    {
        private readonly IProductosFloristeriaRepository _productosFloristeriaRepository;
        public ProductosFloristeriaService(IProductosFloristeriaRepository productosFloristeriaRepository)
        {
            _productosFloristeriaRepository = productosFloristeriaRepository;
        }

        public async Task<IEnumerable<ProdcutosFloristeriaResponseDto>> GetAllProductosFloristeriaAsync()
        {
            var productos = await _productosFloristeriaRepository.GetAllAsync();

            return productos.Select(p => new ProdcutosFloristeriaResponseDto
            {
                ProductosFloristeriaId = p.ProductosFloristeriaId,
                Nombre = p.Nombre,
                ImagenRuta = p.ImagenRuta,
                Detalle = p.Detalle,
                DescripcionCuidados = p.DescripcionCuidados,
                PrecioEuros = p.PrecioEuros
            }).ToList();
        }

        public async Task<ProdcutosFloristeriaResponseDto?> GetProductoFloristeriaByIdAsync(int id)
        {
            var p = await _productosFloristeriaRepository.GetByIdAsync(id);
            if (p == null)
            {
                return null;
            }

            return new ProductosFloristeriaResponseDto
            {
                ProductosFloristeriaId = producto.ProductosFloristeriaId,
                Nombre = producto.Nombre,
                ImagenRuta = producto.ImagenRuta,
                Detalle = producto.Detalle,
                DescripcionCuidados = producto.DescripcionCuidados,
                PrecioEuros = producto.PrecioEuros
            };
        }

        public async Task CreatProductoFloristeriaAsync(ProductosFloristeriaCreateDto dto)
        {
            var nuevoProducto = new ProductosFloristeria
            {
                Nombre = dto.Nombre,
                ImagenRuta = dto.ImagenRuta,
                Detalle = dto.Detalle,
                DescripcionCuidados = dto.DescripcionCuidados,
                PrecioEuros = dto.PrecioEuros
            };
            await _productosFloristeriaRepository.AddAsync(nuevoProducto);
        }
    }
}