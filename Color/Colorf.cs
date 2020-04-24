using UnityEngine;

public static class Colorf
{
    public static Color ColorAlpha(Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }
}