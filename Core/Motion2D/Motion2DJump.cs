
// Configurable jump for Motion2D.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/14 12:15 AM


using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[RequireComponent(typeof(Motion2D))]
public class Motion2DJump : MonoBehaviour
{
	[Header("Config")]
	public Vector2 force; // 0 is neutral
	public Vector2 forceOverride; // Overrides ^
	public float decay; // How fast becames 0 after jump

	[Header("Limits")]
	public int maxGroundJumps = 1;
	public int maxAirJumps = 0;

	[Header("Input")]
	public KeyCode jumpKey = KeyCode.None;

	private int currentGroundJumps = 0;
	private int currentAirJumps = 0;

	private Motion2D motion;
	private Rigidbody2D rbody;

	// tt
	private TeaTime jumpDecay;


	void Start()
	{
		motion = GetComponent<Motion2D>();
		rbody = GetComponent<Rigidbody2D>();

		jumpDecay = this.tt();
	}


	void Update()
	{
		if (jumpKey != KeyCode.None && Input.GetKeyDown(KeyCode.Space))
		{
			// Only jumps if touching the ground
			if (motion.wallsColliding.SqrMagnitude() != 0)
				DoJump(force);
		}


		// Reset the ground jumps
		if (motion.wallsColliding.SqrMagnitude() != 0)
			currentGroundJumps = 0;
	}


	public void DoJump(Vector2 force)
	{
		// Count up
		currentGroundJumps += 1;


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


		// Jump decay
		jumpDecay.Reset().Loop(decay, (ttHandler t) =>
		{
			motion.force = Vector2.Lerp(motion.force, Vector2.zero, t.deltaTime);
		});
	}
}
