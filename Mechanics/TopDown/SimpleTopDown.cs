
// @matnesis
// 2017/06/17 08:19 pm


using UnityEngine;

public class SimpleTopDown : MonoBehaviour
{
    [Header("Config")]
    public Vector3 input; // Usually an axis
    public float speed = 1;
    public float speedDamp = 10;
    public Vector3 externalForce; // Dash probably

    [Header("Override")]
    public float speedOverride = 0;

    [Header("Required")]
    public Rigidbody2D rigid;


    [ContextMenu("Setup")]
    void Setup()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        // Override
        var currentSpeed = speedOverride != 0 ? speedOverride : speed;


        // Motion
        var force = input.normalized * currentSpeed;

        rigid.velocity = Vector3.Lerp(
            rigid.velocity,
            force + externalForce,
            Time.deltaTime * speedDamp
        );
    }
}
