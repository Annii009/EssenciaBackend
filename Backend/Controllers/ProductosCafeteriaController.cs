using Microsoft.AspNetCore.Mvc;
using Essencia.Backend.Dtos;
using Essencia.Backend.Services;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosCafeteriaController : ControllerBase
    {
        private readonly ProductosCafeteriaService _productosCafeteriaService;

        public ProductosCafeteriaController(ProductosCafeteriaService productosCafeteriaService)
        {
            _productosCafeteriaService = productosCafeteriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductosCafeteria()
        {
            var productos = await _productosCafeteriaService.GetAllProductosCafeteriaAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoCafeteriaById(int id)
        {
            var producto = await _productosCafeteriaService.GetProductoCafeteriaByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductoCafeteria([FromBody] ProductosCafeteriaCreateDto dto)
        {
            var nuevoProducto = await _productosCafeteriaService.CreateProductoCafeteriaAsync(dto);
            return CreatedAtAction(nameof(GetProductoCafeteriaById),
                                  new { id = nuevoProducto.ProductosCafeteriaId },
                                  nuevoProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductoCafeteria(int id, [FromBody] ProductosCafeteriaUpdateDto dto)
        {
            var productoActualizado = await _productosCafeteriaService.UpdateProductoCafeteriaAsync(id, dto);
            if (productoActualizado == null)
            {
                return NotFound();
            }
            return Ok(productoActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoCafeteria(int id)
        {
            var producto = await _productosCafeteriaService.GetProductoCafeteriaByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            await _productosCafeteriaService.DeleteAsync(id);
            return NoContent();
        }
    }
}