// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/05/20 02:24 am

using UnityEngine;

public class TweenTest : MonoBehaviour
{
	void Start()
	{
		transform.tweenPos(
			transform.position,
			transform.position + new Vector3(-10, 0, 0), 2,
			t => Easef.Smoothstep(t));

		// transform
		// 	.tweenPos(
		// 		transform.position,
		// 		transform.position + new Vector3(-10, 0, 0), 5,
		// 		t => Easef.Smootherstep(t))
		// 	.tweenPos(
		// 		transform.position,
		// 		transform.position + new Vector3(-10, 0, 0), 5,
		// 		t => Easef.Smootherstep(t));
	}
}