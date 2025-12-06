namespace Essencia.Backend.Dtos
{
    public class ProductosCafeteriaSearchDto
    {
        public string? Categoria { get; set; }
        public decimal? MinPrecio { get; set; }
        public decimal? MaxPrecio { get; set; }

        public string? OrdenPor { get; set; }

        public string? OrdenDireccion { get; set; }
    }
}
