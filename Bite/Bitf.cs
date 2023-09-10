using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

// Utilities to cast bytes.
public static class Bitf
{
    public static int Int(string str, int or = 0)
    {
        return int.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out int n) ? n : or;
    }

    public static int Int(byte[] bigEndian, int or = 0)
    {
        if (bigEndian.Length < 4)
            return or;

        bigEndian = SubArray(bigEndian, 0, 4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bigEndian);

        return BitConverter.ToInt32(bigEndian, 0);
    }

    public static float Float(string str, float or = 0)
    {
        return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out float n) ? n : or;
    }

    public static long Long(string str, long or = 0)
    {
        return long.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out long n) ? n : or;
    }

    public static long Long(byte[] bigEndian, long or = 0)
    {
        if (bigEndian.Length < 8)
            return or;

        bigEndian = SubArray(bigEndian, 0, 8);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bigEndian);

        return BitConverter.ToInt64(bigEndian, 0);
    }

    public static string Str(float f, int precision)
    {
        precision = (int)Mathf.Pow(10, precision);

        var intf = (int)f;
        var decf = (int)Mathf.Abs((f - intf) * precision);

        if (decf == 0)
            return $"{intf}";

        return $"{intf}.{decf}";
    }

    public static string Str(byte[] f)
    {
        return System.Text.Encoding.UTF8.GetString(f, 0, f.Length);
    }

    public static float Round(float f, int precision)
    {
        precision = (int)Mathf.Pow(10, precision);

        return Mathf.Round(f * precision) / precision;
    }

    public static float[] Floats(string str)
    {
        var numbers = new List<float>();

        foreach (var s in str.Split(' ', ','))
        {
            if (float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out float n))
                numbers.Add(n);
        }

        return numbers.ToArray();
    }

    public static string Vector2(Vector3 vector)
    {
        var sx = vector.x < 0 ? "-" : "";
        var sy = vector.y < 0 ? "-" : "";

        var nx = (int)Mathf.Abs(vector.x);
        var ny = (int)Mathf.Abs(vector.y);

        var dx = (int)Mathf.Abs((vector.x - nx) * 1000);
        var dy = (int)Mathf.Abs((vector.y - ny) * 1000);

        var tdx = $".{dx}".TrimEnd('0').TrimEnd('.');
        var tdy = $".{dy}".TrimEnd('0').TrimEnd('.');

        return $"{sx}{nx}{tdx},{sy}{ny}{tdy}";
    }

    public static Vector3 Vector3(string str)
    {
        var numbers = new List<float>();

        foreach (var s in str.Split(' ', ','))
        {
            if (float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out float n))
                numbers.Add(n);
        }

        if (numbers.Count < 1)
            return new Vector3(0, 0, 0);

        if (numbers.Count < 2)
            return new Vector3(numbers[0], 0, 0);

        if (numbers.Count < 3)
            return new Vector3(numbers[0], numbers[1], 0);

        return new Vector3(numbers[0], numbers[1], numbers[2]);
    }

    private static T[] SubArray<T>(this T[] data, int index, int length)
    {
        T[] result = new T[length];
        Array.Copy(data, index, result, 0, length);

        return result;
    }
}
