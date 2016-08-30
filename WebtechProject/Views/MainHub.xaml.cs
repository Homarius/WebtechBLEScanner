using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Xamarin.Forms;

namespace WebtechProject
{
    /// <summary>
    /// Code behind of the MainHub
    /// </summary>
	public partial class MainHub : TabbedPage
	{
		private MainHubViewModel mainHubViewModel;

        /// <summary>
        /// Initialisation of the MainHub and subscribung to the MessagingCenter
        /// </summary>
		public MainHub()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            mainHubViewModel = new MainHubViewModel();
			BindingContext = mainHubViewModel;

            //workaround for setting resource strings as picker items (!Breaks the mvvm pattern)
            customPicker.Items.Add(AppResources.LastDay);
            customPicker.Items.Add(AppResources.LastWeek);
            customPicker.Items.Add(AppResources.LastMonth);
            customPicker.SelectedIndex = 0;

            ApplicationContext.MainPage = mainHubViewModel;
			ApplicationContext.MainPageHub = this;

			mainHubViewModel.PropertyChanged += mainHubViewModel_PropertyChangedEventRaised;

            #region MessagingCenter

            MessagingCenter.Subscribe<MainHub>(this, "BluetoothError", (sender) =>
			{
				DisplayAlert("Bluetooth Error", AppResources.BLEUnsupported, AppResources.Accept);
			});

			MessagingCenter.Subscribe<MainHub>(this, "BluetoothOff", async (sender) =>
			{
				var result = await DisplayAlert("Bluetooth Error", "Bluetooth must be turned on to use Bluetooth features!", "Enable Bluetooth", AppResources.Cancel);
				if (result)
				{
					await mainHubViewModel.turnOnBluetooth();
				}
			});

			MessagingCenter.Subscribe<MainHub>(this, "iOSBluetoothDisabled", (sender) =>
			{
				DisplayAlert("Bluetooth disabled", AppResources.iOSBluetoothOff, AppResources.Ok);
			});

			MessagingCenter.Subscribe<MainHub>(this, "NoDevicesFound", (sender) =>
			{
				Device.BeginInvokeOnMainThread(() =>
											   DisplayAlert("Info", "No Bluetooth devices found!", AppResources.Ok));
			});

            MessagingCenter.Subscribe<MainHub>(this, "ClearDatabase", async (sender) =>
            {
                var result = await DisplayAlert(AppResources.Warning, AppResources.DatabaseWarning, AppResources.Delete, AppResources.Cancel);
                if(result)
                {
                    int deletedItems = App.Database.ClearDatabase();
                    if(deletedItems == 1)
                    {
                        await DisplayAlert(AppResources.Info, AppResources.OneDeletedItem, AppResources.Ok);
                    }
                    else if(deletedItems != 0)
                    {
                        await DisplayAlert(AppResources.Info, String.Format(AppResources.NumberDeletedItems, deletedItems), AppResources.Ok);
                    }                  
                }
            });

            MessagingCenter.Subscribe<MainHub>(this, "NavigateTask", (sender) =>
            {
                Navigation.PushAsync(new AddMockupPage(), true);
            });

            MessagingCenter.Subscribe<MainHub>(this, "CreatePoints", (sender) =>
            {
                List<SensorData> tmpList = MockupData.CreateRandomDataPointList(30);
                foreach(var point in tmpList)
                {
                    App.Database.SaveItem(point);
                }
            });

            #endregion
        }

        private void mainHubViewModel_PropertyChangedEventRaised(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "BluetoothDevicesAddresses")
			{
                DeviceSelector.Items.Clear(); //clears the selectionlist to avoid double entries
                foreach (var d in ((MainHubViewModel)sender).BluetoothDevicesAddresses)
                {
                    DeviceSelector.Items.Add(d);
                }
                DeviceSelector.SelectedIndex = 0;
            }
			else if (e.PropertyName == "IsScanning")
			{
				StartScanButton.IsVisible = ((MainHubViewModel)sender).IsScanning;
				ScanningIndicator.IsVisible = !((MainHubViewModel)sender).IsScanning;
			}
		}
	}
}
