using System;
using System.Collections.Generic;
using WebtechProject.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(BluetoothImplementation))]
namespace WebtechProject.iOS
{
	public class BluetoothImplementation : IBluetooth
	{
		BluetoothManageriOS bluetoothManageriOS;

		public void Activate()
		{
			throw new NotImplementedException();
		}

		public void Connect(string deviceAddress)
		{
			throw new NotImplementedException();
		}

		public bool IsAcitivated()
		{
			return bluetoothManageriOS.bluetoothAcitvated();
			//throw new NotImplementedException();
		}

		public bool IsAvailable()
		{
			return bluetoothManageriOS.bluetoothAvailable();
			//throw new NotImplementedException();
		}

		public List<string> returnDiscoveredDevices()
		{
			throw new NotImplementedException();
		}

		public void ScanForDevices(int scanDuration)
		{
			throw new NotImplementedException();
		}

		public void SetupBluetooth()
		{
			bluetoothManageriOS = new BluetoothManageriOS();
		}
	}
}

