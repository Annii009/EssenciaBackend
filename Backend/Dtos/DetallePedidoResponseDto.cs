namespace Essencia.Backend.DTOs.DetallesPedido
{
    public class DetallePedidoResponseDto
    {
        public int DetallePedidoId { get; set; }
        public int PedidoId { get; set; }

        public int? ProductoCafeteriaId { get; set; }
        public string? NombreProductoCafeteria { get; set; }

        public int? ProductoFloristeriaId { get; set; }
        public string? NombreProductoFloristeria { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
