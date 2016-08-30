using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Runtime;
using Java.Lang;
using Java.Util;
using WebtechProject.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(BluetoothImplementation))]
namespace WebtechProject.Droid
{
	public class BluetoothImplementation : IBluetooth
	{
		BluetoothManagerDroid bluetoothManagerDroid;

		public void SetupBluetooth()
		{
			bluetoothManagerDroid = new BluetoothManagerDroid();
		}

		public void ScanForDevices(int scanDuration)
		{
			if (bluetoothManagerDroid != null)
			{
				bluetoothManagerDroid.scanForBLEDevices(scanDuration);
			}
		}

		public void Connect(string deviceAddress)
		{
			if (bluetoothManagerDroid != null)
			{
				bluetoothManagerDroid.ConnectToDevice(deviceAddress);
			}
		}

		public void Activate()
		{
			bluetoothManagerDroid.bluetoothAdapter.Enable();
		}

		public List<string> returnDiscoveredDevices()
		{
			if (bluetoothManagerDroid.bluetoothDevices != null)
				return bluetoothManagerDroid.bluetoothDevices.Select(x => x.Address).ToList();
			else
				return null;
		}

		public bool IsAcitivated()
		{
			if (bluetoothManagerDroid.bluetoothState() == State.On)
				return true;
			else
				return false;
		}

		public bool IsAvailable()
		{
			return bluetoothManagerDroid.bluetoothAvailable();
		}
	}
}

