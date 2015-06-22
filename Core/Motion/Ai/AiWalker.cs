
// AI component that walks in 2D platforms using Motion.

using System;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(Motion))]
public class AiWalker : MonoBehaviour, IAi
{
	private Action lastPlayedBehaviour;
	private Vector3 aiVector;


	// Components
	private Motion motion;


	void Start()
	{
		// Motion defaults for ai
		motion = GetComponent<Motion>();
		motion.allowInputs = false;
		motion.botMode = true;
	}


	// void OnBecameInvisible()
	// {
	// 	Stop();
	// }


	// void OnBecameVisible()
	// {
	// 	Play();
	// }


	public void PlayRandomWalkerHorizontal()
	{
		lastPlayedBehaviour = PlayRandomWalkerHorizontal;


		// Random side
		aiVector.x = Random.value <= 0.5f ? -1 : 1;
		motion.botInputVector = aiVector;


		float lastTurnAround = 0;


		// Turn if there is no place to go
		this.tt("PlayRandomWalkerHorizontal_SideToSide").ttReset().ttAdd(0.10f, (ttHandler t) =>
		{
			if (motion.isNearWall || motion.isNearCliff)
			{
				// Turn around
				motion.wallCollision = Vector4.zero;
				motion.botInputVector = motion.botInputVector * -1;
				lastTurnAround = Time.time;
				t.WaitFor(1);
			}

		})
		.ttRepeat();


		// Rest some times
		this.tt("PlayRandomWalkerHorizontal_MaybeWalk").ttReset().ttAdd(3, () =>
		{
			if (Random.value <= 0.5f)
			{
				// Pause
				aiVector = motion.botInputVector;
				motion.botInputVector = Vector3.zero;
			}
			// Only if the last time that turned around > 2
			else if (Time.time - lastTurnAround > 2)
			{
				// Continue
				if (aiVector == Vector3.zero)
					aiVector.x = Random.value <= 0.5f ? -1 : 1;

				motion.botInputVector = aiVector;
			}
		})
		.ttRepeat();
	}


	public void PlayHorizontalPatrol()
	{
		lastPlayedBehaviour = PlayHorizontalPatrol;


		// Start at random side
		aiVector.x = Random.value <= 0.5f ? -1 : 1;
		motion.botInputVector = aiVector;


		this.tt("PlayHorizontalPatrol").ttReset().ttAdd(0.10f, (ttHandler t) =>
		{
			if (motion.isNearWall || motion.isNearCliff)
			{
				// Current
				aiVector = motion.botInputVector;

				// Stop
				motion.wallCollision = Vector4.zero;
				motion.botInputVector = Vector3.zero;

				// Wait 1s and patrol to the otherside
				this.tt().ttAdd(1.5f, () =>
				{
					motion.botInputVector = aiVector * -1;
				});

				// Rest
				t.WaitFor(2.5f);
			}
		})
		.ttRepeat();
	}


	public void Play()
	{
		Stop();

		if (lastPlayedBehaviour != null)
			lastPlayedBehaviour();
	}


	public void Stop()
	{
		// PlayRandomWalkerHorizontal
		this.tt("PlayRandomWalkerHorizontal_SideToSide").ttReset();
		this.tt("PlayRandomWalkerHorizontal_MaybeWalk").ttReset();

		// PlayHorizontalPatrol
		this.tt("PlayHorizontalPatrol").ttReset();

		aiVector = motion.botInputVector;
		motion.botInputVector  = new Vector3(0, 0, 0);
	}
}
