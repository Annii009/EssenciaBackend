namespace Essencia.Backend.Dtos
{
    public class ProductosCafeteriaUpdateDto
    {
        public string Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? ImagenRuta { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioEuros { get; set; }
    }
}