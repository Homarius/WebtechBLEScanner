using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using UIKit;
using WebtechProject;
using WebtechProject.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyCustomEntry), typeof(MyCustomEntryRenderer))]
namespace WebtechProject.iOS
{
	public class MyCustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UIKit.UITextBorderStyle.None;

			}
		}

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e != null && sender != null && e.PropertyName == "Text")
            {
                ((MyCustomEntry)sender).Text = Regex.Replace(((MyCustomEntry)sender).Text, "[^0-9]", "");
            }
            base.OnElementPropertyChanged(sender, e);
        }
    }
}

