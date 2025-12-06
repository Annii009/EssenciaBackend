using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.Dtos
{
    public class ProductosFloristeriaCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(260)]
        public string? ImagenRuta { get; set; }

        [StringLength(500)]
        public string? Detalle { get; set; }

        [StringLength(1000)]
        public string? DescripcionCuidados { get; set; }

        [Range(0.01, 1000)]
        public decimal PrecioEuros { get; set; }
    }
}
