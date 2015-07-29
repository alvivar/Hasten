
// 2015/07/22 11:14:33 PM


using UnityEngine;
using System.Collections;


public class ReactTDFollower : ReactBase
{
	[Header("Data")]
	public bool targetOnSight = false;
	public Vector3 bornpos;

	[Header("Config")]
	public float speed = 2;
	public float distanceTo = 0;

	[Header("Required")]
	public Transform target; // If no set, then get the player from GameContext

	private Motion motion;
	private float currentSpeed = 0;


	void Start()
	{
		bornpos = transform.position;
		motion = GetComponent<Motion>();

		if (target == null)
			target = GameContext.Player;
	}


	public override bool Condition()
	{
		if (Vector3.Distance(target.position, transform.position) < 3)
		{
			targetOnSight = true;
		}

		return targetOnSight;
	}


	public override IEnumerator Action()
	{
		// Random walk
		this.tt("FollowTarget").ttAdd(() =>
		{
			Vector3 targetdir = target.position - transform.position;
			targetdir.z = 0;

			motion.speedOverride = speed;
			motion.botInputVector = targetdir.normalized;
		})
		.ttAdd(0.30f).ttWait();


		yield return new WaitForEndOfFrame();
	}


	public override void Stop()
	{
		// this.tt("FollowTarget").ttReset();
		// this.tt("StopAtWalls").ttReset();

		// motion.botInputVector = Vector3.zero;
		// motion.speedOverride = 0;
	}
}
