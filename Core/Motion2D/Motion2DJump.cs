// Configurable jump for Motion2D.

// Andrés Villalobos | twitter.com/matnesis | andresalvivar@gmail.com
// 2015/08/14 12:15 AM

using matnesis.TeaTime;
using UnityEngine;

[RequireComponent(typeof(Motion2D))]
public class Motion2DJump : MonoBehaviour
{
    [Header("Jump Force")]
    public Vector2 forceOverride; // Overrides ^
    public float decay; // How fast becames 0 after jump

    [Header("Config")]
    public int maxJumps = 1;
    public int currentJumps = 0;

    private Motion2D motion;

    // tt
    private TeaTime jumpDecay;
    private TeaTime jumpReset;

    void Start()
    {
        motion = GetComponent<Motion2D>();

        jumpDecay = this.tt();

        // @
        // Watches after the jump for ground to reset the count.
        {
            jumpReset = this.tt()
                .Add(0.30f)
                .Wait(() => motion.wallsColliding.y + motion.wallsColliding.z + motion.wallsColliding.w > 0)
                .Add(t =>
                {
                    currentJumps = 0;
                    t.self.Stop();
                })
                .Immutable();
        }
    }

    public void DoJump(Vector2 force)
    {
        // No jumps avalaible
        if (currentJumps >= maxJumps) return;

        // Count up
        currentJumps += 1;

        // 0 is neutral as input
        var jumpForce = Vector2.zero;
        jumpForce.x = force.x != 0 ? force.x : motion.force.x;
        jumpForce.y = force.y != 0 ? force.y : motion.force.y;

        // Override
        if (forceOverride != Vector2.zero)
        {
            jumpForce.x = forceOverride.x != 0 ? forceOverride.x : motion.force.x;
            jumpForce.y = forceOverride.y != 0 ? forceOverride.y : motion.force.y;
        }

        // Jump representation
        motion.force = jumpForce;

        // & Decay
        jumpDecay.Reset().Loop(decay, t =>
        {
            motion.force = Vector2.Lerp(motion.force, Vector2.zero, t.deltaTime);
        });

        // Wait until it touch the ground
        jumpReset.Play();
    }
}