﻿using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebtechProject.Droid.Localize))]
namespace WebtechProject.Droid
{
	public class Localize : ILocalize
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}

