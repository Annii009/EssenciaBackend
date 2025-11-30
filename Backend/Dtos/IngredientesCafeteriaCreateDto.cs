using Models;

namespace Essencia.Backend.Dtos
{
    public class IngredientesCafeteriaCreateDto
    {
        public ProductosCafeteria? Producto { get; set; }
        public string Ingrediente { get; set; }
    
    }

}