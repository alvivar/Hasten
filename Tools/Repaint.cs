// Repaint changes the color of all SpriteRenderer for the current GameObject
// and children.

// 2015/08/11 09:15 PM

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class Repaint : MonoBehaviour
{
    public Color color = Color.clear;
    public int orderInLayer = 0;
    public bool apply = false;
    public bool reload = false;
    public Vector4 colorData = Vector4.zero;
    public bool cleanPallete = false;
    public List<Color> pallete = null;
    public int quantity = 0;

    private Color lastColor = Color.clear;
    private SpriteRenderer[] children = null;
    private static Dictionary<Repaint, Color> globalPallete = null;

    void Update()
    {
        // Always load the color at first
        if (children == null || children.Length < 1)
            reload = true;

        // Autodetect color change
        if (lastColor != color)
            apply = true;
        lastColor = color;

        // Force color change
        if (apply == true)
        {
            apply = false;

            color = EqualizeColor(color);

            children = GetComponentsInChildren<SpriteRenderer>();
            quantity = children.Length;

            for (int i = 0; i < quantity; i++)
            {
                children[i].color = color;
                children[i].sortingOrder = orderInLayer;
            }

            SyncWithGlobalPallete();
        }

        // Get a common color
        if (reload == true)
        {
            reload = false;

            Color currentColor = Color.clear;
            int layer = 0;

            children = GetComponentsInChildren<SpriteRenderer>();
            quantity = children.Length;

            for (int i = 0; i < quantity; i++)
            {
                currentColor += children[i].color;
                layer += children[i].sortingOrder;
            }

            if (quantity != 0)
            {
                currentColor /= quantity;
                layer /= quantity;
            }

            color = EqualizeColor(currentColor);
            orderInLayer = layer;

            SyncWithGlobalPallete();
        }

        // Clean all the pallete
        if (cleanPallete == true)
        {
            cleanPallete = false;
            globalPallete = new Dictionary<Repaint, Color>();
            globalPallete[this] = color;
            SyncWithGlobalPallete();
        }
    }

    Color EqualizeColor(Color color)
    {
        color.r = Mathf.Round(color.r * 100f) / 100f;
        color.g = Mathf.Round(color.g * 100f) / 100f;
        color.b = Mathf.Round(color.b * 100f) / 100f;

        return color;
    }

    void SyncWithGlobalPallete()
    {
        // True color
        colorData.x = color.r;
        colorData.y = color.g;
        colorData.z = color.b;
        colorData.w = color.a;

        // Global pallete sync
        if (globalPallete == null)
            globalPallete = new Dictionary<Repaint, Color>();
        globalPallete[this] = color;

        // Pure pallete
        pallete.Clear();
        foreach (KeyValuePair<Repaint, Color> gc in globalPallete)
        {
            if (pallete.Any(c => c.r == gc.Value.r && c.g == gc.Value.g && c.b == gc.Value.b && c.a == gc.Value.a) == false)
                pallete.Add(gc.Value);
        }
    }
}