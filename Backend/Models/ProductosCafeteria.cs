using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Models;

public class ProductosCafeteria
{
    public int ProductosCafeteriaId { get; set; }
    public string Nombre { get; set; }
    public string Categoria {get; set;}
    public string ImagenRuta {get; set;}
    public string Descripcion {get; set;}
    public decimal PrecioEuros {get; set;}
    public List<IngredientesCafeteria> Ingredientes {get; set;} = new();
    public List<AlergenosCafeteria> Alergenos {get; set;} = new();

    public ProductosCafeteria(){}

    public ProductosCafeteria(int ProductosCafeteriaId, string Nombre, string Categoria, string ImagenRuta, string Descripcion, decimal PrecioEuros)
    {
        ProductosCafeteriaId = ProductosCafeteriaId;
        Nombre = Nombre;
        Categoria = Categoria;
        ImagenRuta = ImagenRuta;
        Descripcion = Descripcion;
        PrecioEuros = PrecioEuros;
    }
}


