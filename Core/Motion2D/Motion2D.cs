
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
}
