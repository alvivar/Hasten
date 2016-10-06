
// Found here
// http://answers.unity3d.com/questions/15225/how-do-i-remove-null-components-ie-missingmono-scr.html

// 2016/09/25 04:42 PM


#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class MissingScripts : UnityEditor.Editor
{
    [MenuItem("Tools/Missing Scripts/Select All")]
    static void SelectAllMissingScriptsOnChildren()
    {
        var allTrans = FindObjectsOfType<Transform>();
        var toSelect = new List<GameObject>();
        var parents = new List<Transform>();

        foreach (Transform t in allTrans)
        {
            // Collect nulls
            Component[] cs = t.gameObject.GetComponents<Component>();
            foreach (Component c in cs)
            {
                if (c == null)
                {
                    toSelect.Add(t.gameObject);

                    // Collect parents from nulls
                    if (t.parent != null && !parents.Contains(t.parent))
                        parents.Add(t.parent);
                }
            }
        }

        // Exclude parents
        Selection.objects = toSelect.Where(x => !parents.Contains(x.transform)).ToArray();
    }


    // This works, but Unity freezes after using it :( I keep it because it's
    // interesting.

    // [MenuItem("Tools/Missing Scripts/Clean Up Selected")]
    static void CleanUpSelectedMissingScripts()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            var gameObject = Selection.gameObjects[i];

            // We must use the GetComponents array to actually detect missing components
            var components = gameObject.GetComponents<Component>();

            // Create a serialized object so that we can edit the component list
            var serializedObject = new SerializedObject(gameObject);
            // Find the component list property
            var prop = serializedObject.FindProperty("m_Component");

            // Track how many components we've removed
            int r = 0;

            // Iterate over all components
            for (int j = 0; j < components.Length; j++)
            {
                // Check if the ref is null
                if (components[j] == null)
                {
                    // If so, remove from the serialized component array
                    prop.DeleteArrayElementAtIndex(j - r);
                    // Increment removed count
                    r++;
                }
            }

            // Apply our changes to the game object
            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif
