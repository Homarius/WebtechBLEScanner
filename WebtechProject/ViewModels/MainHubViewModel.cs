using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace WebtechProject
{
    /// <summary>
    /// ViewModel for the MainHubView. Contains all neccessary information and logic
    /// </summary>
    public class MainHubViewModel : ViewModelBase
    {
        #region Global

        private IBluetooth _bluetoothManager;

        /// <summary>
        /// Gets or sets the platform specific bluetooth manager.
        /// </summary>
        /// <value>The platform specific bluetooth manager.</value>
        public IBluetooth BluetoothManager
        {
            get { return _bluetoothManager; }
            set { _bluetoothManager = value; }
        }

        private SensorDataDatabase _database;

        /// <summary>
        /// Database where Sensordata is stored
        /// </summary>
        /// <value>The database.</value>
        public SensorDataDatabase Database
        {
            get { return _database; }
            set { _database = value; }
        }


        #endregion

        #region Bluetooth
        private ICommand _scanForBLEDevicesCommand;

        /// <summary>
        /// Command responsible for starting the scan for BLE devices
        /// </summary>
        public ICommand ScanForBLEDevicesCommand
        {
            get { return _scanForBLEDevicesCommand; }
            set { _scanForBLEDevicesCommand = value; }
        }

        private List<string> _bluetoothDevicesAddresses;

        /// <summary>
        /// Stores a list of names of all found BLE Devices
        /// </summary>
        public List<string> BluetoothDevicesAddresses
        {
            get { return _bluetoothDevicesAddresses; }
            set { _bluetoothDevicesAddresses = value; OnPropertyChanged("BluetoothDevicesAddresses"); }
        }

        private int _indexSelectedDevice;

        /// <summary>
        /// The Index of the device which should be connected to. Neccessary for connecting
        /// </summary>
        public int IndexSelectedDevice
        {
            get { return _indexSelectedDevice; }
            set
            {
                _indexSelectedDevice = value;
                connectToBLEDevice();
            }
        }

        private bool _isScanning;

        /// <summary>
        /// Indicates whether the device is checking for BLE devies or not
        /// Is responsible for showing/hiding UI elements
        /// </summary>
        public bool IsScanning
        {
            get { return _isScanning; }
            set { _isScanning = value; OnPropertyChanged("IsScanning"); }
        }

        #endregion

        #region Visualisation

        private ICommand _updatePlotsCommand;

        /// <summary>
        /// Command for clearing the database
        /// </summary>
        public ICommand UpdatePlotsCommand
        {
            get { return _updatePlotsCommand; }
            set { _updatePlotsCommand = value; }
        }

        private double _speedAverage;

        /// <summary>
        /// Gets or sets the speed average for the selected time span
        /// </summary>
        /// <value>The speed average.</value>
        public double SpeedAverage
        {
            get { return _speedAverage; }
            set { _speedAverage = value; }
        }

        private double _cadenceAverage;

        /// <summary>
        /// Gets or sets the cadence average for the selected time span
        /// </summary>
        /// <value>The cadence average.</value>
        public double CadenceAverage
        {
            get { return _cadenceAverage; }
            set { _cadenceAverage = value; }
        }

        private bool _newDataAvailable = false;

        /// <summary>
        /// Indicates if new points are availabe for plotting
        /// </summary>
        public bool NewDataAvailable
        {
            get { return _newDataAvailable; }
            set { _newDataAvailable = value; }
        }

        private PlotModel _speedModel;

        /// <summary>
        /// Stores the PlotModel for the speed graph
        /// </summary>
        public PlotModel SpeedModel
        {
            get { return _speedModel; }
            set { _speedModel = value; }
        }

        private PlotModel _cadenceModel;

        /// <summary>
        /// Stores the PlotModel for the cadence graph
        /// </summary>
        public PlotModel CadenceModel
        {
            get { return _cadenceModel; }
            set { _cadenceModel = value; }
        }

        private ObservableCollection<SensorData> _speedAndCadenceData;

        /// <summary>
        /// Stores all points corresponding to the selected time span
        /// </summary>
		public ObservableCollection<SensorData> SpeedAndCadenceData
        {
            get { return _speedAndCadenceData; }
            set { _speedAndCadenceData = value; }
        }

        private ObservableCollection<SensorData> _backupCollection;

        /// <summary>
        /// Backup of the List to comapre and check for differences
        /// </summary>
		public ObservableCollection<SensorData> BackupCollection
        {
            get { return _backupCollection; }
            set { _backupCollection = value; }
        }

        #endregion

        #region Settings

        private ICommand _clearDatabaseCommand;

        /// <summary>
        /// Command for clearing the database
        /// </summary>
        public ICommand ClearDatabaseCommand
        {
            get { return _clearDatabaseCommand; }
            set { _clearDatabaseCommand = value; }
        }

        private int _scanDuration = 6000; //default value;

        /// <summary>
        /// Gets or sets the duration of the scan.
        /// </summary>
        /// <value>The duration of the scan.</value>
        public int ScanDuration
        {
            get { return _scanDuration; }
            set { _scanDuration = value; }
        }

        private int _indexSelectedTimeSpan = 0;

        /// <summary>
        /// The index of the picker item indicating the time span items will be evaluated for 
        /// </summary>
        /// <value>The index selected time span.</value>
        public int IndexSelectedTimeSpan
        {
            get { return _indexSelectedTimeSpan; }
            set
            {
                _indexSelectedTimeSpan = value;
                SpeedAndCadenceData = loadCorrespondingPoints();
            }
        }

        #endregion

        #region Functions
        //MockupData data = new MockupData();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebtechProject.MainHubViewModel"/> class.
        /// Sets up most important objects
        /// </summary>
        public MainHubViewModel()
        { 
            ScanForBLEDevicesCommand = new Command(searchForBLEDevices);
            ClearDatabaseCommand = new Command(clearDatabase);
            UpdatePlotsCommand = new Command(update);
            BluetoothManager = Xamarin.Forms.DependencyService.Get<IBluetooth>();
            Database = new SensorDataDatabase();

            SpeedAndCadenceData = new ObservableCollection<SensorData>(Database.GetItems(DateTime.Now.AddDays(-1), DateTime.Now).OrderBy(x => x.CreationDate));

            SpeedModel = CreatePlotModel(SpeedAndCadenceData, PlotTypeEnum.Speed);
            CadenceModel = CreatePlotModel(SpeedAndCadenceData, PlotTypeEnum.Cadence);

            if (SpeedAndCadenceData.Count() > 0)
            {
                SpeedAverage = Math.Round(SpeedAndCadenceData.Select(x => x.SpeedValue).Average(), 2);
                CadenceAverage = Math.Round(SpeedAndCadenceData.Select(x => x.CadenceValue).Average(), 2);
            }
            else
            {
                SpeedAverage = 0;
                CadenceAverage = 0;
            }

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), checkForUpdates);
        }

        /// <summary>
        /// Loads the current data and updates the UI
        /// </summary>
        private void update()
        {
            SpeedAndCadenceData = loadCorrespondingPoints();
        }

        /// <summary>
        /// Checks for updates each second
        /// </summary>
        /// <returns>Always true to keep timer running</returns>
        private bool checkForUpdates()
        {
            BackupCollection = loadCorrespondingPoints();
            if (!BackupCollection.ToList().SequenceEqual(SpeedAndCadenceData.ToList()))
            {
                NewDataAvailable = true;
            }
            else
            {
                NewDataAvailable = false;
            }
            return true;
        }

        /// <summary>
        /// Loads all the points for the selected timespan
        /// </summary>
        private ObservableCollection<SensorData> loadCorrespondingPoints()
        {
            if (IndexSelectedTimeSpan == 0)
            {
                return new ObservableCollection<SensorData>(Database.GetItems(DateTime.Now.AddDays(-1), DateTime.Now).OrderBy(x => x.CreationDate));
            }
            else if (IndexSelectedTimeSpan == 1)
            {
                return new ObservableCollection<SensorData>(Database.GetItems(DateTime.Now.AddDays(-7), DateTime.Now).OrderBy(x => x.CreationDate));
            }
            else if (IndexSelectedTimeSpan == 2)
            {
                return new ObservableCollection<SensorData>(Database.GetItems(DateTime.Now.AddMonths(-1), DateTime.Now).OrderBy(x => x.CreationDate));
            }
            else
                return null;
        }

        /// <summary>
        /// Starts to popup confirm dialog
        /// </summary>
        private void clearDatabase()
        {
            MessagingCenter.Send(ApplicationContext.MainPageHub, "ClearDatabase");
        }

        /// <summary>
        /// Starts the search for devices
        /// </summary>
        private void searchForBLEDevices()
        {
            BluetoothDevicesAddresses = new List<string>();
            if (BluetoothManager != null)
            {
                BluetoothManager.SetupBluetooth();
                if (BluetoothManager.IsAvailable())
                {
                    if (BluetoothManager.IsAcitivated())
                    {
                        IsScanning = true;
                        Task.Factory.StartNew(() =>
                        {
                            BluetoothManager.ScanForDevices(ScanDuration);
                            BluetoothDevicesAddresses = BluetoothManager.returnDiscoveredDevices();
                            if (BluetoothDevicesAddresses.Count() == 0)
                            {
                                MessagingCenter.Send(ApplicationContext.MainPageHub, "NoDevicesFound");
                                List<string> tmp = new List<string>() { "Device1", "Device2", "Device3" };
                                BluetoothDevicesAddresses = tmp;
                                IsScanning = false;
                            }
                        });
                    }
                    else if (Device.OS == TargetPlatform.Android)
                        MessagingCenter.Send(ApplicationContext.MainPageHub, "BluetoothOff");
                    else
                        MessagingCenter.Send(ApplicationContext.MainPageHub, "iOSBluetoothDisabled");
                }
                else
                    MessagingCenter.Send(ApplicationContext.MainPageHub, "BluetoothError");
            }
            else
                MessagingCenter.Send(ApplicationContext.MainPageHub, "BluetoothError");
        }

        /// <summary>
        /// Creates the plotmodel for the corresponding plotType
        /// </summary>
        /// <param name="points">Points which will be displayed</param>
        /// <param name="plotType">Indicates which plot should be created</param>
        /// <returns></returns>
        private PlotModel CreatePlotModel(IEnumerable<SensorData> points, PlotTypeEnum plotType)
        {

            var plotModel = new PlotModel()
            {
                PlotAreaBorderColor = OxyColors.White
            };

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
                TextColor = OxyColors.White
            });
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                AxislineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
                TextColor = OxyColors.White,
            });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Color = OxyColors.White;

            if (points != null)
            {
                if (plotType == PlotTypeEnum.Speed)
                {
                    foreach (var point in points)
                    {
                        series1.Points.Add(DateTimeAxis.CreateDataPoint(point.CreationDate, point.SpeedValue));
                    }
                }
                else if (plotType == PlotTypeEnum.Cadence)
                {
                    foreach (var point in points)
                    {
                        series1.Points.Add(DateTimeAxis.CreateDataPoint(point.CreationDate, point.CadenceValue));
                    }
                }
            }

            plotModel.Series.Add(series1);

            return plotModel;
        }

        private void compareCollection()
        {
            if(BackupCollection != SpeedAndCadenceData)
            {
                NewDataAvailable = true;
            }
        }

        /// <summary>
        /// Activates the bluetooth adapter if it is disabled
        /// </summary>
        public async Task turnOnBluetooth()
        {
            await Task.Run(() => BluetoothManager.Activate());
        }

        /// <summary>
        /// Connects to the device selected by the user
        /// </summary>
        private void connectToBLEDevice()
        {
            if (Device.OS == TargetPlatform.Android)
                BluetoothManager.Connect(BluetoothDevicesAddresses.ElementAt(IndexSelectedDevice));
        }

        #endregion
    }
}
