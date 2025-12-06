
using Essencia.Backend.Dtos;
using Essencia.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        // GET api/pedidos
        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            var pedidos = await _pedidosService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        // GET api/pedidos/1000
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidosService.GetPedidoByIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        // POST api/pedidos
        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] PedidosCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevo = await _pedidosService.CreatePedidoAsync(dto);

            return CreatedAtAction(
                nameof(GetPedidoById),
                new { id = nuevo.PedidoId },
                nuevo);
        }

        // DELETE api/pedidos/1000
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var existente = await _pedidosService.GetPedidoByIdAsync(id);
            if (existente == null)
                return NotFound();

            await _pedidosService.DeleteAsync(id);
            return NoContent();
        }
    }
}
