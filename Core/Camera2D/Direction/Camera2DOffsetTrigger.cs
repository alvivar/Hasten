
// @matnesis
// 2017/02/24 07:08 AM


using UnityEngine;
using DG.Tweening;

public class Camera2DOffsetTrigger : MonoBehaviour
{
    public Vector3 offset;
    public float duration = 5;


    void OnTriggerEnter2D()
    {
        // Camera offset to the left
        DOTween.To(
            () => Game.camera2D.focusOffsetOverride,
            x => Game.camera2D.focusOffsetOverride = x,
            offset,
            duration
        );
    }
}
