
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


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Update force values
			Vector2 jumpForce;
			jumpForce.x = force.x != 0 ? force.x : motion.force.x;
			jumpForce.y = force.y != 0 ? force.y : motion.force.y;
			// motion.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			// motion.movement = Vector2.zero;
			motion.force = jumpForce;


			this.tt("JumpAttackDecay")
			.ttReset()
			// .ttLoop(attack, (ttHandler t) =>
			// {
			// 	motion.force = Vector2.Lerp(motion.force, force, t.deltaTime);
			// })
			.ttLoop(decay, (ttHandler t) =>
			{
				motion.force = Vector2.Lerp(motion.force, Vector2.zero, t.deltaTime);
			});
		}
	}
}
