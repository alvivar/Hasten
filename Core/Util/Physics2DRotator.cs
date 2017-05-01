
// Rotates an object to certain direction! xD

// @matnesis
// 2016/12/05 04:25 PM


using UnityEngine;

public class Physics2DRotator : MonoBehaviour
{
    public float speed;
    Rigidbody2D rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rbody.MoveRotation(rbody.rotation + speed * Time.fixedDeltaTime);
    }
}
