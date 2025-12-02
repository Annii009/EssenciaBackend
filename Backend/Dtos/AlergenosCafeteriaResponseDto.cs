namespace Essencia.Backend.Dtos
{
    public class AlergenosCafeteriaResponseDto
    {
        public int AlergenoId {get; set;}
        public int ProductoId {get; set;}
        public string? ProductoNombre { get; set; }
        public string Alergeno {get; set;}
    }
}