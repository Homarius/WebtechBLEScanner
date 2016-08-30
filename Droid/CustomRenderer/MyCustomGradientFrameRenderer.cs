using System;
using Android.Graphics.Drawables;
using WebtechProject;
using WebtechProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomGradientFrame), typeof(MyCustomGradientFrameRenderer))]
namespace WebtechProject.Droid
{
	public class MyCustomGradientFrameRenderer : FrameRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var frame = e.NewElement as MyCustomGradientFrame;
				var startColor = frame.StartColor.ToAndroid();
				var	endColor = frame.EndColor.ToAndroid();
				var colors = new int[] { startColor, endColor };
				Background = new GradientDrawable(GradientDrawable.Orientation.TopBottom, colors);
			}
		}
	}
}

