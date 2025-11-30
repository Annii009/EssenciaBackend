namespace Models
{
    public class ProductosFloristeria
    {
        public int ProductosFloristeriaId { get; set; }
        public string Nombre { get; set; }
        public string ImagenRuta { get; set; }
        public string Detalle { get; set; }
        public string DescripcionCuidados { get; set; }
        public decimal PrecioEuros { get; set; }

        public ProductosFloristeria() { }

        public ProductosFloristeria(int productosFloristeriaId, string nombre, string imagenRuta, 
                                   string detalle, string descripcionCuidados, decimal precioEuros)
        {
            ProductosFloristeriaId = productosFloristeriaId;
            Nombre = nombre;
            ImagenRuta = imagenRuta;
            Detalle = detalle;
            DescripcionCuidados = descripcionCuidados;
            PrecioEuros = precioEuros;
        }
    }
}