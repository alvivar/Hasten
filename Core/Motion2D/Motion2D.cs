
// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 10:13:43 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Motion2D : MonoBehaviour
{
	// Connetion to Rigidbody2D.velocity
	public Vector2 velocity
	{
		get
		{
			return rbody.velocity;
		}
		set
		{
			rbody.velocity = value;
		}
	}

	[Header("Config")]
	[Range(0, 10)] public float attack;
	[Range(0, 10)] public float decay;
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

	[Header("Walls")]
	public LayerMask wallLayer;
	public Vector4 wallsColliding; // Clock style; x = up, y = right, z = down, w = left


	private Rigidbody2D rbody;
	private Collider2D collider;
	private Vector2 movement;
	private float raylen;


	void Start()
	{
		// Required
		rbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();


		// Rigidbody2D defaults
		rbody.interpolation = RigidbodyInterpolation2D.Interpolate; // Smooth
		rbody.gravityScale = 0; // We use our own gravity


		// Raycast length recommended
		raylen = Mathf.Max(collider.bounds.extents.y, collider.bounds.extents.x) * 2f;


		this.tt("WallCollisionDetection").ttAdd(0.10f, () =>
		{
			CalculateWallCollision();
		})
		.ttRepeat();
	}


	void Update()
	{
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


	void CalculateWallCollision()
	{
		Vector3 pos = transform.position;

		wallsColliding.w = Physics2D.Raycast(pos, Vector2.left, raylen, wallLayer) ? 1 : 0;
		wallsColliding.y = Physics2D.Raycast(pos, Vector2.right, raylen,  wallLayer) ? 1 : 0;
		wallsColliding.x = Physics2D.Raycast(pos, Vector2.up, raylen,  wallLayer) ? 1 : 0;
		wallsColliding.z = Physics2D.Raycast(pos, Vector2.down, raylen, wallLayer) ? 1 : 0;
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		CalculateWallCollision();
	}


	void OnCollisionExit2D(Collision2D other)
	{

	}
}
