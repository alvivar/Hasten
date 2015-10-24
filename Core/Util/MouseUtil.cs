﻿
// Mouse stuff.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/10/19 04:52 PM


using UnityEngine;
using System.Collections;


public class MouseUtil
{
	public static Vector3 GetMousePosition()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}