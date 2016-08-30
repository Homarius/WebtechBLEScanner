using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Custom converter to negate bool values which will be used for visibility binding
    /// </summary>
	public class VisibilityParamConverter : IValueConverter
	{
		/// <summary>
		/// Converts a bool value according to the given param
		/// </summary>
		/// <param name="value">The boolean value binded to</param>
		/// <param name="targetType"></param>
		/// <param name="parameter">Parameter 0 or 1, indicates if value should be negated</param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string param = "0";
			bool val = (bool)value;
			if (parameter != null)
				param = parameter.ToString();
			if (param == "0")
				return val;
			else
				return !val;
		}

        /// <summary>
        /// Auto created
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value;
		}
	}
}
