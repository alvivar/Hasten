
using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class RigidBullet : MonoBehaviour
{
	public Transform target;
	public float force;

	private Rigidbody2D body;



	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		body.gravityScale = 0;
		body.interpolation = RigidbodyInterpolation2D.Interpolate;
	}


	void Update()
	{
		if (force > 0)
		{
			Vector3 targetDir = (target.position - transform.position).normalized;
			body.AddForce(targetDir * force);

			this.tt("VelocityRefresh").ttAdd(() =>
			{
				body.velocity = target.GetComponent<Rigidbody2D>().velocity;
			})
			.ttAdd(1).ttWait();
		}
	}
}
