using examen3T;

List<Pelicula> listaPeliculas = new List<Pelicula>();
listaPeliculas.Add(new Pelicula("El Padrino", "Francis Ford Coppola", 1972, true));
listaPeliculas.Add(new Pelicula("Interestellar", "Christopher Nolan", 2014, false));
listaPeliculas.Add(new Pelicula("El Señor de los Anillos: La Comunidad del Anillo", "Peter Jackson", 2001, true));

foreach (Pelicula pelicula in listaPeliculas)
{
	Console.WriteLine(pelicula.ToString());
}
Console.WriteLine();

Console.WriteLine("Peliculas de Nolan");
{
	foreach (Pelicula pelicula in listaPeliculas)
	{
		if (pelicula.getDirector() == "Christopher Nolan")
		{
			Console.WriteLine(pelicula.ToString());
		}
	}
	Console.WriteLine();
}

Console.WriteLine("Fecha de registro");
Console.WriteLine(DateTime.Now.ToShortTimeString());

 static void GuardarPeliculas(List<Pelicula> peliculas, string ruta)
{
	using (StreamWriter writer = new StreamWriter(ruta))
	{
		foreach (Pelicula pelicula in peliculas)
		{
			writer.WriteLine(pelicula.ToString());
		}

		writer.WriteLine($"{p.Titulo};{p.Director};{p.Anio};{p.Visto}");
		
		writer.Close();
	}
}
