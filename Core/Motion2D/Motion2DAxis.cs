
// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 10:57:05 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion2D))]
public class Motion2DAxis : MonoBehaviour
{
	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	void Update()
	{
		motion.direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
}
