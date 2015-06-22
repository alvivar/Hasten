using UnityEngine;
using System.Collections;


public class Timeflux : MonoBehaviour
{
    public float scale = 1;

    private static Timeflux instance;
    public static Timeflux Get
    {
        get
        {
            if (instance != null)
            {
                instance = GameObject.FindObjectOfType<Timeflux>();
            }
            else
            {
                GameObject go = new GameObject("[Timeflux]");
                instance = go.AddComponent<Timeflux>();
            }

            return instance;
        }
    }


    void Update()
    {
        Time.timeScale = scale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
