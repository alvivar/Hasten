
// Time manager.

// @matnesis
// 2015/10/19 04:54 PM | 2016/09/24 07:18 PM


using UnityEngine;
using matnesis.TeaTime;

public class Timeflux : MonoBehaviour
{
    public FloatReactiveProp scale = new FloatReactiveProp(1);


    void Awake()
    {
        scale.Suscribe(UpdateTimeScale);
    }


    void OnDestroy()
    {
        scale.Unsubscribe(UpdateTimeScale);
    }


    void UpdateTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = 0.02f * timeScale; // Physics
    }


    public TeaTime FadeToScale(float timeScale, float duration)
    {
        float currentScale = Time.timeScale;
        return this.tt("@fadeToScale").Reset().Loop(duration, (ttHandler t) =>
        {
            scale.Value = Mathf.Lerp(
                currentScale, timeScale, Easef.Smoothstep(t.t)
            );
        });
    }


    public void Reset()
    {
        this.tt("@fadeToScale").Reset();
    }
}
