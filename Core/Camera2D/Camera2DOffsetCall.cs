
// This component will call the camera 2D attention when triggered, by modifying
// his offset.

// 2016/04/02 01:50 PM


using UnityEngine;
using matnesis.TeaTime;

public class Camera2DOffsetCall : MonoBehaviour
{
    [Header("Config")]
    public Vector3 cameraOffset;
    public float transitionDuration = 8;

    [Header("Auto")]
    public Camera2D cam;

    private static MonoBehaviour mono;


    void Start()
    {
        cam = Game.camera2D;

        if (mono == null) mono = this;
    }


    void OnTriggerEnter2D()
    {
        Vector3 current = cam.focusOffsetOverride;
        mono.tt("@focusTransition").Reset().Loop(transitionDuration, (ttHandler t) =>
        {
            cam.focusOffsetOverride = Vector3.Lerp(
                current,
                cameraOffset,
                Easef.Smootherstep(t.t)
            );
        });
    }


    void OnTriggerExit2D()
    {
        Vector3 current = cam.focusOffsetOverride;
        mono.tt("@focusTransition").Reset().Loop(transitionDuration, (ttHandler t) =>
        {
            cam.focusOffsetOverride = Vector3.Lerp(
                current,
                Vector3.zero,
                Easef.Smootherstep(t.t)
            );
        })
        .Add(() => cam.focusOffsetOverride = Vector3.zero);
    }
}
