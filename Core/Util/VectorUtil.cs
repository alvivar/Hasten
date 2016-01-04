
// Useful vector stuff.

// @matnesis 2016/01/01 11:36 PM


using UnityEngine;


public static class VectorUtil
{
	/// <summary>
	/// Returns a Vector3 only with the strongest direction at 1.
	/// </summary>
	public static Vector3 RawDirection(Vector3 from, Vector3 to)
	{
		Vector3 direction = (to - from).normalized;

		direction.x = Mathf.Abs(direction.x) > Mathf.Abs(direction.y) ? direction.x : 0;
		direction.x = Mathf.Abs(direction.x) > Mathf.Abs(direction.z) ? direction.x : 0;

		direction.y = Mathf.Abs(direction.y) > Mathf.Abs(direction.x) ? direction.y : 0;
		direction.y = Mathf.Abs(direction.y) > Mathf.Abs(direction.z) ? direction.y : 0;

		direction.z = Mathf.Abs(direction.z) > Mathf.Abs(direction.y) ? direction.z : 0;
		direction.z = Mathf.Abs(direction.z) > Mathf.Abs(direction.x) ? direction.z : 0;

		return (direction * 10).normalized;
	}
}
