
// Rotates an object to certain direction! xD

// @matnesis
// 2016/11/28 03:15 PM


using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 direction;


    void Update()
    {
        transform.Rotate(direction * Time.deltaTime);
    }
}
