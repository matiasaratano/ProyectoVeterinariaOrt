using System.ComponentModel.DataAnnotations;

namespace VeterinariaOrt.Models
{
    public class Veterinarios
    {
        [Key]
        public int Matricula { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
    }
}
