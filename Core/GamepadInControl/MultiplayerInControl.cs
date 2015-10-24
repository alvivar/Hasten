
// @matnesis
// 2015/10/23 11:44 PM


using UnityEngine;
using System.Collections.Generic;
using matnesis.TeaTime;
using InControl;


public class MultiplayerInControl : MonoBehaviour
{
	public GamepadInControl[] players = null; // Players list
	public int deviceCount = 0; // Current controls connected


	void Start()
	{
		// When a new usb device is detected, the controls are reassigned
		this.tt("RefreshDevices").Add(1, () =>
		{
			if (InputManager.Devices.Count != deviceCount)
			{
				deviceCount = InputManager.Devices.Count;
				AssignDevicesToPlayers();
			}
		})
		.Repeat();
	}


	void AssignDevicesToPlayers()
	{
		for (int i = 0; i < players.Length; i++)
		{
			if (i >= InputManager.Devices.Count)
				break;

			players[i].SetInputDevice(InputManager.Devices[i], i);
		}
	}
}
