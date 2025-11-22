using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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

        public ProductosFloristeria(int ProductosFloristeriaId, string Nombre, string ImagenRuta, string Detalle, string DescripcionCuidados, decimal PrecioEuros)
        {
            ProductosFloristeriaId = ProductosFloristeriaId;
            Nombre = Nombre;
            ImagenRuta = ImagenRuta;
            Detalle = Detalle;
            DescripcionCuidados = DescripcionCuidados;
            PrecioEuros = PrecioEuros;
        }
    }
}