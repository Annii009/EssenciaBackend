namespace Essencia.Backend.Dtos
{
    public class PedidosCreateDto
    {
        public int MesaId { get; set; }
        public DateTime FechaHoraPedido {get; set;}
        public bool PedidoCompletado { get; set; } = false;
        public decimal Total {get; set;}
        public string Notas { get; set; } = string.Empty;
    }
}