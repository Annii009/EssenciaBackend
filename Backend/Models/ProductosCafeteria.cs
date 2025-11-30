// ProductosCafeteria.cs
namespace Models
{
    public class ProductosCafeteria
    {
        public int ProductosCafeteriaId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string ImagenRuta { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioEuros { get; set; }

        public ProductosCafeteria() { }

        public ProductosCafeteria(int productosCafeteriaId, string nombre, string categoria, 
                                 string imagenRuta, string descripcion, decimal precioEuros)
        {
            ProductosCafeteriaId = productosCafeteriaId;
            Nombre = nombre;
            Categoria = categoria;
            ImagenRuta = imagenRuta;
            Descripcion = descripcion;
            PrecioEuros = precioEuros;
        }
    }
}