using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using OxyPlot.Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using WebtechProject.iOS;
using WebtechProject;

[assembly: ExportRenderer(typeof(MyCustomPlotView), typeof(MyCustomPlotViewRenderer))]
namespace WebtechProject.iOS
{
    public class MyCustomPlotViewRenderer : OxyPlot.Xamarin.Forms.Platform.iOS.PlotViewRenderer
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
