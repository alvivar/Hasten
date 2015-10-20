

using UnityEngine;
using System.Collections;
using System;


public static class Extensions
{
    //
    // MonoBehaviour

    public static Transform GetOrCreateTransform(this MonoBehaviour self, string name)
    {
        GameObject go = GameObject.Find(name);


        if (go == null)
            go = new GameObject(name);


        return go.transform;
    }


    //
    // transform.position

    public static Vector3 SetPosX(this Transform self, float x)
    {
        Vector3 pos = self.position;
        pos.x = x;
        self.position = pos;
        return pos;
    }

    public static Vector3 SetPosY(this Transform self, float y)
    {
        Vector3 pos = self.position;
        pos.y = y;
        self.position = pos;
        return pos;
    }

    public static Vector3 SetPosZ(this Transform self, float z)
    {
        Vector3 pos = self.position;
        pos.z = z;
        self.position = pos;
        return pos;
    }

    public static Vector3 SetPosXY(this Transform self, float x, float y)
    {
        Vector3 pos = self.position;
        pos.x = x;
        pos.y = y;
        self.position = pos;
        return pos;
    }

    public static Vector3 SetPosXYZ(this Transform self, float x, float y, float z)
    {
        Vector3 pos = self.position;
        pos.x = x;
        pos.y = y;
        pos.z = z;
        self.position = pos;
        return pos;
    }


    //
    // transform.localScale

    public static Vector3 SetScaleX(this Transform self, float x)
    {
        Vector3 scale = self.localScale;
        scale.x = x;
        self.localScale = scale;
        return scale;
    }

    public static Vector3 SetScaleY(this Transform self, float y)
    {
        Vector3 scale = self.localScale;
        scale.y = y;
        self.localScale = scale;
        return scale;
    }

    public static Vector3 SetScaleZ(this Transform self, float z)
    {
        Vector3 scale = self.localScale;
        scale.z = z;
        self.localScale = scale;
        return scale;
    }

    public static Vector3 SetScaleXY(this Transform self, float x, float y)
    {
        Vector3 scale = self.localScale;
        scale.x = x;
        scale.y = y;
        self.localScale = scale;
        return scale;
    }

    public static Vector3 SetScaleXYZ(this Transform self, float x, float y, float z)
    {
        Vector3 scale = self.localScale;
        scale.x = x;
        scale.y = y;
        scale.z = z;
        self.localScale = scale;
        return scale;
    }


    //
    // LayerMask

    public static bool IsInside(this LayerMask self, int layer)
    {
        layer = 1 << layer;

        if ((self.value & layer) > 0)
            return true;

        return false;
    }


    //
    // TrailRenderer

    public static void Reset(this TrailRenderer trail, MonoBehaviour instance)
    {
        instance.StartCoroutine(ResetTrailRenderer(trail));
    }

    private static IEnumerator ResetTrailRenderer(TrailRenderer trail)
    {
        trail.time = -Mathf.Abs(trail.time);
        yield return null;
        trail.time = Mathf.Abs(trail.time);
    }
}
