
// A flexible bullet.

// @matnesis
// 2017/03/27 11:44 am


using UnityEngine;

[ReactiveInEditMode]
public class Bullet : MonoBehaviour
{
    [Header("Config")]
    public float speed = 1;
    public Vector3 direction;

    [Header("Required")]
    public Rigidbody2D rbody;
    public TrailRenderer trail;

    [Header("Info")]
    public Collision2D lastCollision;


    public System.Action<Collision2D> OnCollision;


    void Update()
    {
        var hasDirection = direction != Vector3.zero;

        // Move towards
        if (hasDirection) rbody.velocity = direction * speed;

        // Motion trail
        trail.enabled = hasDirection;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        lastCollision = other;
        if (OnCollision != null) OnCollision(other);
    }
}
