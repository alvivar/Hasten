
// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 10:13:43 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Motion2D : MonoBehaviour
{
	[Header("Config")]
	[Range(0, 10)] public float attack;
	[Range(0, 10)] public float decay;
	public float limit;

	[Header("Constants")]
	public Vector2 direction;
	public float magnitude;

	[Header("Forces")]
	public Vector2 gravity;
	public Vector2 force;

	[Header("Walls")]
	public LayerMask wallLayer;
	public Vector4 wallsColliding; // Clock style; x = up, y = right, z = down, w = left


	private Rigidbody2D rbody;
	private Collider2D collider;
	private Vector2 movement;


	void Start()
	{
		// Required
		rbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();


		// Rigidbody2D defaults
		rbody.interpolation = RigidbodyInterpolation2D.Interpolate; // Smooth
		rbody.gravityScale = 0; // We use our own gravity
	}


	void Update()
	{
		// Direction * magnitude
		movement = transform.TransformDirection(direction.normalized);
		movement *= magnitude;


		// Limited force
		movement += gravity;


		// Limit
		movement = Vector2.ClampMagnitude(movement, limit);


		// Unlimited force
		movement += force;


		// Velocity
		rbody.velocity = Vector2.Lerp(rbody.velocity, movement, Time.deltaTime * attack);
		rbody.velocity = Vector2.Lerp(rbody.velocity, Vector2.zero, Time.deltaTime * decay);
	}


	void CalculateWallCollision()
	{
		Vector3 pos = transform.position;

		wallsColliding.w = Physics2D.Raycast(pos, Vector2.left, 1, wallLayer) ? 1 : 0;
		wallsColliding.y = Physics2D.Raycast(pos, Vector2.right, 1,  wallLayer) ? 1 : 0;
		wallsColliding.x = Physics2D.Raycast(pos, Vector2.up, 1,  wallLayer) ? 1 : 0;
		wallsColliding.z = Physics2D.Raycast(pos, Vector2.down, 1, wallLayer) ? 1 : 0;

		Debug.Log(wallsColliding);
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		CalculateWallCollision();
	}


	void OnCollisionExit2D(Collision2D other)
	{
		this.tt().ttAdd(0.10f, () =>
		{
			CalculateWallCollision();
		});
	}
}
