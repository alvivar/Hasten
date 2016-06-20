
// Punch the target based on certain condition.

// @matnesis
// 2016/06/17 09:38 PM


using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Motion2D))]
[RequireComponent(typeof(Motion2DImpulse))]
public class ReactOnHit : ReactBase
{
    public bool isHit = false;
    public Collision2D lastCollision;

    [Header("Config")]
    public Transform target;
    public LayerMask hitLayer;
    public float force;
    public float attack;
    public float sustain;
    public float decay;

    private Motion2D motion;


    void Start()
    {
        motion = GetComponent<Motion2D>();

        if (target == null)
            target = GetComponent<React>().target;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 1 << hitLayer)
        {
            isHit = true;
            lastCollision = other;
        }
    }


    public override bool Condition()
    {
        if (isHit) return true;
        return false;
    }


    public override IEnumerator Action()
    {
        isHit = false;

        Vector2 direction = (lastCollision.transform.position - transform.position).normalized;
        motion.impulse.DoImpulse(force * direction, attack, sustain, decay);

        yield return new WaitForSeconds(0.10f);
    }


    public override void Stop()
    {
        //
    }
}
