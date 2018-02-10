
// Tween library API prototype using DOTween in the meantime.

// Andrés Villalobos | twitter.com/matnesis | andresalvivar@gmail.com
// 2017/08/13 11:15 pm


using System;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;


public class loop
{
    private Sequence dotween = DOTween.Sequence();


    public static loop create()
    {
        return new loop();
    }


    public loop then(DOGetter<float> getter, DOSetter<float> setter, float endvalue, float time)
    {
        dotween.Append(DOTween.To(getter, setter, endvalue, time));

        return this;
    }


    public loop then(Tweener tweener)
    {
        dotween.Append(tweener);

        return this;
    }


    public loop then(TweenCallback callback)
    {
        dotween.AppendCallback(callback);

        return this;
    }


    public loop wait(float time)
    {
        dotween.AppendInterval(time);

        return this;
    }


    public loop wait(Func<float> callback)
    {
        dotween.AppendCallback(() =>
        {
            loop.create()
                .then(() => dotween.Pause())
                .wait(callback())
                .then(() => dotween.Play());
        });

        return this;
    }


    public YieldInstruction WaitForCompletion()
    {
        return dotween.WaitForCompletion();
    }


    public loop repeat()
    {
        dotween.SetLoops(-1);

        return this;
    }
}
