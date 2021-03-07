// Useful Vector stuff.

// 2016/01/01 11:36 PM

using UnityEngine;

public static class VectorUtil
{
    // Returns a Vector3 only with the strongest direction at 1.
    public static Vector3 RawDirection(Vector3 dir)
    {
        dir.x = Mathf.Abs(dir.x) > Mathf.Abs(dir.y) ? dir.x : 0;
        dir.x = Mathf.Abs(dir.x) > Mathf.Abs(dir.z) ? dir.x : 0;

        dir.y = Mathf.Abs(dir.y) > Mathf.Abs(dir.x) ? dir.y : 0;
        dir.y = Mathf.Abs(dir.y) > Mathf.Abs(dir.z) ? dir.y : 0;

        dir.z = Mathf.Abs(dir.z) > Mathf.Abs(dir.y) ? dir.z : 0;
        dir.z = Mathf.Abs(dir.z) > Mathf.Abs(dir.x) ? dir.z : 0;

        return (dir * 10).normalized;
    }
}