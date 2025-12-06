namespace Essencia.Backend.Dtos
{
    public class MesasCreateDto
    {
        public int NumeroMesa { get; set; }
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
    }
}