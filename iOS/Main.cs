﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace WebtechProject.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{

            OxyPlot.Xamarin.Forms.Platform.iOS.PlotViewRenderer.Init();
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
		}
	}
}

