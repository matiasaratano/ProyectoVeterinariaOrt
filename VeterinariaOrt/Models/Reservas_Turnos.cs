using System.ComponentModel.DataAnnotations;

namespace VeterinariaOrt.Models
{
    public class Reservas_Turnos
    {
        [Key]
        public int Id_Turno { get; set; }
        [Required]
        public int Dni { get; set; }
        [Required]
        public int Id_Mascota { get; set; }
        [Required]
        public string? Dia { get; set; }
        [Required]
        public string? Horario { get; set; }
        [Required]
        public int Matricula { get; set; }
    }
}
