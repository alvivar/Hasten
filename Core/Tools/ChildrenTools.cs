
// ChildrenTools v0.2

// Useful stuff for GameObjects on the Hierarchy right click menu.

// @matnesis
// 2016/10/10 01:26 PM


#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ChildrenTools
{
    // --- S E L E C T ------


    [MenuItem("GameObject/Children Tools/Select/All Children", false, 10)]
    static void SelectAllChildren()
    {
        var allChildren = new List<Transform>();
        foreach (var t in Selection.transforms)
        {
            allChildren.AddRange(t.GetComponentsInChildren<Transform>());
        }

        Selection.objects = allChildren.Select(x => x.gameObject).ToArray();
    }


    [MenuItem("GameObject/Children Tools/Select/All Parents", false, 10)]
    static void SelectAllParents()
    {
        var allChildren = new List<Transform>();
        foreach (var t in Selection.transforms)
        {
            allChildren.AddRange(t.GetComponentsInParent<Transform>());
        }

        Selection.objects = allChildren.Select(x => x.gameObject).ToArray();
    }


    [MenuItem("GameObject/Children Tools/Select/All With Similar Name And Parent Structure", false, 10)]
    static void SelectSimilarChildren()
    {
        Transform selected = Selection.activeTransform;


        // Get a list of all parents
        var selectedParents = new List<Transform>();
        var current = selected;
        while (true)
        {
            if (current.parent)
            {
                selectedParents.Add(current.parent);
                current = current.parent;
            }
            else break;
        }


        // Get all transforms with the same name and the same parent
        var allNamed = GameObject.FindObjectsOfType<Transform>()
            .Where(
                x => OnlyLetters(x.name) == OnlyLetters(selected.name) &&
                SameParentsName(x, selected));

        Selection.objects = allNamed.Select(x => x.gameObject).ToArray();
    }


    // --- S O R T ------


    [MenuItem("GameObject/Children Tools/Sort/Children By Name", false, 10)]
    static void SortByName()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.name);

        int i = 0;
        foreach (var t in firstChildren)
            t.SetSiblingIndex(i++);
    }


    [MenuItem("GameObject/Children Tools/Sort/Children By X", false, 10)]
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


    [MenuItem("GameObject/Children Tools/Sort/Children By Y", false, 10)]
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


    [MenuItem("GameObject/Children Tools/Sort/Children By Z", false, 10)]
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


    [MenuItem("GameObject/Children Tools/Sort/Children By Magnitude", false, 10)]
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


    // --- R E L O C A T E ------


    [MenuItem("GameObject/Children Tools/Relocate/To Position 0", false, 10)]
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


    [MenuItem("GameObject/Children Tools/Relocate/To The Center Of All Children", false, 10)]
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


    // --- S N A P ------


    [MenuItem("GameObject/Children Tools/Snap/All To 0.01", false, 10)]
    static void SnapToDot01()
    {
        var all = Selection.activeTransform.GetComponentsInChildren<Transform>();

        foreach (var t in all)
            t.localPosition = Snap(t.localPosition, 0.01f);
    }


    [MenuItem("GameObject/Children Tools/Snap/All To 0.1", false, 10)]
    static void SnapToDot1()
    {
        var all = Selection.activeTransform.GetComponentsInChildren<Transform>();

        foreach (var t in all)
            t.localPosition = Snap(t.localPosition, 0.1f);
    }


    // --- R E N A M E ------


    [MenuItem("GameObject/Children Tools/Rename/Enumerate", false, 10)]
    static void RenameEnumerate()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected);

        int i = 0;
        foreach (var t in firstChildren)
        {
            var name = string.Format(
                "{0} ({1})",
                RemoveBetween(t.name, '(', ')').Trim(),
                i++);

            t.name = name;
        }
    }


    [MenuItem("GameObject/Children Tools/Rename/Enumerate By Magnitude", false, 10)]
    static void RenameEnumerateByMagnitude()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.position.sqrMagnitude);

        int i = 0;
        foreach (var t in firstChildren)
        {
            var name = string.Format(
                "{0} ({1})",
                RemoveBetween(t.name, '(', ')').Trim(),
                i++);

            t.name = name;
        }
    }


    [MenuItem("GameObject/Children Tools/Rename/Enumerate By Magnitude (And Sort)", false, 10)]
    static void RenameEnumerateByMagnitudeAndSort()
    {
        var selected = Selection.activeTransform;

        var firstChildren = selected.GetComponentsInChildren<Transform>()
            .Where(x => x.parent == selected)
            .OrderBy(x => x.position.sqrMagnitude);

        // Rename
        int i = 0;
        foreach (var t in firstChildren)
        {
            var name = string.Format(
                "{0} ({1})",
                RemoveBetween(t.name, '(', ')').Trim(),
                i++);

            t.name = name;
        }

        // Sort
        i = 0;
        foreach (var t in firstChildren)
            t.SetSiblingIndex(i++);
    }


    // --- General ------


    public static string RemoveBetween(string text, char begin, char end)
    {
        Regex re = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
        return re.Replace(text, string.Empty);
    }


    public static string OnlyLetters(string text)
    {
        return new string(text.Where(x => char.IsLetter(x)).ToArray());
    }


    public static bool SameParentsName(Transform one, Transform two)
    {
        // Test for the the same parents
        while (true)
        {
            // Until they don't have parents
            if (one.parent == null || two.parent == null)
            {
                // Equally orphans?
                if (one.parent == null && two.parent == null) return true;
                else return false;
            }

            // Let's continue when having the same parent name
            if (OnlyLetters(one.parent.name) == OnlyLetters(two.parent.name))
            {
                // Next
                one = one.parent;
                two = two.parent;
            }
            // Or we don't
            else
            {
                return false;
            }
        }
    }


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
