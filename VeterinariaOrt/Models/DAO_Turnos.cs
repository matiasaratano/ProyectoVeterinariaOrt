using Microsoft.Data.SqlClient;
using VeterinariaOrt.Models;
namespace VeterinariaOrt.Models

{
    public class DAO_Turnos
    {
        VeterinariaContext context = new VeterinariaContext();
        public List<Turnos> ListarTurnos()
        {
            List<Turnos> turnos = new List<Turnos>();
            try
            {
                string connectionString = "Data Source = DESKTOP-PLMOM31; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true";
                string sqlQuery = "SELECT * FROM Turnos";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Turnos turno = new Turnos();

                                turno.Id = reader.GetInt32(0);
                                turno.Dia = reader.GetString(1);
                                turno.Hora = reader.GetString(2);

                                turnos.Add(turno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return turnos;
        }
    }
}
