// Simple sphere fx

// Andrés Villalobos | twitter.com/matnesis | andresalvivar@gmail.com
// 2018/04/17 07:21 am

using matnesis.TeaTime;
using UnityEngine;

public class SphereFx : MonoBehaviour
{
	public Renderer render;

	public System.Action OnEnd;

	public void Fx(float time, Vector3 scaleA, Vector3 scaleB, Color colorA, Color colorB)
	{
		this.tt("Fx").Reset().Add(() =>
			{
				render.material.color = colorA;
				render.transform.localScale = scaleA;
			})
			.Loop(time, t =>
			{
				render.transform.localScale = Vector3.Lerp(scaleA, scaleB, Easef.EaseOut(t.t));
				render.material.color = Color.Lerp(colorA, colorB, Easef.EaseOut(t.t));
			}).Add(() =>
			{
				if (OnEnd != null) OnEnd();
			});
	}

	public void Clear()
	{
		this.tt("Fx").Reset();
		render.material.color = Color.clear;
		if (OnEnd != null) OnEnd();
	}
}