using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Splender : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }


    public static void Beacon(SpriteRenderer sprite)
    {
        Instantiate(sprite, sprite.transform.position, Quaternion.identity);
    }
}
