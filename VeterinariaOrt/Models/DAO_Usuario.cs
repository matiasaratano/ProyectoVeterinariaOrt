using VeterinariaOrt.Models;
using VeterinariaOrt.Models;
namespace VeterinariaOrt.Models;

public class DAO_Usuario
{
    VeterinariaContext context = new VeterinariaContext();


    public void CrearUsuario(Usuario Usuario)
    { 

       
        try
        {
            context.Usuario.Add(Usuario);
            context.SaveChanges();           
        }
        catch (Exception ex)
        {

            Console.WriteLine("Ocurrió un error: " + ex.InnerException?.Message);

        }
      

    }

}
