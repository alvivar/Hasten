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