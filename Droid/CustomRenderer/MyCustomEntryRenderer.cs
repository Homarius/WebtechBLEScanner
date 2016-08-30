using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using WebtechProject;
using WebtechProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomEntry), typeof(MyCustomEntryRenderer))]
namespace WebtechProject.Droid
{
	class MyCustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{

			}
		}

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e != null && sender != null && e.PropertyName == "Text")
            {
                ((MyCustomEntry)sender).Text = Regex.Replace(((MyCustomEntry)sender).Text, "[^0-9]", "");
            }
            base.OnElementPropertyChanged(sender, e);
        }
    }
}

