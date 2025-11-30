namespace Essencia.Backend.Dtos
{
    public class IngredientesCafeteriaResponseDto
    {
        public int IngredientesId { get; set; }
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }
        public string Ingrediente { get; set; }
    }
}