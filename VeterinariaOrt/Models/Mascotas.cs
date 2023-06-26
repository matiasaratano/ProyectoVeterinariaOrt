using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaOrt.Models
{
    public class Mascotas
    {
        [Key]
        public int Id_Mascota { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Tipo { get; set; }
        [Required]
        public int Edad { get; set; }

        [ForeignKey("Propietario")]
        public int DNI { get; set; }

        public virtual Usuario Propietario { get; set; }
    }
}
