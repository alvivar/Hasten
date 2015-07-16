
// Andrés Villalobos | @matnesis | andresalvivar@gmail.com
// 2015/07/15 10:33:29 PM

using UnityEngine;
using System.Collections;
using DG.Tweening;


[RequireComponent(typeof(Motion))]
public class Dash : MonoBehaviour
{
	public float dashPower = 3;
	public Motion motion;
	public Rigidbody2D rigid;


	void Start()
	{
		motion = GetComponent<Motion>();
		rigid = GetComponent<Rigidbody2D>();
	}


	void Update()
	{
		// Dash
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Positions
			Vector3 mousepos = MouseUtil.GetMousePosition();
			Vector3 playerpos = transform.position;

			// Ignore z
			mousepos.z = 0;
			playerpos.z = 0;

			// Direction
			Vector2 dashDir = (mousepos - playerpos).normalized;

			// Dash
			motion.jumpForce = dashDir * dashPower;
			motion.Jump();

			transform.DORotate(new Vector3(0, 0, 360), 1);

			this.tt("DashDown").ttReset().ttAdd(0.10f, (ttHandler t) =>
			{
				motion.ResetJump();
			})
			.ttAdd(0.30f, () =>
			{

				motion.Reset();
			});
		}
	}
}
