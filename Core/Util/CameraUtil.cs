
// Camera stuff.

// Andrés Villalobos ~ andresalvivar@gmail.com ~ twitter.com/matnesis
// 2016/03/14 09:51 PM


using UnityEngine;

public class CameraUtil
{
    public static Vector2 GetWidthHeight2DScale(Camera camera)
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector2(width, height);
    }
}
