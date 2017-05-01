
// Translates an object to certain direction! xD

// @matnesis
// 2016/11/28 03:15 PM


using UnityEngine;

public class Translate : MonoBehaviour
{
    public Vector3 direction;


    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
