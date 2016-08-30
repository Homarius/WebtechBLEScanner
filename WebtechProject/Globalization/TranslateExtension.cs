using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebtechProject
{
    /// <summary>
    /// An esxtension to be able to localize the application
    /// </summary>
	[ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		readonly CultureInfo ci;
		const string ResourceId = "WebtechProject.AppResources";

        /// <summary>
        /// Gets called on start, gather current culture information
        /// </summary>
		public TranslateExtension()
		{
			ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
		}

        /// <summary>
        /// The text which will be translated
        /// </summary>
		public string Text { get; set; }

        /// <summary>
        /// Checks for the correlate translation in the resource file for the language currently used
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Text == null)
				return "";

			ResourceManager resmgr = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

			var translation = resmgr.GetString(Text, ci);

			if (translation == null)
			{
#if DEBUG
				throw new ArgumentException(
					String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
					"Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
			}
			return translation;
		}
	}
}

