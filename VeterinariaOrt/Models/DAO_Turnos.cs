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
                string connectionString = "Data Source = DESKTOP-0DV3D4L\\MSSQLSERVER01; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true";
                string sqlQuery = "SELECT A.Id,A.Dia,A.Hora FROM Turnos a LEFT JOIN Reservas_Turnos v ON A.Id = V.Id_Turno WHERE V.Id_Turno IS NULL";

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
