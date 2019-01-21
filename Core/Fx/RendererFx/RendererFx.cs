// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/03 03:28 pm

using DG.Tweening;
using UnityEngine;

public class RendererFx : MonoBehaviour
{
	public Renderer render;
	public Color defaultColor;
	public Color[] colors;
	public float delay;
	public float duration;
	public Sequence tween;

	public void Play(float delay, float duration, Color[] colors)
	{
		Stop();
		this.delay = delay;
		this.duration = duration;
		this.colors = colors;
	}

	public void Stop()
	{
		if (tween != null)
		{
			tween.Kill();
			tween = null;
		}
	}
}