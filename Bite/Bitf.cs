using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class Bitf
{
    public static int Int(string str, int or)
    {
        int n;
        return int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out n) ? n : or;
    }

    public static float Float(string str, float or)
    {
        float n;
        return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out n) ? n : or;
    }

    public static long Long(string str, long or)
    {
        long n;
        return long.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out n) ? n : or;
    }

    public static string Str(float f, int precision)
    {
        precision = (int) Mathf.Pow(10, precision);

        var intf = (int) f;
        var decf = (int) Mathf.Abs((f - intf) * precision);

        if (decf == 0)
            return $"{intf}";

        return $"{intf}.{decf}";
    }

    public static string Str(Vector3 vec, int precision)
    {
        var x = Str(vec.x, precision);
        var y = Str(vec.y, precision);
        var z = Str(vec.z, precision);

        return $"{x},{y},{z}";
    }

    public static string Str(Quaternion q, int precision)
    {
        var x = Str(q.x, precision);
        var y = Str(q.y, precision);
        var z = Str(q.z, precision);
        var w = Str(q.w, precision);

        return $"{x},{y},{z},{w}";
    }

    public static Vector3 Vec3(string str)
    {
        var xyz = str.Split(',');
        var vec = new Vector3(
            Float(xyz[0], -1),
            Float(xyz[1], -1),
            Float(xyz[2], -1));

        return vec;
    }

    public static Vector4 Vec4(string str)
    {
        var xyz = str.Split(',');
        var vec = new Vector4(
            Float(xyz[0], -1),
            Float(xyz[1], -1),
            Float(xyz[2], -1),
            Float(xyz[3], -1));

        return vec;
    }

    public static float Round(float f, int precision)
    {
        precision = (int) Mathf.Pow(10, precision);

        return Mathf.Round(f * precision) / precision;
    }

    public static float[] Floats(string str)
    {
        var numbers = new List<float>();

        foreach (var s in str.Split(' ', ','))
        {
            float n;
            if (float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out n))
                numbers.Add(n);
        }

        return numbers.ToArray();
    }
}