using System;
using System.Globalization;

namespace WebtechProject
{
    /// <summary>
    /// Interface for localization
    /// </summary>
	public interface ILocalize
	{
        /// <summary>
        /// The current culture the application is used in
        /// </summary>
        /// <returns>CultureInfo</returns>
		CultureInfo GetCurrentCultureInfo();
	}
}

