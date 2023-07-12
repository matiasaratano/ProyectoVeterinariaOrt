
using VeterinariaOrt.Models;
namespace VeterinariaOrt.Models;

public class DAO_Mascota
{
    VeterinariaContext context = new VeterinariaContext();


    public void CrearMascota(Mascotas mascota)
    {
        try
        {
            context.Mascotas.Add(mascota);
            context.SaveChanges();

        }
        catch (Exception ex)
        {

            Console.WriteLine("Ocurrió un error: " + ex.InnerException?.Message);

        }

    }
}
