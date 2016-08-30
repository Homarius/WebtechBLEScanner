using System;
using UIKit;
using WebtechProject;
using WebtechProject.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyCustomPicker), typeof(MyCustomPickerRenderer))]
namespace WebtechProject.iOS
{
	public class MyCustomPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.TextColor = UIColor.Black;
				Control.TextAlignment = UITextAlignment.Right;
			}
		}
	}
}

