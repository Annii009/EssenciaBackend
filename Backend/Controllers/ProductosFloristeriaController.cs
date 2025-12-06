using Microsoft.AspNetCore.Mvc;
using Essencia.Backend.Dtos;
using Essencia.Backend.Services;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosFloristeriaController : ControllerBase
    {
        private readonly IProductosFloristeriaService _productosFloristeriaService;

        public ProductosFloristeriaController(IProductosFloristeriaService productosFloristeriaService)
        {
            _productosFloristeriaService = productosFloristeriaService;
        }

        // GET api/productosfloristeria
        [HttpGet]
        public async Task<IActionResult> GetAllProductosFloristeria()
        {
            var productos = await _productosFloristeriaService.GetAllProductosFloristeriaAsync();
            return Ok(productos);
        }

        // GET api/productosfloristeria/5
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

        // POST api/productosfloristeria
        [HttpPost]
        public async Task<IActionResult> CreateProductoFloristeria([FromBody] ProductosFloristeriaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevoProducto = await _productosFloristeriaService.CreatProductoFloristeriaAsync(dto);

            return CreatedAtAction(
                nameof(GetProductoFloristeriaById),
                new { id = nuevoProducto.ProductosFloristeriaId },
                nuevoProducto);
        }

        // DELETE api/productosfloristeria/5
        [HttpDelete("{id}")]
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
