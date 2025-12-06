namespace Essencia.Backend.Dtos
{
    public class PedidosResponseDto
    {
        public int PedidoId { get; set; }
        public int MesaId { get; set; }
        public DateTime FechaHoraPedido { get; set; }
        public bool PedidoCompletado { get; set; }
        public decimal Total { get; set; }
        public string Notas { get; set; } = string.Empty;

        public int? NumeroMesa { get; set; }
        public string? UbicacionMesa { get; set; }
    }
}