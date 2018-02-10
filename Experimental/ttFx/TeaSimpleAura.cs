
// TeaTime FX : Simple Aura

// @matnesis
// 2016/05/09 05:16 PM


using UnityEngine;
using matnesis.TeaTime;
using matnesis.Reactive;

[ReactiveInEditMode]
public class TeaSimpleAura : MonoBehaviour
{
    public ReactiveBool update = new ReactiveBool(true);

    [Header("Config")]
    public float time = 1;
    public float delay = 2;
    public float scale = 1.30f;
    public Color fromColor = Color.black;
    public Color toColor = Color.white;

    Renderer render;
    TeaTime simpleAura;


    void Start()
    {
        render = GetComponent<Renderer>();


        // @
        // Simple aura.
        {
            Vector3 currentScale = transform.localScale;

            simpleAura = this.tt().Pause().Loop(time, (ttHandler t) =>
            {
                transform.localScale = Vector3.Lerp(
                    currentScale,
                    currentScale * scale,
                    t.t * t.t * t.t * (t.t * (6f * t.t - 15f) + 10f) // Smotherstep
                );

                render.material.color = Color.Lerp(
                    fromColor,
                    toColor,
                    t.t * t.t * (3f - 2f * t.t) // Smothstep
                );
            })
            .Add(delay).Repeat();
        }


        // Reactive
        update.Subscribe(x =>
        {
            if (x) simpleAura.Play();
            else simpleAura.Stop();
        });
    }
}
