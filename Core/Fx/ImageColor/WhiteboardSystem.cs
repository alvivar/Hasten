// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/10 05:36 pm

using System.Collections.Generic;
using DG.Tweening;
using Unity.Entities;
using UnityEngine;

public class WhiteboardSystem : ComponentSystem
{
	struct Data
	{
		public ComponentArray<Whiteboard> Image;
		public readonly int Length;
	}

	[Inject] readonly Data data;

	static List<Whiteboard> whiteboards = new List<Whiteboard>();

	override protected void OnUpdate()
	{
		for (int i = 0; i < data.Length; i++)
		{
			var img = data.Image[i];

			if (!whiteboards.Contains(img))
				whiteboards.Add(img);

			if (img.duration > 0)
			{
				img.duration -= Time.deltaTime;
				if (img.tween == null)
				{
					img.image.color = img.from;
					img.tween = DOTween.Sequence()
						.Append(img.image.DOColor(img.to, img.duration))
						.AppendCallback(() =>
						{
							img.duration = 0;
							img.tween = null;
						});
				}
			}
		}
	}

	public static void Transition(Color from, Color to, float duration)
	{
		// while (whiteboards.Count > 0 && whiteboards[0] == null)
		// 	whiteboards.RemoveAt(0);

		for (int i = 0; i < whiteboards.Count; i++)
		{
			whiteboards[i].from = from;
			whiteboards[i].to = to;
			whiteboards[i].duration = duration;
			whiteboards[i].tween.Kill();
			whiteboards[i].tween = null;
		}
	}
}