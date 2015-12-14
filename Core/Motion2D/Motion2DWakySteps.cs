
// Weird walk by rotations.

// @matnesis
// 2015/12/12 02:37 PM


using DG.Tweening;
using UnityEngine;
using matnesis.TeaTime;


[RequireComponent(typeof(Motion2D))]
public class Motion2DWakySteps : MonoBehaviour
{
	[Header("Config")]
	public bool enableWakySteps = true;
	public float angle = 5;
	public float duration = 0.20f;

	private Motion2D motion;
	private TeaTime wakyMovement;


	void Start()
	{
		motion = GetComponent<Motion2D>();


		// Waky
		wakyMovement = this.tt().Stop().Add((ttHandler t) =>
		{
			t.WaitFor(transform.DORotate(new Vector3(0, 0, angle), duration).WaitForCompletion());
		})
		.Add((ttHandler t) =>
		{
			t.WaitFor(transform.DORotate(new Vector3(0, 0, -angle), duration).WaitForCompletion());
		})
		.Repeat();
	}


	void Update()
	{
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
