using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInmobiliaria.Models
{
    public class RepositorioContrato
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;
        public RepositorioContrato(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public int Alta(Contrato c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Contratos(idInm, idInq, FechaInicio, FechaCierre, Monto, Vigente)  " +
                    $"VALUES(@idInm, @idInq, @fechaI, @fechaC, @monto, @vigente)" +
                    $"SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@idInm", c.IdInm);
                    command.Parameters.AddWithValue("@idInq", c.IdInq);
                    command.Parameters.AddWithValue("@fechaI", c.FechaInicio);
                    command.Parameters.AddWithValue("@fechaC", c.FechaCierre);
                    command.Parameters.AddWithValue("@monto", c.Monto);
                    command.Parameters.AddWithValue("@vigente", c.Vigente);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    c.IdContr = res;
                    connection.Close();
                }
            }
            return res;
        }
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Contratos WHERE IdContr=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public int Modificacion(Contrato c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET IdInm=@idInm, idInq=@idInq, FechaInicio=@fechaI, FechaCierre=@fechaC, Monto=@monto, Vigente=@vigente " +
                        $"WHERE idContr=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@idInm", c.IdInm);
                    command.Parameters.AddWithValue("@idInq", c.IdInq);
                    command.Parameters.AddWithValue("@fechaI", c.FechaInicio);
                    command.Parameters.AddWithValue("@fechaC", c.FechaCierre);
                    command.Parameters.AddWithValue("@monto", c.Monto);
                    command.Parameters.AddWithValue("@vigente", c.Vigente);
                    command.Parameters.AddWithValue("@id", c.IdContr);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return res;
        }

        public int NoVigente(Contrato con)
        {
            int i = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET Vigente= {0} " +
                    $"WHERE IdContr = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                     command.Parameters.AddWithValue("@id", con.IdContr);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    i = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return i;
        }

        public int Vigente(Contrato con)
        {
            int i = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contratos SET Vigente= {1} " +
                   $"WHERE IdContr = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", con.IdContr);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    i = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return i;
        }

        public IList<Contrato> ObtenerTodos()
        {
            IList<Contrato> res = new List<Contrato>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente," +
                    $" inq.Nombre, inq.Apellido," + 
                    $" inm.Direccion" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contrato c = new Contrato
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm= reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),

                            Inquilino = new Inquilino
                            {
                                IdInq = reader.GetInt32(1),
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmueble = new Inmueble
                            {
                                IdInm= reader.GetInt32(2),
                                Direccion = reader.GetString(9)
                            }


                        }; res.Add(c);
                    }

                }
                connection.Close();
            }

            return res;

        }

        public IList<Contrato> ObtenerTodosPorInm(int id)
        {
            IList<Contrato> res = new List<Contrato>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente," +
                    $" inq.Nombre, inq.Apellido," +
                    $" inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq" +
                    $" WHERE c.IdInm = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contrato c = new Contrato
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),

                            Inquilino = new Inquilino
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmueble = new Inmueble
                            {
                                Direccion = reader.GetString(9),
                                Tipo= reader.GetString(10)
                            }


                        }; res.Add(c);
                    }

                }
                connection.Close();
            }

            return res;

        }

        public Contrato ObtenerPorId(int id)
        {
            Contrato con = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $" SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente, " +
                    $" inq.Nombre, inq.Apellido ," +
                    $" inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm " +
                    $" INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq " +
                    $" WHERE c.IdContr = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        con = new Contrato
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),


                            Inquilino = new Inquilino
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmueble = new Inmueble
                            {
                                Direccion = reader.GetString(9),
                                Tipo = reader.GetString(10)
                            }


                        };
                    }

                }
                connection.Close();
            }

            return con;

        }

        public Contrato ObtenerPorInm(int id)
        {
            Contrato con = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $" SELECT IdContr, c.IdInq, c.IdInm, FechaInicio, FechaCierre, Monto, Vigente, " +
                    $" inq.Nombre, inq.Apellido ," + 
                    $" inm.Direccion, inm.Tipo" +
                    $" FROM Contratos c INNER JOIN Inmuebles inm ON c.IdInm = inm.IdInm " +
                    $" INNER JOIN Inquilinos inq ON c.IdInq = inq.IdInq " +
                    $" WHERE c.IdInm = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        con = new Contrato
                        {
                            IdContr = reader.GetInt32(0),
                            IdInq = reader.GetInt32(1),
                            IdInm = reader.GetInt32(2),
                            FechaInicio = reader.GetDateTime(3),
                            FechaCierre = reader.GetDateTime(4),
                            Monto = reader.GetDecimal(5),
                            Vigente = reader.GetBoolean(6),


                            Inquilino = new Inquilino
                            {
                                Nombre = reader.GetString(7),
                                Apellido = reader.GetString(8),
                            },

                            Inmueble = new Inmueble
                            {
                                Direccion = reader.GetString(9),
                                Tipo = reader.GetString(10)
                            }


                        };
                    }

                }
                connection.Close();
            }

            return con;

        }
    }
}
