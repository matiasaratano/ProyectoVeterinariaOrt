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
        
        [Required]//[ForeignKey("DNI")]
        public int DNI { get; set; }



    }
}
