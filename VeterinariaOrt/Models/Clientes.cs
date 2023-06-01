using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaOrt.Models
{
    public class Clientes
    {
        [Key]
        public int DNI { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }

        public string? Email { get; set; }
        
        public int Telefono { get; set; }


    }
}
