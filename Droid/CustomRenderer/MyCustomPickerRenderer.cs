using System;
using WebtechProject;
using WebtechProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomPicker), typeof(MyCustomPickerRenderer))]
namespace WebtechProject.Droid
{
	class MyCustomPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SetTextColor(global::Android.Graphics.Color.Black); //Textcolor
				Control.Gravity = Android.Views.GravityFlags.End; //Textalignment
			}
		}
	}
}

