
// Andrés Villalobos | @matnesis | andresalvivar@gmail.com
// 2015/07/14 06:16:02 PM


using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Motion : MonoBehaviour
{
    public bool update = true;
    public bool isTopDown = false;


    [Header("AI")]
    public bool botMode = false; // Overrides inputs
    public Vector3 botInputVector = Vector3.zero;


    [Header("IO")]
    public bool allowInputs = true;
    public bool allowVertical = false;
    public bool allowHorizontal = true;
    public float inputSignal = 0;
    public Vector2 lastInputDirection;


    [Header("Gravity")]
    public float gravity = -9.81f;
    public Vector2 gravityScale = new Vector3(0, 14);


    [Header("Movement")]
    public float speed = 5f;
    public float movementDecay = 15;


    [Header("Jump")]
    public Vector2 jumpForce = new Vector2(0, 28);
    public float jumpDecay = 2;
    public int maxJumps = 1;
    public int jumpCount = 0;
    public float lastJump = 0;


    [Header("Walls/Ground")]
    public LayerMask wallLayer;
    public Vector2 groundDirection = new Vector2(0, -1);
    public bool isGrounded;
    public bool isFlying;
    private bool previousIsFlying;
    public float colliderExtend;
    public Vector4 wallCollision;
    public int lastWallCollision;
    public bool isNearWall;
    public bool isNearCliff;


    [Header("Animator")]
    public Animator animator;
    public bool isLookingRight = true;
    public bool useAutoXRotation = false;
    public float walkOutput = 0;
    public float flyOutput = 0;


    // Internal
    private float currentSpeed;
    private Vector2 currentJump;
    private float verticalInput;
    private float horizontalInput;


    // Components
    private Rigidbody2D rigid;
    private Collider2D collid;


    // Actions
    public Action OnJump = null;
    public Action OnAirJump = null;
    public Action OnGrounded = null;


    void Start()
    {
        // Rigidbody defaults
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.interpolation = RigidbodyInterpolation2D.Interpolate;

        // collider data
        collid = GetComponent<Collider2D>();
        colliderExtend = collid.bounds.extents.y;
    }


    void Update()
    {
        if (!update)
            return;


        if (allowInputs)
        {
            if (allowVertical)
            {
                verticalInput = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1, 1);
            }
            else
            {
                verticalInput = 0;
            }

            if (allowHorizontal)
            {
                horizontalInput = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1, 1);
            }
            else
            {
                horizontalInput = 0;
            }
        }


        // Bot mode override other inputs
        if (botMode)
        {
            verticalInput = Mathf.Clamp(botInputVector.y, -1,  1);
            horizontalInput = Mathf.Clamp(botInputVector.x, -1, 1);
        }


        // Looking direction
        if (verticalInput > 0)
            lastInputDirection.y = 1;

        if (verticalInput < 0)
            lastInputDirection.y = -1;

        if (horizontalInput > 0)
            lastInputDirection.x = 1;

        if (horizontalInput < 0)
            lastInputDirection.x = -1;


        // Rotation
        AutoRotateAnimatorX();


        // Animator
        if (animator)
        {
            inputSignal = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));


            // Walking on ground
            if (inputSignal > 0 && isGrounded)
                walkOutput = inputSignal;
            else
                walkOutput = 0;


            // Animator sync
            animator.SetFloat("MotionWalk", walkOutput);
        }


        // speed
        currentSpeed = speed;


        // walls analysis
        if (!coAnalyzeWalls)
            StartCoroutine(CoAnalyzeWalls());


        // Ground collision check
        CheckGround();


        // Near cliff or near wall
        AnalyzeHorizontalProximity();
    }


    void FixedUpdate()
    {
        // gravity
        rigid.AddForce(gravityScale * gravity);


        // movement
        currentJump = Vector2.Lerp(currentJump, Vector2.zero, Time.deltaTime * jumpDecay);
        rigid.velocity = Vector2.Lerp(rigid.velocity, new Vector2(horizontalInput * currentSpeed + currentJump.x, verticalInput * currentSpeed + currentJump.y), Time.deltaTime * movementDecay);
    }


    void AutoRotateAnimatorX()
    {
        if (!useAutoXRotation || animator == null)
            return;


        if (lastInputDirection.x < 0)
        {
            float yRotateTo = isLookingRight ? 180 : 0;
            this.tt("AutoRotateAnimatorX").ttLoop(0.11f, delegate(ttHandler t)
            {
                animator.transform.eulerAngles = Vector3.Lerp(animator.transform.eulerAngles, new Vector3(0, yRotateTo, 0), t.deltaTime);
            })
            .ttWait();
        }
        else
        {
            float yRotateTo = isLookingRight ? 0 : 180;
            this.tt("AutoRotateAnimatorX").ttLoop(0.11f, delegate(ttHandler t)
            {
                animator.transform.eulerAngles = Vector3.Lerp(animator.transform.eulerAngles, new Vector3(0, yRotateTo, 0), t.deltaTime);
            })
            .ttWait();
        }
    }


    bool CheckGround()
    {
        // When Top down, it's always ground
        if (isTopDown)
        {
            isGrounded = true;
            return true;
        }


        // Ground & head hit
        bool hitg = Physics2D.Raycast(transform.position, groundDirection, colliderExtend + 0.5f, wallLayer);
        bool hith = Physics2D.Raycast(transform.position, -groundDirection, colliderExtend + 0.5f, wallLayer);


        // Check
        if (hitg || hith)
        {
            if (hitg)
            {
                isGrounded = true;
                if (OnGrounded != null)
                    OnGrounded();
            }

            // Reset jump on ground change
            if (previousIsFlying != isFlying)
            {
                // Reset jumps on ground
                if (hitg)
                    jumpCount = 0;

                // Clean the jump vector unless the player is multi jumping
                if (Time.time - lastJump > 0.10f)
                    ResetJump();
            }

            // Animator
            if (animator != null)
                animator.SetFloat("MotionJump", 0);
        }
        else
        {
            isGrounded = false;
            isFlying = true;
        }

        return isGrounded;
    }


    bool coAnalyzeWalls = false;
    IEnumerator CoAnalyzeWalls()
    {
        coAnalyzeWalls = true;

        wallCollision = Vector4.zero;
        float raypercent = 0.25f;

        // sides
        bool hitu = Physics2D.Raycast(transform.position, Vector2.up, colliderExtend + raypercent, wallLayer);
        if (hitu)
        {
            wallCollision.x = 1;
            lastWallCollision = 1;
        }

        bool hitr = Physics2D.Raycast(transform.position, Vector2.right, colliderExtend + raypercent, wallLayer);
        if (hitr)
        {
            wallCollision.y = 1;
            lastWallCollision = 2;
        }

        bool hitd = Physics2D.Raycast(transform.position, -Vector2.up, colliderExtend + raypercent, wallLayer);
        if (hitd)
        {
            wallCollision.z = 1;
            lastWallCollision = 3;
        }

        bool hitl = Physics2D.Raycast(transform.position, -Vector2.right, colliderExtend + raypercent, wallLayer);
        if (hitl)
        {
            wallCollision.w = 1;
            lastWallCollision = 4;
        }


        // Spider component seems to need this
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();


        // flying
        previousIsFlying = isFlying;
        isFlying = wallCollision.x + wallCollision.y + wallCollision.z + wallCollision.w <= 0;


        // ground detection
        // CheckGround();

        // yield return null;

        coAnalyzeWalls = false;
    }


    void AnalyzeHorizontalProximity()
    {
        this.tt("AnalyzeCliffProximity").ttAdd(0.10f, () =>
        {
            // Is near wall?
            isNearWall = false;

            bool hitRight = Physics2D.Raycast(transform.position, Vector2.right, colliderExtend + 1f, wallLayer);
            if (hitRight)
            {
                isNearWall = true;
            }

            bool hitLeft = Physics2D.Raycast(transform.position, Vector2.right * -1, colliderExtend + 1f, wallLayer);
            if (hitLeft)
            {
                isNearWall = true;
            }


            // Is Near cliff?
            isNearCliff = false;

            hitRight = Physics2D.Raycast(transform.position + new Vector3(colliderExtend * 2, 0, 0), Vector2.up * -1, colliderExtend + 0.2f, wallLayer);
            if (hitRight == false)
            {
                isNearCliff = true;
            }

            hitLeft = Physics2D.Raycast(transform.position - new Vector3(colliderExtend * 2, 0, 0), Vector2.up * -1, colliderExtend + 0.2f, wallLayer);
            if (hitLeft == false)
            {
                isNearCliff = true;
            }

        })
        .ttWait();
    }


    public void Jump()
    {
        CheckGround();


        // Jump limit
        if (jumpCount >= maxJumps)
            return;


        // Jump event
        if (OnJump != null)
            OnJump();


        // Air jump event
        if (isFlying == true && OnAirJump != null)
            OnAirJump();


        // Jump!
        lastJump = Time.time;
        jumpCount += 1;
        currentJump = jumpForce;


        // #hm What?
        if (jumpForce.x != 0)
            rigid.velocity = new Vector2(0, rigid.velocity.y);

        if (jumpForce.y != 0)
            rigid.velocity = new Vector2(rigid.velocity.x, 0);


        // Animator
        if (animator != null)
            animator.SetFloat("MotionJump", 1);
    }


    public void ResetJump()
    {
        currentJump = Vector3.ClampMagnitude(currentJump, speed);

        // Resets the count jump if there is no change of flying state
        // Why? #hm
        if (previousIsFlying == isFlying)
            jumpCount = 0;
    }


    public void Reset()
    {
        ResetJump();
        rigid.velocity = Vector3.zero;
        verticalInput = 0;
        horizontalInput = 0;
    }
}
