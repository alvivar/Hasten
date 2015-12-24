﻿
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

		if (distance != 0 && distanceToTarget > distance)
			return true;

		return false;
	}


	public override IEnumerator Action()
	{
		motion.actions.target = target;
		motion.actions.doFollow.Value = true;

		yield return new WaitForSeconds(0.10f);
	}


	public override void Stop()
	{
		if (motion.actions.doFollow.Value)
		{
			motion.actions.doFollow.Value = false;
			motion.direction = Vector3.zero;
		}
	}
}
