
// Selector v0.1
// A helper to select GameObjects on the Editor.

// @matnesis
// 2016/10/02 02:30 PM


#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class Selector : UnityEditor.Editor
{
    // @
    // MENU


    [MenuItem("Tools/Selector/+ All Children")]
    static void SelectAllChildren()
    {
        var allChildren = new List<Transform>();
        foreach (var t in Selection.transforms)
        {
            allChildren.AddRange(t.GetComponentsInChildren<Transform>());
        }

        Selection.objects = allChildren.Select(x => x.gameObject).ToArray();
    }


    [MenuItem("Tools/Selector/+ All With Similar Name And Parent Structure")]
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


    // @
    // MISC


    static string OnlyLetters(string word)
    {
        return new string(word.Where(x => char.IsLetter(x)).ToArray()).Trim();
    }


    static bool SameParentsName(Transform one, Transform two)
    {
        // Test for the the same parents
        while (true)
        {
            // Until they don't have parents
            if (one.parent == null || two.parent == null)
            {
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
}

#endif
