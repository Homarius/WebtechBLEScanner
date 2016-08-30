using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Code behind of the AddMockupPage
    /// </summary>
	public partial class AddMockupPage : ContentPage
	{
        /// <summary>
        /// Initialisation of the AddMockupPage and subscribung to the MessagingCenter
        /// </summary>
        public AddMockupPage()
		{
			InitializeComponent();
            BindingContext = new AddMockupPageViewModel();

            //Hides the top back button if the app is running on an android device
            if(Device.OS == TargetPlatform.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            ApplicationContext.AddPointPage = this;

            MessagingCenter.Subscribe<AddMockupPage>(this, "NavigateBack", (sender) =>
            {
                try
                {
                    Navigation.PopAsync(); //Navigates back to the previous view
                }
                catch { }
            });
		}
	}
}

