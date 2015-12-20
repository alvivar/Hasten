
// Quick shoot fade animation.

// @matnesis
// 2015/12/14 05:02 PM


using DG.Tweening;
using UnityEngine;


[Reactive]
public class Fade : MonoBehaviour
{
	public BoolReactiveProp Show = new BoolReactiveProp(true);

	[Header("Fade In")]
	public Color fadeInColor = Color.white;
	public float fadeInDuration = 0.20f;

	[Header("Fade Out")]
	public Color fadeOutColor = Color.clear;
	public float fadeOutDuration = 1;

	private Renderer render;


	void Start()
	{
		render = GetComponent<Renderer>();


		Show.Suscribe(x =>
		{
			render.material.DOKill();

			if (x) render.material.DOColor(fadeInColor, fadeInDuration);
			else render.material.DOColor(fadeOutColor, fadeOutDuration);
		});
	}
}
