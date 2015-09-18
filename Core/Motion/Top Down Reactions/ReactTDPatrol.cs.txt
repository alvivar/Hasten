
// 2015/07/22 07:27:16 PM


using UnityEngine;
using System.Collections;


public class ReactTDPatrol : ReactBase
{
	[Header("Info")]
	public Vector3 bornpos;

	[Header("Config")]
	public float speed = 3;

	private Motion motion;
	private float currentSpeed = 0;


	void Start()
	{
		bornpos = transform.position;
		motion = GetComponent<Motion>();
	}


	public override bool Condition()
	{
		return true;
	}


	public override IEnumerator Action()
	{
		Vector3 randomdir = Random.insideUnitSphere;
		randomdir.z = 0;

		Vector3 borndir = bornpos - transform.position;
		borndir.z = 0;


		// Random walk
		this.tt("ChangeDirection").ttAdd(() =>
		{
			motion.speedOverride = speed;
			motion.botInputVector = randomdir.normalized;
		})
		.ttAdd(Random.Range(1f, 2f), () =>
		{
			motion.botInputVector = Vector3.zero;
		})
		.ttAdd(Random.Range(1f, 2f), () =>
		{
			motion.botInputVector = borndir.normalized;
		})
		.ttAdd(Random.Range(2f, 4f)).ttWait();


		// Change direction when touching walls
		this.tt("StopAtWalls").ttAdd((ttHandler t) =>
		{
			Collider2D other = Physics2D.OverlapCircle(transform.position, 0.5f, 1 << LayerMask.NameToLayer(Layer.Ground));
			if (other)
			{
				motion.botInputVector = motion.botInputVector * -1;
				t.WaitFor(1f);
			}
		})
		.ttAdd(0.20f).ttWait();


		yield return new WaitForEndOfFrame();
	}


	public override void Stop()
	{
		// this.tt("ChangeDirection").ttReset();
		// this.tt("StopAtWalls").ttReset();

		// motion.botInputVector = Vector3.zero;
		// motion.speedOverride = 0;
	}
}
