
// Looks a target immediately.

// @matnesis
// 2017/04/13 07:12 PM


using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    public Vector3 lookOffset;


    void Update()
    {
        if (target)
        {
            transform.LookAt(target);
            transform.eulerAngles += lookOffset;
        }
    }
}
