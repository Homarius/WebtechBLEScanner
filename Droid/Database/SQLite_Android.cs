using System;
using System.IO;
using WebtechProject.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace WebtechProject.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android() { }
		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "SensorDataSQLite.db3";
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path, true);
			// Return the database connection
			return conn;
		}
	}
}

