
// TeaTime FX : Random rotation

// @matnesis
// 2016/07/10 04:49 PM


using UnityEngine;
using matnesis.TeaTime;
using matnesis.Reactive;

[ReactiveInEditMode]
public class TeaRotation : MonoBehaviour
{
    public ReactiveBool update = new ReactiveBool(false);

    [Header("Config")]
    public Vector3 eulerRangeA = new Vector3(0, 0, -30);
    public Vector3 eulerRangeB = new Vector3(0, 0, 30);
    public Vector2 durationRange = new Vector2(1, 3);
    public Vector2 delayRange = new Vector2(1, 3);

    TeaTime randomRotation;


    void Start()
    {
        // @
        {
            Vector3 bornEuler = transform.eulerAngles;
            Vector3 newEuler = Vector3.zero;
            Vector3 eulerp = Vector3.zero;

            randomRotation = this.tt()
            .Pause()
            .Add(() =>
            {
                newEuler = new Vector3(
                    Random.Range(eulerRangeA.x, eulerRangeB.x),
                    Random.Range(eulerRangeA.y, eulerRangeB.y),
                    Random.Range(eulerRangeA.z, eulerRangeB.z)
                );
            })
            .Loop(() => Random.Range(durationRange.x, durationRange.y), (ttHandler t) =>
            {
                transform.localEulerAngles = new Vector3(
                    Mathf.LerpAngle(bornEuler.x, bornEuler.x + newEuler.x, Easef.Smoothstep(t.t)),
                    Mathf.LerpAngle(bornEuler.y, bornEuler.y + newEuler.y, Easef.Smoothstep(t.t)),
                    Mathf.LerpAngle(bornEuler.z, bornEuler.z + newEuler.z, Easef.Smoothstep(t.t))
                );
            })
            .Loop(() => Random.Range(durationRange.x, durationRange.y), (ttHandler t) =>
            {
                transform.localEulerAngles = new Vector3(
                    Mathf.LerpAngle(bornEuler.x + newEuler.x, bornEuler.x, Easef.Smoothstep(t.t)),
                    Mathf.LerpAngle(bornEuler.y + newEuler.y, bornEuler.y, Easef.Smoothstep(t.t)),
                    Mathf.LerpAngle(bornEuler.z + newEuler.z, bornEuler.z, Easef.Smoothstep(t.t))
                );
            })
            .Add(() => Random.Range(delayRange.x, delayRange.y))
            .Repeat();
        }


        // +R
        update.Subscribe(x =>
        {
            if (x) randomRotation.Play();
            else randomRotation.Stop();
        });
    }
}
