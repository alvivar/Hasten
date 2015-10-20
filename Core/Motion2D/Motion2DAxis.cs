
// Simple bind between Motion2D and Input to move.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 10:57 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion2D))]
public class Motion2DAxis : MonoBehaviour
{
	public bool active = true;
	public bool enableHorizontal = true;
	public bool enableVertical = true;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	void Update()
	{
		if (!active)
			return;

		float horiAxis = enableHorizontal ? Input.GetAxisRaw("Horizontal") : 0;
		float vertAxis = enableVertical ? Input.GetAxisRaw("Vertical") : 0;

		motion.direction = new Vector2(horiAxis, vertAxis);
	}
}
