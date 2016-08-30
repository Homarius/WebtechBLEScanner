using System;
using System.Collections.Generic;
using SQLite;

namespace WebtechProject
{
    /// <summary>
    /// The interface for all database tasks
    /// </summary>
	public interface ISQLite
	{
        /// <summary>
        /// Connect to the local database
        /// </summary>
        /// <returns>The connection to the local database</returns>
		SQLiteConnection GetConnection();
	}
}

