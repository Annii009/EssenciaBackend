
using Essencia.Backend.Dtos;
using Essencia.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesasController : ControllerBase
    {
        private readonly IMesasService _mesasService;

        public MesasController(IMesasService mesasService)
        {
            _mesasService = mesasService;
        }

        // GET api/mesas
        [HttpGet]
        public async Task<IActionResult> GetAllMesas()
        {
            var mesas = await _mesasService.GetAllMesasAsync();
            return Ok(mesas);
        }

        // GET api/mesas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMesaById(int id)
        {
            var mesa = await _mesasService.GetMesaByIdAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            return Ok(mesa);
        }

        // POST api/mesas
        [HttpPost]
        public async Task<IActionResult> CreateMesa([FromBody] MesasCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevaMesa = await _mesasService.CreateMesaAsync(dto);

            return CreatedAtAction(
                nameof(GetMesaById),
                new { id = nuevaMesa.MesasId },
                nuevaMesa);
        }

        // DELETE api/mesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            var mesa = await _mesasService.GetMesaByIdAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            await _mesasService.DeleteAsync(id);
            return NoContent();
        }
    }
}
