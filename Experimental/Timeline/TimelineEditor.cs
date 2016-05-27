
// @matnesis
// 2016/05/13 05:36 PM


#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Timeline))]
public class TimelineEditor : Editor
{
    Timeline transformData;
    int selectedMarker = 0;
    Vector3 selectedPos;
    Vector3 selectedRot;
    Vector3 selectedScale;

    string message = "";
    char[] spinner = { '/', '-', '\\', '|' };
    int spinnerId = 0;



    void OnEnable()
    {
        if (Application.isPlaying) return;


        transformData = target as Timeline;
        message = "";
    }


    void OnDisable()
    {
        if (Application.isPlaying) return;


        // Let's go to the first one at the end to avoid a wrong auto save
        if (transformData && transformData.positions.Count < 1) return;

        selectedMarker = 0;
        SyncSelectedWithMarker();

        transformData.transform.position = selectedPos;
        transformData.transform.eulerAngles = selectedRot;
        transformData.transform.localScale = selectedScale;
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (Application.isPlaying) return;


        // Title
        GUILayout.Label("");
        EditorGUILayout.LabelField("Timeline " + message, EditorStyles.boldLabel);


        // Auto Update
        if (transformData.positions.Count > 0 && IsAutoUpdateNeeded())
        {
            transformData.positions[selectedMarker] = transformData.transform.position;
            transformData.rotations[selectedMarker] = transformData.transform.eulerAngles;
            transformData.scales[selectedMarker] = transformData.transform.localScale;

            message = spinner[spinnerId++] + "";
            spinnerId %= spinner.Length;
        }


        // ~
        // Cycle

        // Back
        GUILayout.BeginHorizontal();
        if (transformData.positions.Count > 0 && GUILayout.Button("<~", GUILayout.ExpandWidth(false)))
        {
            selectedMarker -= 1;
            SyncSelectedWithMarker();

            // Update
            transformData.transform.position = selectedPos;
            transformData.transform.eulerAngles = selectedRot;
            transformData.transform.localScale = selectedScale;

            message = "";
        }

        // Next
        if (transformData.positions.Count > 0 && GUILayout.Button("~>", GUILayout.ExpandWidth(false)))
        {
            selectedMarker += 1;
            SyncSelectedWithMarker();

            // Update
            transformData.transform.position = selectedPos;
            transformData.transform.eulerAngles = selectedRot;
            transformData.transform.localScale = selectedScale;

            message = "";
        }

        // Marker info
        if (transformData.positions.Count < 1) GUILayout.Label("Empty.");
        else GUILayout.Label((selectedMarker + 1) + " of " + transformData.positions.Count);
        GUILayout.EndHorizontal();


        // ~
        // Index buttons
        GUILayout.BeginHorizontal();
        for (int i = 0, len = transformData.positions.Count; i < len; i++)
        {
            // A button that works as index
            string buttonName = selectedMarker == i ? "~" + (i + 1) + "~" : (i + 1) + "";
            if (GUILayout.Button(buttonName, GUILayout.ExpandWidth(false)))
            {
                selectedMarker = i;
                SyncSelectedWithMarker();

                // Update
                transformData.transform.position = selectedPos;
                transformData.transform.eulerAngles = selectedRot;
                transformData.transform.localScale = selectedScale;

                message = "";
            }
        }
        GUILayout.EndHorizontal();


        // ~
        // Edition

        // Add
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Clone+", GUILayout.ExpandWidth(false)))
        {
            selectedMarker += 1;
            if (transformData.positions.Count < 1) selectedMarker = 0; // First

            // Insertion
            transformData.positions.Insert(selectedMarker, transformData.transform.position);
            transformData.rotations.Insert(selectedMarker, transformData.transform.eulerAngles);
            transformData.scales.Insert(selectedMarker, transformData.transform.localScale);

            SyncSelectedWithMarker();

            message = "";
        }

        // Delete
        if (transformData.positions.Count > 0 && GUILayout.Button("Delete?", GUILayout.ExpandWidth(false)))
        {
            // Remove
            transformData.positions.RemoveAt(selectedMarker);
            transformData.rotations.RemoveAt(selectedMarker);
            transformData.scales.RemoveAt(selectedMarker);

            selectedMarker -= 1;
            SyncSelectedWithMarker();

            // Replace with the new
            transformData.transform.position = selectedPos;
            transformData.transform.eulerAngles = selectedRot;
            transformData.transform.localScale = selectedScale;

            message = "";
        }
        GUILayout.EndHorizontal();


        // Credits
        GUILayout.Label("");
        GUILayout.Label("Timeline v0.1b by @matnesis");
    }


    void SyncSelectedWithMarker()
    {
        // Only with items
        if (!transformData || transformData.positions.Count < 1)
        {
            selectedMarker = 0;
            return;
        }

        // Limits
        selectedMarker = selectedMarker % transformData.positions.Count;
        selectedMarker = selectedMarker < 0 ? transformData.positions.Count - 1 : selectedMarker;

        // Selected +1
        selectedPos = transformData.positions[selectedMarker];
        selectedRot = transformData.rotations[selectedMarker];
        selectedScale = transformData.scales[selectedMarker];
    }


    bool IsAutoUpdateNeeded()
    {
        return
            transformData.transform.position != transformData.positions[selectedMarker] ||
            transformData.transform.eulerAngles != transformData.rotations[selectedMarker] ||
            transformData.transform.localScale != transformData.scales[selectedMarker];
    }
}
#endif
