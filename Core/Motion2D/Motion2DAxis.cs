
// Simple axis control for Motion2D.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 10:57 PM


using UnityEngine;


[RequireComponent(typeof(Motion2D))]
public class Motion2DAxis : MonoBehaviour
{
	[Header("Options")]
	public bool update = true;
	public bool enableHorizontal = true;
	public bool enableVertical = true;

	[Header("Input")]
	public float horizontalAxis = 0;
	public float verticalAxis = 0;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	void Update()
	{
		if (!update)
			return;

		float horiAxis = enableHorizontal ? horizontalAxis : 0;
		float vertAxis = enableVertical ? verticalAxis : 0;

		motion.direction = new Vector2(horiAxis, vertAxis);
	}
}
