
// Weird walk simulation with some rotations.

// @matnesis
// 2015/12/12 02:37 PM


using DG.Tweening;
using UnityEngine;
using matnesis.TeaTime;
using DG.Tweening;


public class Motion2DWakySteps : MonoBehaviour
{
	public TeaTime wakyMovement = null;


	void Start()
	{
		wakyMovement = this.tt().Stop().Add((ttHandler t) =>
		{
			t.WaitFor(transform.DORotate(new Vector3(0, 0, 5), 0.20f).WaitForCompletion());
		})
		.Add((ttHandler t) =>
		{
			t.WaitFor(transform.DORotate(new Vector3(0, 0, -5), 0.20f).WaitForCompletion());
		})
		.Repeat();
	}


	void Update()
	{
		//
		if (motion.direction.sqrMagnitude != 0)
		{
			wakyMovement.Play();
		}
		else
		{
			if (wakyMovement.IsPlaying)
				wakyMovement.Stop();
		}
	}
}
