using CoreBluetooth;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace WebtechProject.iOS
{
	public class BluetoothManageriOS : CBCentralManagerDelegate
	{
		public CBPeripheral connectedPeripheral;
		public CBCentralManager cbCentralManager;
		public List<CBPeripheral> discoveredDevices;

		public BluetoothManageriOS()
		{
			cbCentralManager = new CBCentralManager();
			discoveredDevices = new List<CBPeripheral>();
		}

		public override void UpdatedState(CBCentralManager mgr)
		{
			if (mgr.State == CBCentralManagerState.PoweredOn)
			{
				//Passing in null scans for all peripherals. Peripherals can be targeted by using CBUIIDs
				CBUUID[] cbuuids = new CBUUID[0x1816]; //UUID for Speed and Cadence devices
				mgr.ScanForPeripherals(cbuuids); //Initiates async calls of DiscoveredPeripheral
												 //Timeout after 10 seconds
				var timer = new Timer(10 * 1000);
				timer.Elapsed += (sender, e) => mgr.StopScan();
			}
			else if (mgr.State == CBCentralManagerState.PoweredOff)
			{

			}
			else
			{
				//Invalid state -- Bluetooth powered down, unavailable, etc.
				System.Console.WriteLine("Bluetooth is not available");
			}
		}

		public override void DiscoveredPeripheral(CBCentralManager central, CBPeripheral peripheral, NSDictionary advertisementData, NSNumber RSSI)
		{
			discoveredDevices.Add(peripheral);
			//connectedPeripheral = peripheral;
			Console.WriteLine("Discovered {0}, data {1}, RSSI {2}", peripheral.Name, advertisementData, RSSI);
		}

		public bool bluetoothAvailable()
		{
			if (cbCentralManager != null && !(cbCentralManager.State == CBCentralManagerState.Unsupported))
			{
				return true;
			}
			else
				return false;
		}

		public void scanForDevices()
		{
			discoveredDevices = new List<CBPeripheral>();
			CBUUID[] cbuuids = new CBUUID[0x1816]; //UUID for Speed and Cadence devices
			cbCentralManager.ScanForPeripherals(cbuuids); //Initiates async calls of DiscoveredPeripheral
											 //Timeout after 10 seconds
			var timer = new Timer(10 * 1000);
			timer.Elapsed += (sender, e) => cbCentralManager.StopScan();
		}

		public void connectToDevice()
		{
			
		}

		public CBCentralManagerState returnBluetoothState()
		{
			if (cbCentralManager.State == CBCentralManagerState.PoweredOn)
				return CBCentralManagerState.PoweredOn;
			else
				return CBCentralManagerState.PoweredOff;
		}

		public bool bluetoothAcitvated()
		{
			if (cbCentralManager != null)
			{
				if (cbCentralManager.State == CBCentralManagerState.PoweredOn)
					return true;
				else
					return false;
			}
			else
				return false;
		}
	}
}
