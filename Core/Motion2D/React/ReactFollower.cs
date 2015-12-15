
// Locks the Motion direction to target.position.

// @matnesis
// 2015/12/13 04:25 PM


using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[RequireComponent(typeof(Motion2D))]
[RequireComponent(typeof(Motion2DActions))]
public class ReactFollower : ReactBase
{
	[Header("Info")]
	public float distanceToTarget;

	[Header("Config")]
	public Transform target;
	public float distanceToFollow;

	private Motion2D motion;


	void Start()
	{
		motion = GetComponent<Motion2D>();
	}


	public override bool Condition()
	{
		distanceToTarget = Vector3.Distance(transform.position, target.position);

		if (distanceToTarget > distanceToFollow)
			return true;

		return false;
	}


	public override IEnumerator Action()
	{
		motion.actions.target = target;
		motion.actions.doFollowTarget.Play();

		yield return new WaitForSeconds(0.10f);
	}


	public override void Stop()
	{
		if (motion.actions.doFollowTarget.IsPlaying)
		{
			motion.actions.doFollowTarget.Stop();
			motion.direction = Vector3.zero;
		}
	}
}
