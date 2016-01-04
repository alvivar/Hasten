
// Raycast util stuff.

// @matnesis 2015/12/31 06:12 PM


using UnityEngine;


public static class RayUtil
{
	public static RaycastHit Hit(Vector3 origin, Vector3 direction, float rayLength, LayerMask layer)
	{
		RaycastHit rayHit;
		Physics.Raycast(origin, direction, out rayHit,  rayLength, layer);

		return rayHit;
	}
}
