using Microsoft.AspNetCore.Mvc;
using Essencia.Backend.Dtos;
using Essencia.Backend.Services;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosFloristeriaController : ControllerBase
    {
        private readonly ProductosFloristeriaService _productosFloristeriaService;

        public ProductosFloristeriaController(ProductosFloristeriaService productosFloristeriaService)
        {
            _productosFloristeriaService = productosFloristeriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductosFloristeria()
        {
            var productos = await _productosFloristeriaService.GetAllProductosFloristeriaAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoFloristeriaById(int id)
        {
            var producto = await _productosFloristeriaService.GetProductoFloristeriaByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductoFloristeria([FromBody] ProductosFloristeriaCreateDto dto)
        {
            var nuevoProducto = await _productosFloristeriaService.CreatProductoFloristeriaAsync(dto);
            return CreatedAtAction(nameof(GetProductoFloristeriaById),
                                  new { id = nuevoProducto.ProductosFloristeriaId },
                                  nuevoProducto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductoFloristeria(int id)
        {

            var producto = await _productosFloristeriaService.GetProductoFloristeriaByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            await _productosFloristeriaService.DeleteAsync(id);
            return NoContent();

        }
    }
}