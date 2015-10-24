
// Experimental wall Jump+Crawl component for Motion2D.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/17 12:12 AM


using UnityEngine;


[RequireComponent(typeof(Motion2D))]
public class Motion2DWallJump : MonoBehaviour
{
	[Header("Config")]
	public float wallSnapGravity;

	[Header("Motion override")]
	public Vector2 gravityOnWall;
	public float forceLimitOnWall;

	private Motion2D motion;
	private Motion2DJump jump;


	void Start()
	{
		motion = GetComponent<Motion2D>();
		jump = GetComponent<Motion2DJump>();
	}


	void Update()
	{
		Vector2 nextGravity = gravityOnWall;

		// Modify gravity towards the wall (left, right)
		if (motion.wallsColliding.w == 1)
			nextGravity.x = wallSnapGravity * -1;

		if (motion.wallsColliding.y == 1)
			nextGravity.x = wallSnapGravity;


		// Left or right
		if (motion.wallsColliding.y == 1 || motion.wallsColliding.w == 1)
		{
			// Config overrides
			motion.gravityOverride = nextGravity;
			motion.forceLimit = forceLimitOnWall;
		}
		else
		{
			// Normal config
			motion.gravityOverride = Vector2.zero;
			motion.forceLimit = 0;
		}
	}
}
