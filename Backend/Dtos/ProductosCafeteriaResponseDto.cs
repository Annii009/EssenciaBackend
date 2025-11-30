namespace Essencia.Backend.Dtos
{
    public class ProductosCafeteriaResponseDto
    {
        public int ProductosCafeteriaId { get; set; }
        public string Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? ImagenRuta { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioEuros { get; set; }
    }
}