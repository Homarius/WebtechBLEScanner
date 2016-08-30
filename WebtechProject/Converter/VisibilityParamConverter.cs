using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WebtechProject
{
	public class VisibilityParamConverter : IValueConverter
	{
		/// <summary>
		/// 
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

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value;
		}
	}
}
