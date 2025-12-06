using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.Dtos
{
    public class IngredientesCafeteriaCreateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El ingrediente no puede superar los 200 caracteres.")]
        public string Ingrediente { get; set; } = string.Empty;
    }
}
