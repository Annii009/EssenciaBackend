using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.Dtos
{
    public class PedidosCreateDto
    {
        [Range(1, int.MaxValue)]
        public int MesaId { get; set; }

        [Required]
        public DateTime FechaHoraPedido { get; set; }

        public bool PedidoCompletado { get; set; } = false;

        [Range(0, 10000, ErrorMessage = "El total no puede ser negativo.")]
        public decimal Total { get; set; }

        [StringLength(500, ErrorMessage = "Las notas no pueden superar los 500 caracteres.")]
        public string Notas { get; set; } = string.Empty;
    }
}
