
// Configurable Motion2D TeaTime behaviours.

// @matnesis
// 2015/12/13 06:11 PM


using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[RequireComponent(typeof(Motion2D))]
public class Motion2DActions : MonoBehaviour
{
	[Header("Config")]
	public Transform target;

	// TeaTime
	public TeaTime doFollowTarget;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();


		doFollowTarget = this.tt().Add(0.10f, () =>
		{
			Vector3 dirToTarget = target.position - transform.position;
			dirToTarget.z = 0;

			motion.direction = dirToTarget.normalized;
		})
		.Repeat();
	}
}
