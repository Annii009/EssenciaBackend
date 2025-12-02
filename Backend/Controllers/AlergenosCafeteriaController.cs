using Essencia.Backend.Dtos;
using Essencia.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlergenosCafeteriaController : ControllerBase
    {
        private readonly AlergenosCafeteriaService _alergenosCafeteriaService;

        public AlergenosCafeteriaController(AlergenosCafeteriaService alergenosCafeteriaService)
        {
            _alergenosCafeteriaService = alergenosCafeteriaService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAlergenosCafeteria()
        {
            var alergenos = await _alergenosCafeteriaService.GetAllalergenosCafeteriaAsync();
            return Ok(alergenos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlergenoCafeteriaById(int id)
        {
            var alergeno = await _alergenosCafeteriaService.GetalergenoCafeteriaByIdAsync(id);
            if (alergeno == null)
            {
                return NotFound();
            }
            return Ok(alergeno);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlergenoCafeteria([FromBody] AlergenosCafeteriaCreateDto dto)
        {
            var nuevoAlergeno = await _alergenosCafeteriaService.CreatalergenoCafeteriaAsync(dto);
            return CreatedAtAction(nameof(GetAlergenoCafeteriaById),
                                  new { id = nuevoAlergeno.AlergenosId },
                                  nuevoAlergeno);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAlergenoCafeteria(int id)
        {

            var alergeno = await _alergenosCafeteriaService.GetalergenoCafeteriaByIdAsync(id);
            if (alergeno == null)
            {
                return NotFound();
            }
            await _alergenosCafeteriaService.DeleteAsync(id);
            return NoContent();

        }
    }
}
