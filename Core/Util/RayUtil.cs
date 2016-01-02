
// Raycast util stuff.

// @matnesis 2015/12/31 06:12 PM


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class RayUtil
{
	public static Transform GetTransformAt(Vector3 origin, Vector3 direction, float length, LayerMask layer)
	{
		Transform t = null;

		RaycastHit rayHit;
		if (Physics.Raycast(origin, direction, out rayHit,  length, layer))
			return rayHit.transform;

		return null;
	}
}
