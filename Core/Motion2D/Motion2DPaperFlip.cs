
// Automatic 2D flip effect.

// @matnesis
// 2015/12/13 11:05 PM


using UnityEngine;
using System.Collections;
using DG.Tweening;


[RequireComponent(typeof(Motion2D))]
public class Motion2DPaperFlip : MonoBehaviour
{
	public bool enableXFlip = false;
	public float flipDuration = 0.20f;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	void Update()
	{
		if (enableXFlip)
		{
			// Left
			if (motion.direction.x > 0)
			{
				this.tt("xFlip").Loop(flipDuration, (ttHandler t) =>
				{
					transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), t.deltaTime);
				})
				.Wait();
			}

			// Right
			if (motion.direction.x < 0)
			{
				this.tt("-xFlip").Loop(flipDuration, (ttHandler t) =>
				{
					transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-1, 1, 1), t.deltaTime);
				})
				.Wait();
			}
		}
	}
}
