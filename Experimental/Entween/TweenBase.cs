// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/05/20 02:46 am

using UnityEngine;

public abstract class TweenBase : MonoBehaviour
{
    public float t = 0;
    public bool done = false;
    public System.Func<float, float> easeFunc = null;

    public void Init()
    {
        t = 0;
        done = false;
        easeFunc = null;
    }
}