
// Quick shoot fade animation.

// @matnesis
// 2015/12/14 05:02 PM


using DG.Tweening;
using UnityEngine;
using matnesis.Reactive;


[ReactiveInEditMode]
public class Fade : MonoBehaviour
{
    public ReactiveBool Show = new ReactiveBool(true);

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


        Show.Subscribe(x =>
        {
            render.material.DOKill();

            if (x) render.material.DOColor(fadeInColor, fadeInDuration);
            else render.material.DOColor(fadeOutColor, fadeOutDuration);
        });
    }
}
