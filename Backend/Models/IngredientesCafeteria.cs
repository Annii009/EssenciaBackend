using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Models;
public class IngredientesCafeteria
{
    public int IngredientesId {get; set;}
    public int ProductoId {get; set;}
    public ProductoCafeteria? Producto {get; set;}
    public string Ingrediente {get; set;}

    
    
}