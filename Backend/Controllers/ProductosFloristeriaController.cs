using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Essencia.Backend.DTOs;
using Essencia.Backend.Services;

namespace Essencia.Backend.Controllers
{
    public class ProductosFloristeriaController : ControllerBase
    {
        private readonly ProductosFloristeriaService _productosFloristeriaService;

        public ProductosFloristeriaController(ProductosFloristeriaService productosFloristeriaService)
        {
            _productosFloristeriaService = productosFloristeriaService;
        }

        public async Task<IActionResult> GetAllProductosFloristeria()
        {
            var productos = await _productosFloristeriaService.GetAllProductosFloristeriaAsync();
            return Ok(productos);
        }

        public async Task<IActionResult> GetProductoFloristeriaById(int id)
        {
            var producto = await _productosFloristeriaService.GetProductoFloristeriaByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        public async Task<IActionResult> CreateProductoFloristeria(ProductosFloristeriaCreateDto dto)
        {
            await _productosFloristeriaService.CreatProductoFloristeriaAsync(dto);
            return CreatedAtAction(nameof(GetProductoFloristeriaById), new { id = dto.ProductosFloristeriaId }, dto);
        }
    }
}