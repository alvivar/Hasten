// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/05/20 02:04 am

using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class TweenSystem : ComponentSystem
{
	struct PosData
	{
		public ComponentArray<TweenPos> pos;
		public readonly int Length;
	}

	[Inject] readonly PosData posData;

	override protected void OnUpdate()
	{
		for (int i = 0; i < posData.Length; i++)
		{
			var pos = posData.pos[i];
			if (!pos.done)
			{
				var tRate = 1 / pos.duration;
				pos.t += tRate * Time.deltaTime;

				if (pos.easeFunc != null)
					pos.transform.localPosition = Vector3.Lerp(pos.from, pos.to, pos.easeFunc(pos.t));
				else
					pos.transform.localPosition = Vector3.Lerp(pos.from, pos.to, pos.t);

				if (pos.t >= 1)
					pos.done = true;
			}

		}
	}
}

public static class EntweenExtension
{
	public static Transform tweenPos(this Transform t, Vector3 from, Vector3 to, float duration, System.Func<float, float> easeFunc = null)
	{
		var tw = t.gameObject.GetComponent<TweenPos>();
		if (!tw) tw = t.gameObject.AddComponent<TweenPos>();
		tw.Init();
		tw.from = from;
		tw.to = to;
		tw.duration = duration;
		tw.easeFunc = easeFunc;

		var go = t.gameObject.GetComponent<GameObjectEntity>();
		if (go)
		{
			go.enabled = false;
			go.enabled = true;
		}
		else
		{
			go = t.gameObject.AddComponent<GameObjectEntity>();
		}

		return t;
	}
}