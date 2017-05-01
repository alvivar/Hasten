
// Useful Math formulas.

// @matnesis
// 2017/03/21 08:05 PM


using UnityEngine;

public static class Mathx
{
    public static float NormalizeAngle(float angle)
    {
        while (angle < 0) angle += 360;
        while (angle > 360) angle -= 360;

        return angle;
    }


    public static Vector3 SnapVector(Vector3 vector, float size)
    {
        return new Vector3(
            Mathf.Round(vector.x / size) * size,
            Mathf.Round(vector.y / size) * size,
            Mathf.Round(vector.z / size) * size
        );
    }
}
