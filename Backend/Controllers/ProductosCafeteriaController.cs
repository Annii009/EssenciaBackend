using Microsoft.AspNetCore.Mvc;
using Essencia.Backend.Dtos;
using Essencia.Backend.Services;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosCafeteriaController : ControllerBase
    {
        private readonly IProductosCafeteriaService _productosCafeteriaService;

        public ProductosCafeteriaController(IProductosCafeteriaService productosCafeteriaService)
        {
            _productosCafeteriaService = productosCafeteriaService;
        }

        // GET api/productoscafeteria
        [HttpGet]
        public async Task<IActionResult> GetAllProductosCafeteria()
        {
            var productos = await _productosCafeteriaService.GetAllProductosCafeteriaAsync();
            return Ok(productos);
        }

        // GET api/productoscafeteria/5
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

        // POST api/productoscafeteria
        [HttpPost]
        public async Task<IActionResult> CreateProductoCafeteria([FromBody] ProductosCafeteriaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevoProducto = await _productosCafeteriaService.CreateProductoCafeteriaAsync(dto);

            return CreatedAtAction(
                nameof(GetProductoCafeteriaById),
                new { id = nuevoProducto.ProductosCafeteriaId },
                nuevoProducto);
        }

        // PUT api/productoscafeteria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductoCafeteria(int id, [FromBody] ProductosCafeteriaUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productoActualizado = await _productosCafeteriaService.UpdateProductoCafeteriaAsync(id, dto);
            if (productoActualizado == null)
            {
                return NotFound();
            }
            return Ok(productoActualizado);
        }

        // DELETE api/productoscafeteria/5
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
