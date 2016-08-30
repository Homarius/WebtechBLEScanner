using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WebtechProject.Droid
{
	[Activity(Label = "BLE Scan", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Initialize OxyPlot renderers
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();

            LoadApplication(new WebtechProject.App());
        }
	}
}

