
// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 10:57:05 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion2D))]
public class Motion2DInput : MonoBehaviour
{
	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	void Update()
	{
		motion.direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		// // Up
		// if (Input.GetKeyDown(KeyCode.W))
		// 	motion.direction.y = 1;

		// if (Input.GetKeyUp(KeyCode.W))
		// 	motion.direction.y = 0;


		// // Left
		// if (Input.GetKeyDown(KeyCode.A))
		// 	motion.direction.x = -1;

		// if (Input.GetKeyUp(KeyCode.A))
		// 	motion.direction.x = 0;


		// // Down
		// if (Input.GetKeyDown(KeyCode.S))
		// 	motion.direction.y = -1;

		// if (Input.GetKeyUp(KeyCode.S))
		// 	motion.direction.y = 0;


		// // Right
		// if (Input.GetKeyDown(KeyCode.D))
		// 	motion.direction.x = 1;

		// if (Input.GetKeyUp(KeyCode.D))
		// 	motion.direction.x = 0;
	}
}
