using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.Dtos
{
    public class AlergenosCafeteriaCreateDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El ProductoId debe ser mayor que 0.")]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El alérgeno no puede superar los 100 caracteres.")]
        public string Alergeno { get; set; } = string.Empty;
    }
}
