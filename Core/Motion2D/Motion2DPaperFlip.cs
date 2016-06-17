﻿
// Automatic 2D flip effect, assumes right orientation as default.

// @matnesis
// 2015/12/13 11:05 PM


using UnityEngine;
using matnesis.TeaTime;

[RequireComponent(typeof(Motion2D))]
public class Motion2DPaperFlip : MonoBehaviour
{
    [Header("Config")]
    public Transform target;
    public bool invertX = false;
    public bool enableXFlip = true;
    public float flipDuration = 0.20f;

    private Motion2D motion;


    void Start()
    {
        motion = GetComponent<Motion2D>();

        // If the target wasn't selected, use self
        if (!target) target = transform;
    }


    void Update()
    {
        if (enableXFlip)
        {
            // Left
            if (motion.direction.x < 0)
            {
                this.tt("@xFlipL").Loop(flipDuration, (ttHandler t) =>
                {
                    target.localScale = Vector3.Lerp(target.localScale, new Vector3(!invertX ? -1 : 1, 1, 1), t.deltaTime);
                })
                .Immutable();
            }

            // Right
            if (motion.direction.x > 0)
            {
                this.tt("@xFlipR").Loop(flipDuration, (ttHandler t) =>
                {
                    target.localScale = Vector3.Lerp(target.localScale, new Vector3(!invertX ? 1 : -1, 1, 1), t.deltaTime);
                })
                .Immutable();
            }
        }
    }
}
