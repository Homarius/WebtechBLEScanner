using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WebtechProject
{
    /// <summary>
    /// Class for storing data recevied from the BLE sensor
    /// </summary>
	public class SensorData
	{
		private DateTime creationDate;
		private double speedValue;
		private int cadenceValue;

        /// <summary>
        /// The id of the object. Needed for database indexing
        /// </summary>
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

        /// <summary>
        /// The date the point was created
        /// </summary>
		public DateTime CreationDate
		{
			get { return creationDate; }
			set { creationDate = value; }
		}

        /// <summary>
        /// The speed value transmitted by the sensor
        /// </summary>
		public double SpeedValue
		{
			get { return speedValue; }
			set { speedValue = value; }
		}

        /// <summary>
        /// The cadence value transmitted by the sensir
        /// </summary>
		public int CadenceValue
		{
			get { return cadenceValue; }
			set { cadenceValue = value; }
		}

        /// <summary>
        /// Empty constructor which is need by sqlite-net
        /// </summary>
		public SensorData()
		{
		}

        /// <summary>
        /// Creates a new SensorData object with the given values
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="speed">Speed value</param>
        /// <param name="cadence">Cadence value</param>
		public SensorData(DateTime date, double speed, int cadence)
		{
			this.CreationDate = date;
			this.SpeedValue = speed;
			this.CadenceValue = cadence;
		}
	}
}
