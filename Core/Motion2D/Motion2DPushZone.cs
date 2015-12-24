
// Push away triggering Motions.

// @matnesis
// 2015/12/12 09:22 PM


using UnityEngine;
using System.Collections;


public class Motion2DPushZone : MonoBehaviour
{
	public float force = 5f;
	private Collider2D collidr;


	void Start()
	{
		collidr = GetComponent<Collider2D>();
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other)
		{
			Vector3 againstForce = other.transform.position - collidr.bounds.center;
			againstForce.z = 0;
			againstForce = againstForce.normalized;

			other.GetComponent<Rigidbody2D>().AddForce(againstForce * force);
		}
	}
}
