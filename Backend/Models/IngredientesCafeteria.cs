namespace Models
{
    public class IngredientesCafeteria
    {
        public int IngredientesId { get; set; }
        public int ProductoId { get; set; }
        public ProductosCafeteria? Producto { get; set; }
        public string Ingrediente { get; set; }

        public IngredientesCafeteria() { }

        public IngredientesCafeteria(int ingredientesId, int productoId, ProductosCafeteria? producto, string ingrediente)
        {
            IngredientesId = ingredientesId;
            ProductoId = productoId;
            Producto = producto;
            Ingrediente = ingrediente;
        }
    }
}