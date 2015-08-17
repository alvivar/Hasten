
// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/14 12:15:12 AM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion2D))]
public class Motion2DJump : MonoBehaviour
{
	public Vector2 force; // 0 is neutral
	public Vector2 forceOverride; // Overrides ^
	public float decay; // How fast becames 0 after jump

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
			DoJump(force);
		}
	}


	public void DoJump(Vector2 force)
	{
		// 0 is neutral as input
		Vector2 jumpForce = Vector2.zero;
		jumpForce.x = force.x != 0 ? force.x : motion.force.x;
		jumpForce.y = force.y != 0 ? force.y : motion.force.y;


		// Override
		if (forceOverride != Vector2.zero)
		{
			jumpForce.x = forceOverride.x != 0 ? forceOverride.x : motion.force.x;
			jumpForce.y = forceOverride.y != 0 ? forceOverride.y : motion.force.y;
		}


		// Jump representation
		motion.force = jumpForce;


		this.tt("JumpDecay").ttReset().ttLoop(decay, (ttHandler t) =>
		{
			motion.force = Vector2.Lerp(motion.force, Vector2.zero, t.deltaTime);
		});
	}
}
