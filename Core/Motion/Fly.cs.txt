using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
// using DG.Tweening;


public class Fly : MonoBehaviour
{
    public bool update = true;

    [Header("Animator")]
    public Animator animator;
    public SpriteRenderer sprite;

    [Header("Flying conditions")]
    public bool activateFlying = false;
    public bool allowsInput = true;
    public bool allowsVertical = true;
    public Vector2 gravityScale = new Vector3(0, 0);
    public float speed = 0;
    public float boost = 0;
    private bool lastActivateFlying = false;

    [Header("Ground conditions")]
    public bool allowsInputGr = false;
    public bool allowsVerticalGr = false;
    public float gravityGr = 0;
    public Vector2 gravityScaleGr = new Vector3(0, 0);
    public float speedGr = 0;
    public Vector2 jumpForceGr = new Vector2(0, 0);

    private Motion motion;
    private Gamepad gamepad;
    private Rigidbody2D rigidbody2;

    public Action OnFlying = null;
    public Action OnBoost = null;


    void Start()
    {
        motion = GetComponent<Motion>();
        gamepad = GetComponent<Gamepad>();
        rigidbody2 = GetComponent<Rigidbody2D>();

        // Gamepad registration
        if (gamepad != null)
        {
            gamepad.OnLeftShiftIn += ActivateFlyingHandler;
            gamepad.OnLeftShiftOut += StopFlyingHandler;
            gamepad.OnSpacebar += ActivateBoostHandler;
        }

        // Motion ground data
        allowsInputGr = motion.allowInputs;
        allowsVerticalGr = motion.allowVertical;
        gravityGr = motion.gravity;
        gravityScaleGr = motion.gravityScale;
        speedGr = motion.speed;
        jumpForceGr = motion.jumpForce;
    }


    void OnDestroy()
    {
        // De-registration
        if (gamepad)
        {
            gamepad.OnLeftShiftIn -= ActivateFlyingHandler;
            gamepad.OnLeftShiftOut -= StopFlyingHandler;
            gamepad.OnSpacebar -= ActivateBoostHandler;
        }
    }


    void Update()
    {
        if (update == false)
            activateFlying = false;

        // Flying / Ground Motion config
        if (update == true && activateFlying == true && activateFlying != lastActivateFlying)
        {
            if (OnFlying != null)
                OnFlying();

            this.tt("GroundLandingLerp").ttReset();
            this.tt("JumpSlowDown").ttReset();

            // Flying conditions
            motion.allowInputs = allowsInput;
            motion.allowVertical = allowsVertical;
            motion.gravity = gravityGr;
            motion.gravityScale = gravityScale;
            motion.speed = speed;

            // Jump settings
            motion.maxJumps = 999;
            motion.jumpForce = Vector2.zero;
            motion.ResetJump();

            // Jump signal when flying
            animator.SetFloat("MotionJump", 1);
        }
        else if (activateFlying != lastActivateFlying)
        {
            // Ground conditions
            motion.gravity = gravityGr;
            motion.jumpForce = jumpForceGr;

            // Jump reset
            motion.maxJumps = 2;
            motion.jumpCount = 0;

            this.tt("GroundLandingLerp").ttLoop(0.75f, delegate(ttHandler t)
            {
                motion.gravityScale = Vector3.Lerp(motion.gravityScale, gravityScaleGr, t.deltaTime);
                motion.speed = Mathf.Lerp(motion.speed, speedGr, t.deltaTime);
            })
            .ttAdd(delegate()
            {
                motion.allowInputs = allowsInputGr;
                motion.allowVertical = allowsVerticalGr;
            })
            .ttWait();
        }

        lastActivateFlying = activateFlying;

        // Sync animator when flying with force
        if (activateFlying == true && motion.inputSignal > 0 && motion.isFlying == true)
        {
            animator.SetFloat("MotionJump", 1);
            animator.SetFloat("MotionFly", 1);
        }
        else
        {
            animator.SetFloat("MotionFly", 0);
        }
    }


    void ActivateFlyingHandler()
    {
        activateFlying = true;
    }


    void StopFlyingHandler()
    {
        activateFlying = false;
    }


    void ActivateBoostHandler()
    {
        if (activateFlying)
        {
            if (OnBoost != null)
                OnBoost();

            motion.jumpForce = rigidbody2.velocity.normalized * boost;
            motion.Jump();

            // Air blast effect
            Transform fromPool = sprite.transform.lpSpawn(sprite.transform.position, Quaternion.identity);

            SpriteRenderer currentSprite = fromPool.GetComponent<SpriteRenderer>();
            currentSprite.color = Color.white;

            this.tt().ttLoop(0.20f, delegate(ttHandler t)
            {
                currentSprite.transform.localScale = Vector3.Lerp(currentSprite.transform.localScale, new Vector3(3, 3, 1), t.deltaTime);
                currentSprite.color = Color.Lerp(currentSprite.color, Color.white * 0.1f, t.deltaTime);
            })
            .ttLoop(1f, delegate(ttHandler t)
            {
                currentSprite.transform.localScale = Vector3.Lerp(currentSprite.transform.localScale, new Vector3(6, 6, 1), t.deltaTime);
                currentSprite.color = Color.Lerp(currentSprite.color, Color.clear, t.deltaTime);
            })
            .ttAdd(delegate()
            {
                currentSprite.transform.localScale = new Vector3(1, 1, 1);
                fromPool.lpRecycle();
            });
        }
        else
        {
            // If avalaible
            if (motion.jumpCount >= motion.maxJumps)
                return;

            // Normal jump behaviour
            this.tt("GroundLandingLerp").ttReset();
            motion.gravity = gravityGr;
            motion.jumpForce = jumpForceGr;
            motion.gravityScale = gravityScaleGr;
            motion.allowInputs = allowsInputGr;
            motion.allowVertical = allowsVerticalGr;

            // A little push to the front
            // motion.speed = speed;
            // motion.jumpForce.x = motion.lastInputDirection.x *  motion.jumpForce.y;
            motion.Jump();

            // Normalize
            this.tt("JumpSlowDown").ttReset().ttLoop(0.5f, delegate(ttHandler t)
            {
                motion.speed = Mathf.Lerp(motion.speed, speedGr, t.deltaTime);
            });
        }
    }
}
