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
                //string connectionString = "Data Source = DESKTOP-0DV3D4L\\MSSQLSERVER01; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true";
                string connectionString = "Data Source = localhost, 57000; initial catalog = Veterinaria2; User ID=SA;Password=Matiasd123;Encrypt=true; TrustServerCertificate=true;";
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

        public List<Turnos> MisTurnos(int dni)
        {
            dni = 1234567;
            List<Turnos> turnos = new List<Turnos>();
            try
            {
                //string connectionString = "Data Source = DESKTOP-0DV3D4L\\MSSQLSERVER01; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true";
                string connectionString = "Data Source = localhost, 57000; initial catalog = Veterinaria2; User ID=SA;Password=Matiasd123;Encrypt=true; TrustServerCertificate=true;";
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
        public void confirmarTurno(int turnoId)
        {
            int dniSession = 1234567;
            //string connectionString = "Data Source = DESKTOP-0DV3D4L\\MSSQLSERVER01; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true";
            string connectionString = "Data Source = localhost, 57000; initial catalog = Veterinaria2; User ID=SA;Password=Matiasd123;Encrypt=true; TrustServerCertificate=true;";
            string sqlQuery = "INSERT INTO Reservas_Turnos (Id_Turno, Dni) VALUES (@Valor1, @Valor2)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlCheckQuery = "SELECT COUNT(*) FROM Reservas_Turnos WHERE Dni = @Dni";
                int count;

                using (SqlCommand checkCommand = new SqlCommand(sqlCheckQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Dni", dniSession);
                    count = (int)checkCommand.ExecuteScalar();
                }

                if (count > 0)
                {
                    // El usuario ya tiene un turno reservado
                    // Puedes mostrar una alerta o mensaje aquí
                    Console.WriteLine("Ya tienes un turno reservado.");
                }
                else
                {
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
}
