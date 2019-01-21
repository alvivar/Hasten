// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/02 03:53 pm

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public Vector3 direction;
    public float speed;
    public System.Action<Collision2D, Bullet> onCollision;
    public float timer;

    public void Clean()
    {
        target = null;
        direction = Vector3.zero;
        speed = 0;
        onCollision = null;
        timer = 0;
    }
}