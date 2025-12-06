using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.DTOs.DetallesPedido
{
    public class DetallePedidoCreateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PedidoId { get; set; }
        public int? ProductoCafeteriaId { get; set; }
        public int? ProductoFloristeriaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }

        [Range(0.01, 10000, ErrorMessage = "El precio unitario debe ser mayor que 0.")]
        public decimal PrecioUnitario { get; set; }
    }
}
