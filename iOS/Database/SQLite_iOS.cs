using System;
using System.IO;
using WebtechProject.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_iOS))]
namespace WebtechProject.iOS
{
public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS() { }
		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "SensorDataSQLite.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path, true);
			// Return the database connection
			return conn;
		}
	}
}

