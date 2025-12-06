using Essencia.Backend.DTOs.DetallesPedido;
using Essencia.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly IDetallePedidoService _detallePedidoService;

        public DetallesPedidoController(IDetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }

        // GET api/detallespedido/pedido/1000
        [HttpGet("pedido/{pedidoId}")]
        public async Task<IActionResult> GetDetallesByPedido(int pedidoId)
        {
            var detalles = await _detallePedidoService.GetDetallesByPedidoAsync(pedidoId);
            return Ok(detalles);
        }

        // GET api/detallespedido/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleById(int id)
        {
            var detalle = await _detallePedidoService.GetDetalleByIdAsync(id);
            if (detalle == null)
                return NotFound();

            return Ok(detalle);
        }

        // POST api/detallespedido
        [HttpPost]
        public async Task<IActionResult> CreateDetalle([FromBody] DetallePedidoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevo = await _detallePedidoService.CreateDetalleAsync(dto);

            return CreatedAtAction(
                nameof(GetDetalleById),
                new { id = nuevo.DetallePedidoId },
                nuevo);
        }

        // DELETE api/detallespedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            var existente = await _detallePedidoService.GetDetalleByIdAsync(id);
            if (existente == null)
                return NotFound();

            await _detallePedidoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
