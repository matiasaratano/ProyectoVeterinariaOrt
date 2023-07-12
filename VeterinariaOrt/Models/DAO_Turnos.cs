using Microsoft.Data.SqlClient;
using VeterinariaOrt.Models;
using VeterinariaOrt.Servicios.Implementacion;
using static System.Runtime.InteropServices.JavaScript.JSType;
using VeterinariaOrt.Controllers;

namespace VeterinariaOrt.Models
{
    public class DAO_Turnos
    {
        VeterinariaContext context = new VeterinariaContext();
        public static IConfiguration? Configuration;
        //string connectionString = "Data Source = DESKTOP-0DV3D4L\\MSSQLSERVER01; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true";
        //string connectionString = "Data Source = localhost; initial catalog = VETERINARIA; User ID = SA; Password = Melody1234; Encrypt = true; TrustServerCertificate = true;";
        private string connectionString = "Data Source = localhost, 57000; initial catalog = Veterinaria2; User ID=SA;Password=Matiasd123;Encrypt=true; TrustServerCertificate=true;";

        public List<Turnos> ListarTurnos()
        {
            List<Turnos> turnos = new List<Turnos>();
            try
            {
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

        public List<Turnos> MisTurnos(string dni)
        {

            List<Turnos> turnos = new List<Turnos>();
            try
            {

                string sqlQuery = "SELECT  A.Dia,A.Hora, m.Nombre, m.Tipo, u.DNI, u.Apellido, u.Nombre\r\nFROM Turnos a INNER JOIN Reservas_Turnos v ON A.Id = V.Id_Turno \r\nINNER JOIN Usuario u ON u.DNI = v.Dni\r\nINNER JOIN Mascotas m ON u.dni = m.DNI\r\nWHERE u.DNI = " + dni;


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
                                turno.Dia = reader.GetString(0);
                                turno.Hora = reader.GetString(1);
                                turno.Nombre = reader.GetString(2);
                                turno.Tipo = reader.GetString(3);

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

        public bool TieneMascotaRegistrada(string dni)
        {

            string sqlQuery = "SELECT COUNT(*) FROM Mascotas WHERE Dni = @Dni";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Dni", dni);
                    int mascotaCount = (int)command.ExecuteScalar();

                    return mascotaCount > 0;
                }
            }
        }

        public bool TieneTurnoReservado(string dni)
        {

            string sqlQuery = "SELECT COUNT(*) FROM Reservas_Turnos WHERE Dni = @Dni";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Dni", dni);
                    int turnoCount = (int)command.ExecuteScalar();

                    return turnoCount > 0;
                }
            }
        }

        public void confirmarTurno(int turnoId, string dniSession)
        {
            if (!TieneMascotaRegistrada(dniSession))
            {

                Console.WriteLine("No tienes una mascota registrada. Por favor, registra una mascota antes de reservar un turno.");
                return;
            }

            if (TieneTurnoReservado(dniSession))
            {

                Console.WriteLine("Ya tienes un turno reservado.");
                return;
            }


            string sqlQuery = "INSERT INTO Reservas_Turnos (Id_Turno, Dni) VALUES (@Valor1, @Valor2)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Valor1", turnoId);
                    command.Parameters.AddWithValue("@Valor2", dniSession);

                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
