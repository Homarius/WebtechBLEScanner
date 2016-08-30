using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebtechProject
{
    /// <summary>
    /// The interface for all bluetooth tasks
    /// </summary>
	public interface IBluetooth
	{
        /// <summary>
        /// Sets up bluetooth adapter
        /// </summary>
		void SetupBluetooth();
        /// <summary>
        /// Scans for BLE devices in the surrounding area
        /// </summary>
        /// <param name="scanDuration">The duration of the scan</param>
		void ScanForDevices(int scanDuration);
        /// <summary>
        /// Connects to a device
        /// </summary>
        /// <param name="deviceAddress">The bluetooth address of the device</param>
		void Connect(string deviceAddress);
        /// <summary>
        /// Acitvates the bluetooth adapter if it's disabled
        /// </summary>
		void Activate();
        /// <summary>
        /// Indicates if the bluetooth adapter is acitvated
        /// </summary>
        /// <returns>True if the adapter is activated, false otherwise</returns>
		bool IsAcitivated();
        /// <summary>
        /// Indicates if the device is capable of BLE funtions
        /// </summary>
        /// <returns>True if the device is a BLE device, false otherwise</returns>
		bool IsAvailable();
        /// <summary>
        /// A List of all devies found during the scan
        /// </summary>
        /// <returns>A list of the names of all discoverd BLE devices</returns>
		List<string> returnDiscoveredDevices();
	}
}

