
// Time manager.

// @matnesis
// 2015/10/19 04:54 PM | 2016/09/24 07:18 PM


using UnityEngine;
using matnesis.TeaTime;
using matnesis.Reactive;

public class Timeflux : MonoBehaviour
{
    public ReactiveFloat scale = new ReactiveFloat(1);


    void Awake()
    {
        scale.Subscribe(timeScale =>
        {
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = 0.02f * timeScale; // Physics
        });
    }


    public TeaTime FadeToScale(float timeScale, float duration)
    {
        float currentScale = Time.timeScale;
        return this.tt("@FadeToScale").Reset().Loop(duration, (ttHandler t) =>
        {
            scale.Value = Mathf.Lerp(
                currentScale, timeScale, Easef.Smoothstep(t.t)
            );
        });
    }


    public void Reset()
    {
        this.tt("@FadeToScale").Reset();
    }
}
