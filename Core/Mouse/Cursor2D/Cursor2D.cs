﻿
// 2015/07/16 12:26:44 PM

// This is basically a mouse cursor with a look at rotation from an origin.


using UnityEngine;
using System.Collections;


public class Cursor2D : MonoBehaviour
{
	[Header("Config")]
	public float zLayer = -9;
	public bool rotateUponOrigin = false;

	[Header("Required")]
	public Transform origin;


	void Start()
	{
		Cursor.visible = false;
	}


	void Update()
	{
		Vector3 mousepos = MouseUtil.GetMousePosition();
		mousepos.z = -9;

		transform.position = mousepos;


		if (rotateUponOrigin)
		{
			Vector3 source = mousepos - origin.position;
			float angle = Mathf.Atan2(source.y, source.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}
