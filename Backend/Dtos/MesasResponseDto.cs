namespace Essencia.Backend.Dtos
{
    public class MesasResponseDto
    {
        public int MesasId { get; set; }
        public int NumeroMesa { get; set; }
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }
        public string  Ubicacion { get; set; } = string.Empty;
    }
}