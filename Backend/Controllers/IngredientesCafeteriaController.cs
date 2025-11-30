using Essencia.Backend.Dtos;
using Essencia.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesCafeteriaController : ControllerBase
    {
        private readonly IngredientesCafeteriaService _ingredientesCafeteriaService;

        public IngredientesCafeteriaController(IngredientesCafeteriaService ingredientesCafeteriaService)
        {
            _ingredientesCafeteriaService = ingredientesCafeteriaService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllIngredientesCafeteria()
        {
            var ingredientes = await _ingredientesCafeteriaService.GetAllIngredientesCafeteriaAsync();
            return Ok(ingredientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredienteCafeteriaById(int id)
        {
            var ingrediente = await _ingredientesCafeteriaService.GetIngredienteCafeteriaByIdAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return Ok(ingrediente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredienteCafeteria([FromBody] IngredientesCafeteriaCreateDto dto)
        {
            var nuevoIngrediente = await _ingredientesCafeteriaService.CreatIngredienteCafeteriaAsync(dto);
            return CreatedAtAction(nameof(GetIngredienteCafeteriaById),
                                  new { id = nuevoIngrediente.IngredientesId },
                                  nuevoIngrediente);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteIngredienteCafeteria(int id)
        {

            var ingrediente = await _ingredientesCafeteriaService.GetIngredienteCafeteriaByIdAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            await _ingredientesCafeteriaService.DeleteAsync(id);
            return NoContent();

        }
    }
}
