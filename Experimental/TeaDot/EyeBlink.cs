
// Blink animation, useful for small 2D eyes.

// @matnesis
// 2015/12/14 10:25 PM


using DG.Tweening;
using UnityEngine;
using matnesis.TeaTime;


public class EyeBlink : MonoBehaviour
{
    public Vector2 randomBetween = new Vector2(4, 8);
    public TeaTime ttBlink;


    void Start()
    {
        ttBlink = this.tt();
        ttBlink.Add((ttHandler t) =>
        {
            Sequence ts = DOTween.Sequence();
            ts.Append(transform.DOScaleY(0.001f, 0.10f));
            ts.Append(transform.DOScaleY(1, 0.10f));

            t.Wait(ts.WaitForCompletion());
            t.Wait(Random.Range(randomBetween.x, randomBetween.y));
        })
        .Repeat();
    }
}
