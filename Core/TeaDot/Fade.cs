
// Quick shoot fade animation.

// @matnesis
// 2015/12/14 05:02 PM


using DG.Tweening;
using UnityEngine;


public class Fade : MonoBehaviour
{
	public BoolReactiveProp Show = new BoolReactiveProp(true);
	public float fadeInDuration = 0.20f;
	public float fadeOutDuration = 1;

	private Renderer render;


	void Start()
	{
		render = GetComponent<Renderer>();


		Show.Suscribe(x =>
		{
			render.material.DOKill();

			if (x) render.material.DOColor(Color.white, fadeInDuration);
			else render.material.DOColor(Color.clear, fadeOutDuration);
		});
	}


	void Update()
	{
		Show.SyncWithInspector();
	}
}
