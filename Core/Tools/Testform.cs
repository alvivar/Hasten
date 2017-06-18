
// @matnesis
// 2017/05/27 11:57 PM


using UnityEngine;

public class Testform : MonoBehaviour
{
    private static Transform sphere1;
    public static Transform Sphere1
    {
        get
        {
            sphere1 = !sphere1 ? GameObject.CreatePrimitive(PrimitiveType.Sphere).transform : sphere1;
            sphere1.GetComponent<Collider>().enabled = false;
            sphere1.name = "Testform@Sphere1";
            return sphere1;
        }
    }
}