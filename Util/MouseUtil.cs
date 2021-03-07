// Mouse stuff.

// 2015/10/19 04:52 PM

using UnityEngine;

public class MouseUtil
{
    public static Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}