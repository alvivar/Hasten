// Handles the states to make Motion2D fly in the sky!

// Andrés Villalobos | twitter.com/matnesis | andresalvivar@gmail.com
// 2017/09/15 10:48 am

using matnesis.TeaTime;
using UnityEngine;

public class Motion2DFly : MonoBehaviour
{

    [Header("Config")]
    public Vector2 flyGravity;
    public float flySpeed;
    public Vector2 groundGravity;
    public float groundSpeed;

    [Header("Info")]
    public bool isFlying = false;

    private Motion2D motion;

    void Start()
    {
        motion = GetComponent<Motion2D>();
        DoGround();
    }

    public void DoFly()
    {
        if (isFlying) return;
        isFlying = true;

        motion.gravity = flyGravity;
        motion.limit = motion.magnitude = flySpeed;

        this.tt("DoGroundReset").Stop();
    }

    public void DoGround()
    {
        if (!isFlying) return;
        isFlying = false;

        motion.limit = groundSpeed;

        this.tt("DoGroundReset").Reset().Loop(t =>
        {
            motion.gravity = Vector3.Lerp(motion.gravity, groundGravity, Time.deltaTime);
            motion.magnitude = Mathf.Lerp(motion.magnitude, groundSpeed, Time.deltaTime * 0.6f);
        });
    }
}