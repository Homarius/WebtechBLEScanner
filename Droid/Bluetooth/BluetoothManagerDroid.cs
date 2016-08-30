using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;
using System.Threading.Tasks;
using System.Threading;
using Android.Bluetooth.LE;
using Java.Util;

namespace WebtechProject.Droid
{

	//UUID for Speed and Cadence "0x1816"
	public class BluetoothManagerDroid : ScanCallback
	{
		private BluetoothManager bluetoothManager;
		private BluetoothLeScanner bluetoothLeScanner;
		private MyBluetoothGattCallback bluetoothGattCallback;
		public BluetoothAdapter bluetoothAdapter { get; private set; }
		public List<BluetoothDevice> bluetoothDevices { get; private set; }

		public BluetoothDevice bondedDevice { get; set; }

		public IntPtr Handle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public BluetoothManagerDroid()
		{
			bluetoothManager = (BluetoothManager)Application.Context.GetSystemService("bluetooth");
			bluetoothAdapter = bluetoothManager.Adapter;
			if (bluetoothAdapter != null)
			{
				bluetoothLeScanner = bluetoothAdapter.BluetoothLeScanner;
			}
		}

		public void scanForBLEDevices(int scanDuration)
		{
			if (bluetoothAdapter != null)
			{
				//UUID uuid = UUID.FromString("00001801-0000-1000-8000-00805F9B34FB"); //UUID for GATT
				//UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");

				bluetoothDevices = new List<BluetoothDevice>(); //setting up list for availabe devices
				bluetoothLeScanner.StartScan(this);
				Console.WriteLine("Scan started");
				Thread.Sleep(scanDuration);
				bluetoothLeScanner.StopScan(this);
				Console.WriteLine("Scan stopped");
			}
		}

		public State bluetoothState()
		{
			if (bluetoothAdapter != null && bluetoothAdapter.IsEnabled)
			{
				return State.On;
			}
			else
			{
				return State.Off;
			}
		}

		public bool bluetoothAvailable()
		{
			if (bluetoothAdapter != null)
				return true;
			else
				return false;
		}

		public void Reset()
		{
			bluetoothDevices = new List<BluetoothDevice>();
			bondedDevice = null;
		}

		public void ConnectToDevice(string deviceAddress)
		{
			if (deviceAddress != null && bluetoothDevices != null && bluetoothDevices.Where(x => x.Address == deviceAddress).Count() == 1)
			{
				bluetoothDevices.Single(x => x.Address == deviceAddress).ConnectGatt(Application.Context, false, bluetoothGattCallback);
				bondedDevice = bluetoothDevices.Single(x => x.Address == deviceAddress);
			}
		}

		public override void OnScanResult([GeneratedEnum] ScanCallbackType callbackType, ScanResult result)
		{
			if (!string.IsNullOrEmpty(result.Device.Address))
			{
				if (bluetoothDevices.Where(x => x.Address == result.Device.Address).Count() == 0) //check if the device is already discovered
				{
					bluetoothDevices.Add(result.Device);
					Console.WriteLine(result.Device.Address);
				}
			}
			else
			{
				Console.WriteLine("Null");
			}
			//base.OnScanResult(callbackType, result);
		}
	}
}