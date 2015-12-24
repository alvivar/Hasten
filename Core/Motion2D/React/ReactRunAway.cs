
// Get away from the target.

// @matnesis
// 2015/12/23 07:57 PM


using UnityEngine;
using System.Collections;


public class ReactRunAway : ReactBase
{
	[Header("Config")]
	public Transform target;
	public float distance;

	[Header("Info")]
	public float distanceToTarget;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();

		if (target == null)
			target = GetComponent<React>().target;
	}


	public override bool Condition()
	{
		distanceToTarget = Vector3.Distance(transform.position, target.position);

		if (distance != 0 && distanceToTarget < distance)
			return true;

		return false;
	}


	public override IEnumerator Action()
	{
		motion.actions.target = target;
		motion.actions.doRunAway.Value = true;

		yield return new WaitForSeconds(0.10f);
	}


	public override void Stop()
	{
		if (motion.actions.doRunAway.Value)
		{
			motion.actions.doRunAway.Value = false;
			motion.direction = Vector3.zero;
		}
	}
}
