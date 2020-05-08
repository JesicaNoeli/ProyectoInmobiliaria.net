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
                    $"SELECT Scope_Identit();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@pago", p.IdPago);
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
                    $"Inm.Direccion," +
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
                            Contrato = new Contrato
                            {
                                IdContr = reader.GetInt32(2),
                                Inmueble = new Inmueble
                                {
                                    IdInm = reader.GetInt32(3),
                                    Direccion = reader.GetString(4),
                                },
                                Inquilino = new Inquilino
                                {
                                    IdInq = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Apellido = reader.GetString(7)
                                }
                            },
                            FechaPago = reader.GetDateTime(8),
                            Importe = reader.GetDecimal(9)
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
                string sql = $"SELECT P.IdPago, NumPago, P.IdContr, C.IdInm, " +
                    $"Inm.Direccion, C.IdInq, Inq.Nombre, Inq.Apellido, " +
                    $"FechaPago, P.Importe " +
                    $"FROM Pago P INNER JOIN Contrato C ON (C.IdContr=P.IdContr) " +
                    $"INNER JOIN Inmuebles Inm ON (Inm.IdInm = C.IdInm) " +
                    $"INNER JOIN Inquilinos Inq ON (Inq.IdInq = C.IdInq) " +
                    $"WHERE P.IdPago=@id";

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
                            Contrato = new Contrato
                            {
                                IdContr = reader.GetInt32(2),
                                Inmueble = new Inmueble
                                {
                                    IdInm = reader.GetInt32(3),
                                    Direccion = reader.GetString(4),
                                },
                                Inquilino = new Inquilino
                                {
                                    IdInq = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Apellido = reader.GetString(7)
                                }
                            },
                            FechaPago = reader.GetDateTime(8),
                            Importe = reader.GetDecimal(9)
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

    }
}
