using System;
using System.Collections.Generic;

namespace WebtechProject
{
    /// <summary>
    /// Provides funtions to return new random data points
    /// </summary>
	public static class MockupData
	{
        /// <summary>
        /// Returns a List of random SensorData objects
        /// </summary>
        /// <param name="listsize">How many items the returning list will contain</param>
        /// <returns></returns>
        public static List<SensorData> CreateRandomDataPointList(int listsize)
        {
            List<SensorData> tmp = new List<SensorData>();
            for(int i=0;i<listsize; i++)
            {
                tmp.Add(CreateNewRandomDataPoint());
            }
            return tmp;
        }

        /// <summary>
        /// Returns one random SensorData object
        /// </summary>
        /// <returns></returns>
        public static SensorData CreateNewRandomDataPoint()
        {
            return new SensorData(RandomDateGenerator(), RandomizerClass.rnd.Next(30), RandomizerClass.rnd.Next(200));
        }

        /// <summary>
        /// Creates a random date between now and 1 day + 1 hour ago
        /// </summary>
        /// <returns></returns>
		private static DateTime RandomDateGenerator()
		{
			return DateTime.Now.AddHours(RandomizerClass.rnd.Next(-24, 0)).AddMinutes(RandomizerClass.rnd.Next(-60, 0));
		}
	}
}

