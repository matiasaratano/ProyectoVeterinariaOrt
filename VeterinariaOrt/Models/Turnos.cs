using System.ComponentModel.DataAnnotations;

namespace VeterinariaOrt.Models
{
    public class Turnos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Dia { get; set; }
        [Required]
        public string? Hora { get; set; }

        public string? Nombre { get; set; }

        public string? Tipo { get; set; }
    }
}
