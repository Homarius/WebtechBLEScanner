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

namespace WebtechProject.Droid
{
	public class MyBluetoothGattCallback : BluetoothGattCallback
	{
		public override void OnConnectionStateChange(BluetoothGatt gatt, [GeneratedEnum] GattStatus status, [GeneratedEnum] ProfileState newState)
		{
			switch (newState)
			{
				case ProfileState.Connected:
					Console.WriteLine("Connected peripheral: " + gatt.Device.Name);
					break;
				case ProfileState.Disconnected:
					Console.WriteLine("Disconnected peripheral: " + gatt.Device.Name);
					break;
				case ProfileState.Connecting:
					Console.WriteLine("Connecting peripheral: " + gatt.Device.Name);
					break;
				case ProfileState.Disconnecting:
					Console.WriteLine("Disconnecting peripheral: " + gatt.Device.Name);
					break;
			}
		}

		public override void OnServicesDiscovered(BluetoothGatt gatt, [GeneratedEnum] GattStatus status)
		{
			base.OnServicesDiscovered(gatt, status);
		}

		public override void OnCharacteristicWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, [GeneratedEnum] GattStatus status)
		{
			base.OnCharacteristicWrite(gatt, characteristic, status);
		}

		public override void OnCharacteristicRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, [GeneratedEnum] GattStatus status)
		{
			base.OnCharacteristicRead(gatt, characteristic, status);
		}
	}
}