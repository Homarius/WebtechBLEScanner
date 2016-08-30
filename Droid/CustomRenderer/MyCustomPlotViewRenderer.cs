using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OxyPlot.Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WebtechProject;
using Xamarin.Forms;
using WebtechProject.Droid;

[assembly: ExportRenderer(typeof(MyCustomPlotView), typeof(MyCustomPlotViewRenderer))]
namespace WebtechProject.Droid
{
    public class MyCustomPlotViewRenderer : OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PlotView> e)
        {
            base.OnElementChanged(e);
            this.Control.InvalidatePlot(false);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            this.Control.InvalidatePlot(false);
        }
    }
}