using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Models;
public class AlergenosProductosCafeteria

{
    public int AlergenoId {get; set;}
    public int ProductoId {get; set;}

    public ProductosCafeteria? Producto {get; set;}
    public string Alergeno {get; set;}


}