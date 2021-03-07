// This is basically a mouse cursor that looks at certain rotation towards an
// origin.

// 2015/07/16 12:26 PM

using UnityEngine;

public class Cursor2D : MonoBehaviour
{
    [Header("Config")]
    public float zLayer = 0;
    public bool rotateUponOrigin = false;

    [Header("Required")]
    public Transform origin;

    public Vector3 position2D
    {
        get
        {
            var pos = transform.position;
            pos.z = 0;
            return pos;
        }
    }

    private static Cursor2D instance;
    public static Cursor2D Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Cursor2D>();
            return instance;
        }
    }

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

        // Don't go out of screen.
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