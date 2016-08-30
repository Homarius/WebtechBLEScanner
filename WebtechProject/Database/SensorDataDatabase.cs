using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Database object. Contains all required functions
    /// </summary>
	public class SensorDataDatabase
	{
		static object locker = new object();

		SQLiteConnection database;

        /// <summary>
        /// Creates a new database or connects to the existing
        /// </summary>
		public SensorDataDatabase()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			// create the tables
			database.CreateTable<SensorData>();
		}

        /// <summary>
        /// Funtion to get all items
        /// </summary>
        /// <returns>All database items</returns>
		public IEnumerable<SensorData> GetItems()
		{
			lock(locker)
			{
				return (from i in database.Table<SensorData>() select i).ToList();
			}
		}

        /// <summary>
        /// Funtion to get items of a given time span
        /// </summary>
        /// <param name="startDate">The first date for which items will be selected</param>
        /// <param name="endDate">The last date for which items will be selected</param>
        /// <returns></returns>
        public IEnumerable<SensorData> GetItems(DateTime startDate, DateTime endDate)
        {
            lock (locker)
            {
                if (startDate != null && endDate != null)
                {
                    return database.Query<SensorData>(String.Format("SELECT * FROM [SensorData] WHERE [CreationDate] BETWEEN {0} AND {1}", startDate.Ticks, endDate.Ticks));
                }
                else
                    return GetItems();
            }
        }

        /// <summary>
        /// Returns one item form the database with the given id
        /// </summary>
        /// <param name="id">id of the items</param>
        /// <returns>The item with the id</returns>
		public SensorData GetItem(int id)
		{
			lock(locker)
			{
				return database.Table<SensorData>().FirstOrDefault(x => x.ID == id);
			}
		}

        /// <summary>
        /// Stores an item in the databsa and auto increments it's id
        /// </summary>
        /// <param name="item">The item which will be stored</param>
        /// <returns>The id given to the object</returns>
		public int SaveItem(SensorData item)
		{
			lock(locker)
			{
				if (item.ID != 0)
				{
					database.Update(item);
					return item.ID;
				}
				else
				{
					return database.Insert(item);
				}
			}
		}

        /// <summary>
        /// Deletes the item corresponding to the id from the database
        /// </summary>
        /// <param name="id">id of the object which should get deleted</param>
        /// <returns>The number of objects deleted.</returns>
		public int DeleteItem(int id)
		{
			lock(locker)
			{
				return database.Delete<SensorData>(id);
			}
		}

        /// <summary>
        /// Deletes all items which are older than the given date
        /// </summary>
        /// <param name="date">The date for which older items will be deleted</param>
        /// <returns>The number of rows modified in the database as a result of this execution.</returns>
        public int DeleteItems(DateTime date)
        {
            lock(locker)
            {
                return database.Execute("DELETE FROM [SENSORDATA] WHERE [CREATIONDATE] < ?", date.Ticks);
            }
        }

        /// <summary>
        /// Deletes all items from the database
        /// </summary>
        /// <returns>The number of objects deleted.</returns>
		public int ClearDatabase()
		{
			return database.DeleteAll<SensorData>();
		}
	}
}

