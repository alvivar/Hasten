
// AI Component that search for a target and calls the Action OnTargetFound
// when found.

// Calling .Init() is mandatory.


using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class AiRadar : MonoBehaviour, IAi
{
	private Transform target;
	private float searchDistance = 1;
	private Action OnTargetFound;

	private Action lastPlayCalled;


	// Mandatory initial config.
	public void Init(Transform target, float searchDistance, Action OnTargetFound)
	{
		this.target = target;
		this.searchDistance = searchDistance;
		this.OnTargetFound = OnTargetFound;
	}


	// Looks for the target testing if there is a clear path with a raycast.
	// Calls OnTargetFound if found.
	public void PlayIsTargetOnSight()
	{
		lastPlayCalled = PlayIsTargetOnSight;


		this.tt("PlayIsTargetOnSight").ttAdd(0.25f, (ttHandler t) =>
		{

			if (Vector3.Distance(target.position, transform.position) < searchDistance)
			{
				if (OnTargetFound != null)
					OnTargetFound();

				t.WaitFor(1);
			}

		})
		.ttRepeat();
	}


	public void Play()
	{
		Stop();


		if (lastPlayCalled != null)
			lastPlayCalled();
	}


	public void Stop()
	{
		this.tt("PlayIsTargetOnSight").ttReset();
	}
}
