
// Quick shoot fade animation.

// @matnesis
// 2015/12/14 05:02 PM


using DG.Tweening;
using UnityEngine;


public class Fade : MonoBehaviour
{
	public BoolReactiveProp Show = new BoolReactiveProp(true);

	[Header("Config")]
	public Color fadeInColor = Color.white;
	public float fadeInDuration = 0.20f;
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

		Show.SyncWithInspector();
	}


#if UNITY_EDITOR
	void Update()
	{
		Show.SyncWithInspector();
	}
#endif
}
