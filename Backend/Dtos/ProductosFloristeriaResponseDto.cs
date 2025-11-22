using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Dtos
{
    public class ProductosFloristeriaResponseDto
    {
        public int ProductosFloristeriaId { get; set; }
        public string Nombre { get; set; }
        public string? ImagenRuta { get; set; }
        public string? Detalle { get; set; }
        public string? DescripcionCuidados { get; set; }
        public decimal PrecioEuros { get; set; }
    }
}