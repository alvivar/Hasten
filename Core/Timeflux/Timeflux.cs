
// Time manager.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/10/19 04:54 PM


using UnityEngine;
using System.Collections;


public class Timeflux : MonoBehaviour
{
    public float scale = 1;


    void Update()
    {
        Time.timeScale = scale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
