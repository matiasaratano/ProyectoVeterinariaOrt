using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaOrt.Models
{
    public class Reservas_Turnos
    {
        [Key]
        public int Id { get; set; }
        [Required][ForeignKey("Turno")]
        public int Id_Turno { get; set; }

        public Turnos Turno { get; set; }

        [ForeignKey("Usuario")]
        public int Dni { get; set; }

        public Usuario Usuario { get; set; }

        [Required]

        public string? Dia { get; set; }
        [Required]

        public string? Horario { get; set; }
    }
}
