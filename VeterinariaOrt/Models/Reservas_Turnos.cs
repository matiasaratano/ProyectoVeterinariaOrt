using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaOrt.Models
{
    public class Reservas_Turnos
    {
        [Key]
        public int Id { get; set; }
        [Required][ForeignKey("Turnos")]
        public int Id_Turno { get; set; }

        Turnos Turnos { get; set; }

        [ForeignKey("Usuario")]
        public int Dni { get; set; }

        Usuario Usuario { get; set; }

        [Required] [ForeignKey("Mascotas")]
        public int Id_Mascota { get; set; }
        Mascotas Mascotas { get; set; }

        [Required]
        public string? Dia { get; set; }
        [Required]
        public string? Horario { get; set; }
        [Required,ForeignKey("Veterinarios")]
        public int matricula { get; set; }
        Veterinarios Veterinarios { get; set; }
    }
}
