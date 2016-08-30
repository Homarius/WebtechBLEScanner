using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Custom converter for string formatting
    /// </summary>
    public class CreationDateConverter : IValueConverter
    {
        /// <summary>
        /// Returns a string with the localised string for CreationDate and the given DateTime value
        /// </summary>
        /// <param name="value">Date value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("{0}: {1}", AppResources.CreationDate, value.ToString());
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
            return value.ToString();
        }
    }
}
