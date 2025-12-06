using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.Dtos
{
    public class ProductosCafeteriaUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Categoria { get; set; }

        [StringLength(260)]
        public string? ImagenRuta { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Range(0.01, 1000)]
        public decimal PrecioEuros { get; set; }
    }
}
