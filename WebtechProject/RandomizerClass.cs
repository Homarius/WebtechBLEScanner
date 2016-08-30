using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebtechProject
{
    /// <summary>
    /// Provides a Random object for the whole app
    /// </summary>
    /// <remarks>It's best practice to provide one static Random object to avoid creating new ones</remarks>
    public static class RandomizerClass
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        public static Random rnd = new Random();
    }
}
