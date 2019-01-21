// The simplest laser between two points.

// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/04/15 11:45 am

using UnityEngine;

public class LaserShooter : MonoBehaviour
{
	[Header("Required")]
	public Damage damage;
	public LineRenderer line;

	public void On(Vector3 origin, Vector3 destiny)
	{
		line.SetPositions(new Vector3[] { origin, destiny });
	}

	public void Off()
	{
		line.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
	}
}