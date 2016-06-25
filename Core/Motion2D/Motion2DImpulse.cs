
// Configurable force impulse for Motion2D.

// Andrés Villalobos ~ andresalvivar@gmail.com ~ twitter.com/matnesis
// 2016/06/17 09:45 PM


using UnityEngine;
using matnesis.TeaTime;

[RequireComponent(typeof(Motion2D))]
public class Motion2DImpulse : MonoBehaviour
{
    [Header("Config")]
    public Vector2 force; // 0 is neutral
    public Vector2 forceOverride; // Overrides ^
    public float attack; // How fast becomes maximum force
    public float sustain; // How long stays at maximum force
    public float decay; // How fast becames 0 after

    private Motion2D motion;
    private TeaTime ttImpulse;


    void Start()
    {
        motion = GetComponent<Motion2D>();
        ttImpulse = this.tt();
    }


    public TeaTime DoImpulse(Vector2 force, float attack, float sustain, float decay)
    {
        this.force = force;
        this.attack = attack;
        this.sustain = sustain;
        this.decay = decay;

        return DoImpulse();
    }


    public TeaTime DoImpulse()
    {
        // @
        {
            Vector2 currentForce = motion.force;

            ttImpulse.Reset().Loop(attack, (ttHandler t) =>
            {
                // Attack
                motion.force = Vector2.Lerp(
                    currentForce,
                    force,
                    t.t
                );
            })
            .Add(sustain).Loop(decay, (ttHandler t) =>
            {
                // Decay
                motion.force = Vector2.Lerp(
                    force,
                    Vector2.zero,
                    t.t
                );
            });
        }

        return ttImpulse;
    }
}
