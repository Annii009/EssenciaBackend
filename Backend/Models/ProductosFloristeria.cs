using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("ProductosFloristeria")]
    public class ProductosFloristeria
    {
        [Key]
        [Column("ID")]
        public int ProductosFloristeriaId { get; set; }
        
        [Column("Nombre")]
        public string Nombre { get; set; }
        
        [Column("ImagenRuta")]
        public string ImagenRuta { get; set; }
        
        [Column("Detalle")]
        public string Detalle { get; set; }
        
        [Column("DescripcionCuidados")]
        public string DescripcionCuidados { get; set; }
        
        [Column("PrecioEuros")]
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