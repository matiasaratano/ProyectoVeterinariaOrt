using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaOrt.Models
{
    public class Reservas_Turnos
    {
        [Key]
        public int Id_Turno { get; set; }

        [Required]
        [ForeignKey("Dni")]
        public Clientes Clientes { get; set; }
        public int Dni { get; set; }
        [Required]
        [ForeignKey("Id_Mascota")]
        public Mascotas Mascotas { get; set; }
        [Required]
        public string? Dia { get; set; }
        [Required]
        public string? Horario { get; set; }
        [ForeignKey("Matricula")]
        public Veterinarios Veterinarios { get; set; }
    }
}
