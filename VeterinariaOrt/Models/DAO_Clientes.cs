using VeterinariaOrt.Models;
namespace VeterinariaOrt.Models;

public class DAO_Clientes
{
    VeterinariaContext context = new VeterinariaContext();


    public void CrearClientes(Clientes cliente)
    { 
    bool estado = false;

        try
        {
            context.Clientes.Add(cliente);
            Console.WriteLine(cliente);
            context.SaveChanges();
            Console.WriteLine(cliente);

            estado = true;
        }
        catch (Exception ex)
        {

            Console.WriteLine("Ocurrió un error: " + ex.InnerException?.Message
);

        }
        // return estado;

    }

}
