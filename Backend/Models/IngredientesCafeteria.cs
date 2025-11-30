using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models;

[Table("IngredientesCafeteria")]
public class IngredientesCafeteria
{
    [Key]
    [Column("ID")]
    public int IngredientesId {get; set;}
    [Key]
    [Column("ProductoCafeteriaId")]
    public ProductosCafeteria? Producto {get; set;}
    [Column("Ingrediente")]
    public string Ingrediente {get; set;}

    public IngredientesCafeteria(){}

    public IngredientesCafeteria(int ingredientesId, ProductosCafeteria? producto, string ingrediente)
    {
        IngredientesId = ingredientesId;
        Producto = producto;
        Ingrediente = ingrediente;
    }
}