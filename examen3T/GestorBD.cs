using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace examen3T
{
	public class GestorBD
	{
	
		private readonly MySqlConnection _conexion;

		
		public GestorBD()
		{
			
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "", 
				Database = "videotech"
			};

			
			_conexion = new MySqlConnection(builder.ConnectionString);
		}

		
		public void Insertar(Pelicula p)
		{
			
			string query = "INSERT INTO pelicula (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible)";

			try
			{
				_conexion.Open();
				using (MySqlCommand command = new MySqlCommand(query, _conexion))
				{
				
					command.Parameters.AddWithValue("@titulo", p.titulo);
					command.Parameters.AddWithValue("@director", p.director);
					command.Parameters.AddWithValue("@anyo", p.anyo);
					command.Parameters.AddWithValue("@disponible", p.disponible);

					command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error al insertar: " + ex.Message);
			}
			finally
			{
			
				if (_conexion.State == System.Data.ConnectionState.Open)
				{
					_conexion.Close();
				}
			}
		}

		
		public List<Pelicula> ObtenerTodos()
		{
			List<Pelicula> peliculas = new List<Pelicula>();
			
			string query = "SELECT titulo, director, anyo, disponible FROM pelicula";

			try
			{
				_conexion.Open();
				using (MySqlCommand command = new MySqlCommand(query, _conexion))
				{
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							
							Pelicula p = new Pelicula(
								reader.GetString("titulo"),
								reader.GetString("director"),
								reader.GetInt32("anyo"),
								reader.GetBoolean("disponible")
							);
							peliculas.Add(p);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error al obtener datos: " + ex.Message);
			}
			finally
			{
				
				if (_conexion.State == System.Data.ConnectionState.Open)
				{
					_conexion.Close();
				}
			}

			return peliculas;
		}
	}
}