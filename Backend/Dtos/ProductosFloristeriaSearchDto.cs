namespace Essencia.Backend.Dtos
{
    public class ProductosFloristeriaSearchDto
    {
        public string? Texto { get; set; }
        public decimal? MinPrecio { get; set; }
        public decimal? MaxPrecio { get; set; }
        public string? OrdenPor { get; set; } 
        public string? OrdenDireccion { get; set; }
    }
}
