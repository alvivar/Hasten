
// Custom Rigidbody2D Motion a la CharacterController.

// Andrés Villalobos ~ andresalvivar@gmail.com ~ twitter.com/matnesis
// 2015/08/11 10:13 PM


using UnityEngine;
using matnesis.TeaTime;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Motion2D : MonoBehaviour
{
    public bool update = true;


    // ^
    // Axis
    private Motion2DAxis _axis;
    public Motion2DAxis axis
    {
        get { return _axis == null ? _axis = GetComponent<Motion2DAxis>() : _axis; }
    }


    // ^
    // Impulse
    private Motion2DImpulse _impulse;
    public Motion2DImpulse impulse
    {
        get { return _impulse == null ? _impulse = GetComponent<Motion2DImpulse>() : _impulse; }
    }


    // ^
    // Jump
    private Motion2DJump _jump;
    public Motion2DJump jump
    {
        get { return _jump == null ? _jump = GetComponent<Motion2DJump>() : _jump; }
    }


    // ^
    // Wall jump
    private Motion2DWallJump _wallJump;
    public Motion2DWallJump wallJump
    {
        get { return _wallJump == null ? _wallJump = GetComponent<Motion2DWallJump>() : _wallJump; }
    }


    // ^
    // Actions
    private Motion2DActions _actions;
    public Motion2DActions actions
    {
        get { return _actions == null ? _actions = GetComponent<Motion2DActions>() : _actions; }
    }


    // ^
    // Rigidbody2D.velocity connection
    public Vector2 velocity
    {
        get { return rbody.velocity; }
        set { rbody.velocity = value; }
    }


    [Header("Config")]
    [Range(0, 10)]
    public float attack;
    [Range(0, 10)]
    public float decay;
    public float limit;
    public float limitOverride;

    [Header("Constants")]
    public Vector2 direction;
    public float magnitude;

    [Header("Forces")]
    public Vector2 gravity;
    public Vector2 gravityOverride;
    public Vector2 force;
    public float forceLimit;

    [Header("Walls Detection")]
    public float raycastLength = 0.25f;
    public LayerMask wallLayer;
    public Vector4 wallsColliding; // Clock style; x = up, y = right, z = down, w = left

    private float colliderRadius;

    private Rigidbody2D rbody;
    private Collider2D collidr;
    private Vector2 movement;

    // tt
    private TeaTime wallCollisionDetection;


    void Start()
    {
        // Required
        rbody = GetComponent<Rigidbody2D>();
        collidr = GetComponent<Collider2D>();


        // Rigidbody2D defaults
        rbody.interpolation = RigidbodyInterpolation2D.Interpolate; // Smooth
        rbody.gravityScale = 0; // We use our own gravity


        // Collider radius
        colliderRadius = Mathf.Max(collidr.bounds.extents.y, collidr.bounds.extents.x);


        // > Wall collision calculation
        wallCollisionDetection = this.tt().Add(0.10f, () =>
        {
            wallsColliding = GetWallsColliding(transform.position, colliderRadius, raycastLength, wallLayer);
        })
        .Repeat();
    }


    void Update()
    {
        if (!update) return;


        // Direction * magnitude
        movement = transform.TransformDirection(direction.normalized);
        movement *= magnitude;


        // Gravity + Override
        if (gravityOverride != Vector2.zero)
            movement += gravityOverride;
        else
            movement += gravity;


        // Limit + Override
        if (limitOverride != 0)
            movement = Vector2.ClampMagnitude(movement, limitOverride);
        else
            movement = Vector2.ClampMagnitude(movement, limit);


        // Unlimited force
        if (forceLimit != 0)
            movement += Vector2.ClampMagnitude(force, forceLimit);
        else
            movement += force;


        // Velocity
        rbody.velocity = Vector2.Lerp(rbody.velocity, movement, Time.deltaTime * attack);
        rbody.velocity = Vector2.Lerp(rbody.velocity, Vector2.zero, Time.deltaTime * decay);
    }


    Vector4 GetWallsColliding(Vector3 position, float radius, float rayLength, LayerMask layer)
    {
        Vector4 result = new Vector4(
            Physics2D.Raycast(position, Vector2.up, radius + rayLength, layer) ? 1 : 0,
            Physics2D.Raycast(position, Vector2.right, radius + rayLength, layer) ? 1 : 0,
            Physics2D.Raycast(position, Vector2.down, radius + rayLength, layer) ? 1 : 0,
            Physics2D.Raycast(position, Vector2.left, radius + rayLength, layer) ? 1 : 0
        );

        return result;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        wallsColliding = GetWallsColliding(transform.position, colliderRadius, raycastLength, wallLayer);
    }


    public Vector4 ForceGetWallsColliding()
    {
        return wallsColliding = GetWallsColliding(transform.position, colliderRadius, raycastLength, wallLayer);
    }


    public void Reset()
    {
        rbody.velocity = movement = Vector2.zero;
    }
}
