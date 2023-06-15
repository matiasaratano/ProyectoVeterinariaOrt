﻿using VeterinariaOrt.Models;
namespace VeterinariaOrt.Models;

public class DAO_Clientes
{
    VeterinariaContext context = new VeterinariaContext();


    public void CrearClientes(Clientes cliente)
    { 


        try
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();           
        }
        catch (Exception ex)
        {

            Console.WriteLine("Ocurrió un error: " + ex.InnerException?.Message);

        }
      

    }

}
