
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
	public float deadZone = 0.3f; // Ignore values less than the dead zone

	[Header("Input")]
	public bool enableSimpleInput = true; // Basically Input.GetAxisRaw
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


		// Input.GetAxisRaw
		if (enableSimpleInput)
		{
			horiAxis = Input.GetAxisRaw("Horizontal");
			vertAxis = Input.GetAxisRaw("Vertical");
		}


		motion.direction = new Vector2(
		    Mathf.Abs(horiAxis) > deadZone ? horiAxis : 0,
		    Mathf.Abs(vertAxis) > deadZone ? vertAxis : 0);
	}
}
