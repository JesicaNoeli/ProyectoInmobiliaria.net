using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInmobiliaria.Models
{
    public class RepositorioInmueble
    {
		private readonly string connectionString;
		private readonly IConfiguration configuration;
		public RepositorioInmueble(IConfiguration configuration)
		{
			this.configuration = configuration;
			connectionString = configuration["ConnectionStrings:DefaultConnection"];
		}

		public int Alta(Inmueble i)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Inmuebles (Direccion, CantAmbientes, Tipo, Uso, Costo, IdProp, Disponible) " +
					"VALUES (@direccion, @ambientes, @tipo, @uso, @costo, @propietarioId, @disponible);" +
					"SELECT SCOPE_IDENTITY();";//devuelve el id insertado (LAST_INSERT_ID para mysql)
				using (var command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@direccion", i.Direccion);
					command.Parameters.AddWithValue("@ambientes", i.CantAmbientes);
					command.Parameters.AddWithValue("@costo", i.Costo);
					command.Parameters.AddWithValue("@tipo", i.Tipo);
					command.Parameters.AddWithValue("@uso", i.Uso);
					command.Parameters.AddWithValue("@propietarioId", i.IdProp);
					command.Parameters.AddWithValue("@disponible", i.Disponible);
					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					i.IdInm = res;
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
				string sql = $"DELETE FROM Inmuebles WHERE IdInm = {id}";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}
		public int Modificacion(Inmueble i)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = "UPDATE Inmuebles SET " +
					"Direccion=@direccion, CantAmbientes=@ambientes, Uso=@uso, Disponible=@disponible, Tipo=@tipo, Costo=@costo, IdProp=@propietarioId " +
					"WHERE IdInm = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@direccion", i.Direccion);
					command.Parameters.AddWithValue("@ambientes", i.CantAmbientes);
					command.Parameters.AddWithValue("@disponible", i.Disponible);
					command.Parameters.AddWithValue("@costo", i.Costo);
					command.Parameters.AddWithValue("@uso", i.Uso);
					command.Parameters.AddWithValue("@propietarioId", i.IdProp);
					command.Parameters.AddWithValue("@tipo", i.Tipo);
					command.Parameters.AddWithValue("@id", i.IdInm);
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public int NoDisponible(Inmueble inm)
		{
			int i = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE Inmuebles SET Disponible= {0} " +
					$"WHERE IdInm = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					//command.Parameters.AddWithValue("@disponible", inm.Disponible);
					command.Parameters.AddWithValue("@id", inm.IdInm);
					command.CommandType = CommandType.Text;
					connection.Open();
					i = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return i;
		}

		public int Disponible(Inmueble inm)
		{
			int i = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE Inmuebles SET Disponible= {1} " +
					$"WHERE IdInm = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					//command.Parameters.AddWithValue("@disponible", inm.Disponible);
					command.Parameters.AddWithValue("@id", inm.IdInm);
					command.CommandType = CommandType.Text;
					connection.Open();
					i = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return i;
		}


		public IList<Inmueble> ObtenerTodos()
		{
			IList<Inmueble> res = new List<Inmueble>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInm, Direccion, CantAmbientes, Tipo, Uso, Costo, i.IdProp, Disponible," +
					$" p.Nombre, p.Apellido" +
					$" FROM Inmuebles i INNER JOIN Propietarios p ON i.IdProp = p.IdProp";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Inmueble inm = new Inmueble
						{
							IdInm = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							CantAmbientes = reader.GetInt32(2),
							Tipo = reader.GetString(3),
							Uso = reader.GetString(4),
							Costo = reader.GetDecimal(5),
							IdProp = reader.GetInt32(6),
							Disponible = reader.GetBoolean(7),
							Propietario = new Propietario
							{
								//IdProp = reader.GetInt32(8),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							}
						};
						res.Add(inm);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Inmueble ObtenerPorId(int id)
		{
			Inmueble inm = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInm, Direccion, CantAmbientes, Tipo, Uso, Costo, i.IdProp, Disponible, p.Nombre, p.Apellido" +
					$" FROM Inmuebles i INNER JOIN Propietarios p ON i.IdProp = p.IdProp" +
					$" WHERE IdInm=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						inm = new Inmueble
						{
							IdInm = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							CantAmbientes = reader.GetInt32(2),
							Tipo = reader.GetString(3),
							Uso = reader.GetString(4),
							Costo = reader.GetDecimal(5),
							IdProp = reader.GetInt32(6),
							Disponible = reader.GetBoolean(7),
							Propietario = new Propietario
							{
								//IdProp = reader.GetInt32(8),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							}
						};
					}
					connection.Close();
				}
			}
			return inm;
		}

		public IList<Inmueble> ObtenerSiDisponible()
		{
			IList<Inmueble> inm = new List<Inmueble>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInm, Direccion, CantAmbientes, Tipo, Uso, Costo, i.IdProp, Disponible, p.Nombre, p.Apellido" +
					$" FROM Inmuebles i INNER JOIN Propietarios p ON i.IdProp = p.IdProp" +
					$" WHERE Disponible= {1} ";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Inmueble i = new Inmueble
						{
							IdInm = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							CantAmbientes = reader.GetInt32(2),
							Tipo = reader.GetString(3),
							Uso = reader.GetString(4),
							Costo = reader.GetDecimal(5),
							IdProp = reader.GetInt32(6),
							Disponible = reader.GetBoolean(7),
							Propietario = new Propietario
							{
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							}
						};
						inm.Add(i);
					}
					connection.Close();
				}
			}
			return inm;
		}

		public IList<Inmueble> BuscarPorPropietario(int idProp)
		{
			List<Inmueble> res = new List<Inmueble>();
			Inmueble inm = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInm, Direccion, CantAmbientes, Tipo, Uso, Costo, i.IdProp, Disponible, p.Nombre, p.Apellido" +
					$" FROM Inmuebles i INNER JOIN Propietarios p ON i.IdProp = p.IdProp" +
					$" WHERE i.IdProp=@idPropietario";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idPropietario", SqlDbType.Int).Value = idProp;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						inm = new Inmueble
						{
							IdInm = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							CantAmbientes = reader.GetInt32(2),
							Tipo = reader.GetString(3),
							Uso = reader.GetString(4),
							Costo = reader.GetDecimal(5),
							IdProp = reader.GetInt32(6),
							Disponible = reader.GetBoolean(7),
							Propietario = new Propietario
							{
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9)
							}
						};
						res.Add(inm);
					}
					connection.Close();
				}
			}
			return res;
		}

		public IList<Inmueble> BuscarDesocupados(DateTime i, DateTime f)
		{
			List<Inmueble> res = new List<Inmueble>();
			Inmueble inm = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT i.IdInm, Direccion, CantAmbientes, Tipo, Uso, Costo, i.IdProp, Disponible, " +
					$"p.Nombre, p.Apellido "+ 
					$" FROM Inmuebles i INNER JOIN Contratos c ON i.IdInm = c.IdInm  INNER JOIN Propietarios p ON i.IdProp = p.IdProp " +
					$" WHERE ( @fechaInicio > FechaCierre) OR (FechaInicio > @fechaCierre) "+
					$"UNION SELECT i.IdInm, Direccion, CantAmbientes, Tipo, Uso, Costo, i.IdProp, Disponible, p.Nombre, p.Apellido FROM Inmuebles i INNER JOIN Propietarios p ON i.IdProp = p.IdProp WHERE i.IdInm NOT IN (SELECT i.IdInm FROM Inmuebles i INNER JOIN Contratos c ON i.IdInm = c.IdInm) ";
				
				using (SqlCommand command = new SqlCommand(sql, connection))
				{ 
					command.Parameters.Add("@fechaCierre", SqlDbType.DateTime).Value = f;
					command.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = i;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{ 
						inm = new Inmueble
						{
							IdInm = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							CantAmbientes = reader.GetInt32(2),
							Tipo = reader.GetString(3),
							Uso = reader.GetString(4),
							Costo = reader.GetDecimal(5),
							IdProp = reader.GetInt32(6),
							Disponible = reader.GetBoolean(7),
							Propietario = new Propietario {
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9)
							}
							
						};
						res.Add(inm);
					}
					connection.Close();
				}
			}
			return res;
		}
	}
}
