
// Configurable Motion2D TeaTime behaviours.

// @matnesis
// 2015/12/13 06:11 PM


using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[Reactive]
[RequireComponent(typeof(Motion2D))]
public class Motion2DActions : MonoBehaviour
{
	[Header("Config")]
	public Transform target;
	public BoolReactiveProp doFollow = new BoolReactiveProp(false);
	public BoolReactiveProp doRunAway = new BoolReactiveProp(false);

	// TeaTime
	private TeaTime followTarget;
	private TeaTime runAwayFromTarget;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();


		// ^
		// Follow

		followTarget = this.tt().Pause().Add(0.10f, (ttHandler t) =>
		{
			Vector3 dirToTarget = target.position - transform.position;
			dirToTarget.z = 0;

			motion.direction = dirToTarget.normalized;
		})
		.Repeat();

		doFollow.Suscribe(x =>
		{
			if (x) followTarget.Play();
			else followTarget.Stop();
		});



		// ^
		// Run away

		runAwayFromTarget = this.tt().Pause().Add(0.10f, (ttHandler t) =>
		{
			Vector3 dirToTarget = transform.position - target.position;
			dirToTarget.z = 0;

			motion.direction = dirToTarget.normalized;
		})
		.Repeat();

		doRunAway.Suscribe(x =>
		{
			if (x) runAwayFromTarget.Play();
			else runAwayFromTarget.Stop();
		});
	}
}
