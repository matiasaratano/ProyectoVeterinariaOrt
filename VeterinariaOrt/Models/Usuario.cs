using System;
using System.Collections.Generic;

namespace VeterinariaOrt.Models;

public  class Usuario
{
    public int IdUsuario { get; set; }
    public int DNI { get; set; }
    public string? Apellido { get; set; }
    public string? Nombre { get; set; }

    public int Telefono { get; set; }
    public string? Mail { get; set; }

    public string? Clave { get; set; }
}
