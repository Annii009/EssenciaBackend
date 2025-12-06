using System.ComponentModel.DataAnnotations;

namespace Essencia.Backend.Dtos
{
    public class MesasCreateDto
    {
        [Range(1, 500, ErrorMessage = "El número de mesa debe estar entre 1 y 500.")]
        public int NumeroMesa { get; set; }

        [Range(1, 20, ErrorMessage = "La capacidad debe estar entre 1 y 20.")]
        public int Capacidad { get; set; }

        public bool Disponible { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "La ubicación no puede superar los 50 caracteres.")]
        public string Ubicacion { get; set; } = string.Empty;
    }
}
