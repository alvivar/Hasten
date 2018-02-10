
// Andrés Villalobos | twitter.com/matnesis | andresalvivar@gmail.com
// 2017/08/12 06:50 pm


using UnityEngine;

public class SlowdownRigidbody : MonoBehaviour
{
    public float damp = 1;
    public Rigidbody2D rbody;


    void FixedUpdate()
    {
        if (rbody)
            rbody.velocity = Vector3.Lerp(rbody.velocity, Vector3.zero, Time.deltaTime * damp);
    }
}
