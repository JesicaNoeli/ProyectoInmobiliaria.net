using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInmobiliaria.Models
{
    public class RepositorioPago
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public RepositorioPago(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public int Alta(Pago p)
        {
            int res = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Pagos(NumPago, IdContr, FechaPago, Importe)" +
                    $"VALUES (@pago, @idContr, @fec, @importe);" +
                    $"SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@pago", p.NumPago);
                    command.Parameters.AddWithValue("@idContr", p.IdContr);
                    command.Parameters.AddWithValue("@fec", p.FechaPago);
                    command.Parameters.AddWithValue("@importe", p.Importe);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    p.IdPago = res;
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
                string sql = $"DELETE FROM Pagos WHERE idPago=@id";

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

        public int Modificacion(Pago p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Pagos SET  Importe=@importe " +
                            $"WHERE IdPago=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@importe", p.Importe);
                    command.Parameters.AddWithValue("@id", p.IdPago);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return res;
        }

        public IList<Pago> ObtenerTodos()
        {
            IList<Pago> res = new List<Pago>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumPago, p.IdContr, FechaPago, Importe, " +
                    $"c.IdInm, c.IdInq," +
                    $"Inm.Direccion, Inm.Tipo," +
                    $"  Inq.Nombre, Inq.Apellido FROM Pagos p INNER JOIN Contratos c ON p.IdContr = c.IdContr INNER JOIN Inmuebles Inm ON Inm.IdInm = c.IdInm INNER JOIN Inquilinos Inq ON Inq.IdInq = c.IdInq";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pago p = new Pago
                        {
                            IdPago = reader.GetInt32(0),
                            NumPago = reader.GetInt32(1),
                            IdContr = reader.GetInt32(2),
                            FechaPago = reader.GetDateTime(3),
                            Importe = reader.GetDecimal(4),
                            Contrato = new Contrato
                            {
                                IdInm = reader.GetInt32(5),
                                IdInq = reader.GetInt32(6),
                                Inmueble = new Inmueble
                                {
                                    Direccion = reader.GetString(7),
                                    Tipo = reader.GetString(8),
                                },
                                Inquilino = new Inquilino
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10),
                                }
                            }

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public Pago ObtenerPorId(int id)
        {
            Pago p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumPago, p.IdContr,FechaPago, Importe, " +
                     $"c.IdInq, c.IdInq," +
                    $"Inm.Direccion, Inm.Tipo," +
                    $"Inq.Nombre, Inq.Apellido FROM Pagos p INNER JOIN Contratos c ON c.IdContr=p.IdContr " +
                    $"INNER JOIN Inmuebles Inm ON Inm.IdInm = c.IdInm " +
                    $"INNER JOIN Inquilinos Inq ON Inq.IdInq = c.IdInq " +
                    $"WHERE p.IdPago=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Pago
                        {
                            IdPago = reader.GetInt32(0),
                            NumPago = reader.GetInt32(1),
                            IdContr = reader.GetInt32(2),
                            FechaPago = reader.GetDateTime(3),
                            Importe = reader.GetDecimal(4),
                            Contrato = new Contrato
                            {
                                IdInm = reader.GetInt32(5),
                                IdInq = reader.GetInt32(6),
                                Inmueble = new Inmueble
                                {
                                    Direccion = reader.GetString(7),
                                    Tipo = reader.GetString(8),
                                },
                                Inquilino = new Inquilino
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10)
                                }
                            }
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }


        public IList<Pago> ObtenerPorContr(int id)
        {
            IList<Pago> res = new List<Pago>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumPago, p.IdContr,FechaPago, Importe, " +
                     $"c.IdInq, c.IdInq," +
                    $"Inm.Direccion, Inm.Tipo," +
                    $"Inq.Nombre, Inq.Apellido FROM Pagos p INNER JOIN Contratos c ON c.IdContr=p.IdContr " +
                    $"INNER JOIN Inmuebles Inm ON Inm.IdInm = c.IdInm " +
                    $"INNER JOIN Inquilinos Inq ON Inq.IdInq = c.IdInq " +
                    $"WHERE p.IdContr=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pago p = new Pago
                        {
                            IdPago = reader.GetInt32(0),
                            NumPago = reader.GetInt32(1),
                            IdContr = reader.GetInt32(2),
                            FechaPago = reader.GetDateTime(3),
                            Importe = reader.GetDecimal(4),
                            Contrato = new Contrato
                            {
                                IdInm = reader.GetInt32(5),
                                IdInq = reader.GetInt32(6),
                                Inmueble = new Inmueble
                                {
                                    Direccion = reader.GetString(7),
                                    Tipo = reader.GetString(8),
                                },
                                Inquilino = new Inquilino
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10)
                                }
                            }
                        };
                    res.Add(p);
                }
                connection.Close();
            }
        }
            return res;

        }
    }
}
