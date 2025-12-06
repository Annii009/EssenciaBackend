using Essencia.Backend.Dtos;
using Essencia.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesCafeteriaController : ControllerBase
    {
        private readonly IIngredientesCafeteriaService _ingredientesCafeteriaService;

        public IngredientesCafeteriaController(IIngredientesCafeteriaService ingredientesCafeteriaService)
        {
            _ingredientesCafeteriaService = ingredientesCafeteriaService;
        }

        // GET api/ingredientescafeteria
        [HttpGet]
        public async Task<IActionResult> GetAllIngredientesCafeteria()
        {
            var ingredientes = await _ingredientesCafeteriaService.GetAllIngredientesCafeteriaAsync();
            return Ok(ingredientes);
        }

        // GET api/ingredientescafeteria/5
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

        // POST api/ingredientescafeteria
        [HttpPost]
        public async Task<IActionResult> CreateIngredienteCafeteria([FromBody] IngredientesCafeteriaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevoIngrediente = await _ingredientesCafeteriaService.CreatIngredienteCafeteriaAsync(dto);

            return CreatedAtAction(
                nameof(GetIngredienteCafeteriaById),
                new { id = nuevoIngrediente.IngredientesId },
                nuevoIngrediente);
        }

        // DELETE api/ingredientescafeteria/5
        [HttpDelete("{id}")]
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
