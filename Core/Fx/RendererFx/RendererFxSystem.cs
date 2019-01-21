// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/03 03:36 pm

using DG.Tweening;
using matnesis.TeaTime;
using Unity.Entities;
using UnityEngine;

public class RendererFxSystem : ComponentSystem
{
    struct RendererFxData
    {
        public ComponentArray<RendererFx> rendererFx;
        public readonly int Length;
    }

    [Inject] readonly RendererFxData rendererFxData;

    override protected void OnUpdate()
    {
        for (int i = 0; i < rendererFxData.Length; i++)
        {
            var fx = rendererFxData.rendererFx[i];
            if (fx.duration > 0)
            {
                fx.duration -= Time.deltaTime;
                if (fx.tween == null)
                {
                    fx.tween = DOTween.Sequence();
                    fx.tween.SetLoops(-1);
                    for (int j = 0; j < fx.colors.Length; j++)
                    {
                        fx.tween.Append(
                            fx.render.material.DOColor(
                                fx.colors[j], fx.delay
                            )
                        );
                    }
                }
            }
            else if (fx.tween != null)
            {
                fx.tween.Kill(complete: true);
                fx.tween = null;
                fx.render.material.color = fx.defaultColor;
            }
        }
    }
}