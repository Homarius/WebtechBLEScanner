using System;
using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Custom control to dispay graph inside with a color gradient
    /// </summary>
	public class MyCustomGradientFrame : Frame
	{
		public Xamarin.Forms.Color StartColor { get; set;}
		public Xamarin.Forms.Color EndColor { get; set; }
	}
}

