
// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/14 12:15:12 AM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion2D))]
public class Motion2DJump : MonoBehaviour
{
	public Vector2 force;
	public float decay;

	private Motion2D motion;
	private Rigidbody2D rbody;


	void Start()
	{
		motion = GetComponent<Motion2D>();
		rbody = GetComponent<Rigidbody2D>();
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector2 jumpForce = Vector2.zero;
			jumpForce.x = force.x != 0 ? force.x : motion.force.x;
			jumpForce.y = force.y != 0 ? force.y : motion.force.y;

			motion.force = jumpForce;


			// if (force.x != 0)
			// 	rbody.velocity = new Vector2(rbody.velocity.x, 0);

			// if (force.y != 0)
			// 	rbody.velocity = new Vector2(0, rbody.velocity.y);


			this.tt("JumpDecay").ttReset().ttLoop(decay, (ttHandler t) =>
			{
				motion.force = Vector2.Lerp(motion.force, Vector2.zero, t.deltaTime);
			});
		}
	}
}
