
// Useful stuff for nested stuff.

// @matnesis
// 2016/10/10 01:26 PM


#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Linq;

public class ChildrenTools
{
    [MenuItem("Tools/Children/Sort/By X")]
    static void SortByX()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.position.x);

        int i = 0;
        foreach (var t in firstChildren)
            t.SetSiblingIndex(i++);
    }


    [MenuItem("Tools/Children/Sort/By Y")]
    static void SortByY()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.position.y);

        int i = 0;
        foreach (var t in firstChildren)
            t.SetSiblingIndex(i++);
    }


    [MenuItem("Tools/Children/Sort/By Z")]
    static void SortByZ()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.position.z);

        int i = 0;
        foreach (var t in firstChildren)
            t.SetSiblingIndex(i++);
    }


    [MenuItem("Tools/Children/Sort/By Magnitude")]
    static void SortBySqrMagnitude()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.position.sqrMagnitude);

        int i = 0;
        foreach (var t in firstChildren)
            t.SetSiblingIndex(i++);
    }


    [MenuItem("Tools/Children/Relocate/To Position 0")]
    static void RelocateToPos0()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected);


        Vector3 displacement = selected.localPosition;
        foreach (var t in firstChildren)
            t.localPosition += displacement;
        selected.localPosition = Vector3.zero;
    }


    [MenuItem("Tools/Children/Relocate/To The Center Of All Children")]
    static void RelocateToCenterOfChildren()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected);


        // Calculate the average of all positions
        Vector3 averagePos = Vector3.zero;
        foreach (var t in firstChildren)
            averagePos += t.localPosition;
        averagePos /= firstChildren.Count() + 1;

        // Center of everything
        averagePos += selected.localPosition;


        // Updating to new positions
        Vector3 displacement = selected.localPosition - averagePos;
        foreach (var t in firstChildren)
            t.localPosition += displacement;
        selected.localPosition = averagePos;
    }


    [MenuItem("Tools/Children/Snap/To 0.1")]
    static void SnapToDot1()
    {
        var all = Selection.activeTransform.GetComponentsInChildren<Transform>();

        foreach (var t in all)
            t.localPosition = Snap(t.localPosition, 0.1f);
    }


    //
    // @
    //


    public static Vector3 Snap(Vector3 vector, float size)
    {
        return new Vector3(
            Mathf.Round(vector.x / size) * size,
            Mathf.Round(vector.y / size) * size,
            Mathf.Round(vector.z / size) * size
        );
    }
}

#endif
