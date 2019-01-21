// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/02 03:57 pm

using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public List<Collision2D> detected = new List<Collision2D>();

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!detected.Contains(other))
            detected.Add(other);
    }
}