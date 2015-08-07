
// 2015/08/06 11:20:24 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion))]
public class WalkJump : MonoBehaviour
{
	private Motion motion;


	void Start()
	{
		motion = GetComponent<Motion>();
		motion.OnJump += OnJumpHandler;
	}


	void Update()
	{

	}


	void OnJumpHandler()
	{
		// Ignore if grounded
		if (motion.wallCollision.z != 0)
			return;


		if (motion.wallCollision.w != 0 || motion.wallCollision.y != 0)
		{
			motion.jumpCount = 0;
		}


		// Left wall
		Vector2 wallJump = Vector2.zero;
		if (motion.wallCollision.w != 0)
		{
			wallJump = (motion.jumpForce + new Vector2(motion.jumpForce.y * 0.60f, motion.jumpForce.y * 1.20f)) * 0.5f;

			motion.Reset();
			motion.jumpForce = wallJump;
			motion.GetComponent<Rigidbody2D>().velocity = wallJump;
			// motion.jumpForce = Vector2.ClampMagnitude(wallJump, motion.jumpForce.y);
			// motion.jumpForce.y *= 1.30f;

			InertiaCleanUp();
		}


		// Right wall
		if (motion.wallCollision.y != 0)
		{
			wallJump = (motion.jumpForce + new Vector2(-motion.jumpForce.y * 0.60f, motion.jumpForce.y * 1.20f)) * 0.5f;

			motion.Reset();
			motion.jumpForce = wallJump;
			motion.GetComponent<Rigidbody2D>().velocity = wallJump;
			// motion.jumpForce = Vector2.ClampMagnitude(wallJump, motion.jumpForce.y);
			// motion.jumpForce.y *= 1.30f;

			InertiaCleanUp();
		}
	}


	void InertiaCleanUp()
	{
		this.tt("InertiaCleanUp").ttReset().ttLoop(0.30f, (ttHandler t) =>
		{

		});
	}
}
