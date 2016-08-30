using System;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using WebtechProject;
using WebtechProject.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyCustomGradientFrame), typeof(MyCustomGradientFrameRenderer))]
namespace WebtechProject.iOS
{
	public class MyCustomGradientFrameRenderer : FrameRenderer
	{
		private MyCustomGradientFrame frame;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				frame = e.NewElement as MyCustomGradientFrame;
				e.NewElement.SizeChanged += size_changed;
			}
		}

		void size_changed(object sender, EventArgs e)
		{
			var startColor = frame.StartColor.ToCGColor();
			var endColor = frame.EndColor.ToCGColor();
			var layer = this.Layer.Sublayers.FirstOrDefault();
			var gradient = new CAGradientLayer();
			gradient.Frame = layer.Bounds;
			gradient.CornerRadius = layer.CornerRadius = 20;
			gradient.Colors = new CGColor[] { startColor, endColor };
			this.Layer.InsertSublayer(gradient, 0);
		}
	}
}

