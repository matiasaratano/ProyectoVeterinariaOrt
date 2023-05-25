using System.ComponentModel.DataAnnotations;

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

    }
}
