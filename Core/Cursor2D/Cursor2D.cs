
// This is basically a mouse cursor that looks at certain rotation towards an
// origin.

// andresalvivar@gmail.com | twitter.com/matnesis
// 2015/07/16 12:26 PM


using UnityEngine;

public class Cursor2D : MonoBehaviour
{
    [Header("Config")]
    public float zLayer = -9;
    public bool rotateUponOrigin = false;

    [Header("Required")]
    public Transform origin;


    void Awake()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        Vector3 mousepos = MouseUtil.GetMousePosition();
        mousepos.z = zLayer;

        transform.position = mousepos;


        if (rotateUponOrigin)
        {
            Vector3 source = mousepos - origin.position;
            float angle = Mathf.Atan2(source.y, source.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        // Don't go out of screen

        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));

        var cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
            Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax),
            transform.position.z);
    }
}
