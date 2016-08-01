
// @matnesis
// 2016/05/13 05:36 PM


#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Timeline))]
public class TimelineEditor : Editor
{
    Timeline timeline;

    int timelineIndex = 0;
    Vector3 timelinePos;
    Vector3 timelineRot;
    Vector3 timelineSca;

    int childrenIndex = 0;

    string message = "";
    char[] spinner = { '/', '-', '\\', '|' };
    int spinnerId = 0;


    void OnEnable()
    {
        if (Application.isPlaying) return;


        timeline = target as Timeline;
        message = "";
    }


    void OnDisable()
    {
        if (Application.isPlaying) return;


        // Let's go to the first one at the end to avoid a wrong auto save
        if (timeline && timeline.positions.Count < 1) return;

        timelineIndex = 0;
        SyncSelectedWithMarker();

        timeline.transform.position = timelinePos;
        timeline.transform.eulerAngles = timelineRot;
        timeline.transform.localScale = timelineSca;
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (Application.isPlaying) return;


        // Title
        GUILayout.Label("");
        EditorGUILayout.LabelField("Timeline " + message, EditorStyles.boldLabel);


        // Auto Update
        if (timeline.positions.Count > 0 && IsAutoUpdateNeeded())
        {
            timeline.positions[timelineIndex] = timeline.transform.position;
            timeline.rotations[timelineIndex] = timeline.transform.eulerAngles;
            timeline.scales[timelineIndex] = timeline.transform.localScale;

            message = spinner[spinnerId++] + "";
            spinnerId %= spinner.Length;
        }


        // ~
        // Cycle

        // Back
        GUILayout.BeginHorizontal();
        if (timeline.positions.Count > 0 && GUILayout.Button("<~", GUILayout.ExpandWidth(false)))
        {
            timelineIndex -= 1;
            SyncSelectedWithMarker();

            // Update
            timeline.transform.position = timelinePos;
            timeline.transform.eulerAngles = timelineRot;
            timeline.transform.localScale = timelineSca;

            message = "";
        }

        // Next
        if (timeline.positions.Count > 0 && GUILayout.Button("~>", GUILayout.ExpandWidth(false)))
        {
            timelineIndex += 1;
            SyncSelectedWithMarker();

            // Update
            timeline.transform.position = timelinePos;
            timeline.transform.eulerAngles = timelineRot;
            timeline.transform.localScale = timelineSca;

            message = "";
        }

        // Marker info
        if (timeline.positions.Count < 1) GUILayout.Label("Empty.");
        else GUILayout.Label((timelineIndex + 1) + " of " + timeline.positions.Count);
        GUILayout.EndHorizontal();


        // ~
        // Index buttons
        GUILayout.BeginHorizontal();
        for (int i = 0, len = timeline.positions.Count; i < len; i++)
        {
            // A button that works as index
            string buttonName = timelineIndex == i ? "~" + (i + 1) + "~" : (i + 1) + "";
            if (GUILayout.Button(buttonName, GUILayout.ExpandWidth(false)))
            {
                timelineIndex = i;
                SyncSelectedWithMarker();

                // Update
                timeline.transform.position = timelinePos;
                timeline.transform.eulerAngles = timelineRot;
                timeline.transform.localScale = timelineSca;

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
            timelineIndex += 1;
            if (timeline.positions.Count < 1) timelineIndex = 0; // First

            // Insertion
            timeline.positions.Insert(timelineIndex, timeline.transform.position);
            timeline.rotations.Insert(timelineIndex, timeline.transform.eulerAngles);
            timeline.scales.Insert(timelineIndex, timeline.transform.localScale);

            SyncSelectedWithMarker();

            message = "";
        }

        // Delete
        if (timeline.positions.Count > 0 && GUILayout.Button("Delete?", GUILayout.ExpandWidth(false)))
        {
            // Remove
            timeline.positions.RemoveAt(timelineIndex);
            timeline.rotations.RemoveAt(timelineIndex);
            timeline.scales.RemoveAt(timelineIndex);

            timelineIndex -= 1;
            SyncSelectedWithMarker();

            // Replace with the new
            timeline.transform.position = timelinePos;
            timeline.transform.eulerAngles = timelineRot;
            timeline.transform.localScale = timelineSca;

            message = "";
        }
        GUILayout.EndHorizontal();


        // // ^^
        // // SNAPSHOT


        // // Title
        // GUILayout.Label("");
        // EditorGUILayout.LabelField("Snapshot System " + message, EditorStyles.boldLabel);


        // // ^
        // // Edition

        // // Add
        // GUILayout.BeginHorizontal();
        // if (GUILayout.Button("Snapshot +", GUILayout.ExpandWidth(false)))
        // {
        //     timeline.AddSnapshot();

        //     message = "";
        // }

        // // Delete
        // if (timeline.positions.Count > 0 && GUILayout.Button("Delete?", GUILayout.ExpandWidth(false)))
        // {


        //     message = "";
        // }
        // GUILayout.EndHorizontal();


        // // ^
        // // Index buttons
        // GUILayout.BeginHorizontal();
        // for (int i = 0, len = timeline.childrenData.Count; i < len; i++)
        // {
        //     // A button that works as index
        //     string buttonName = childrenIndex == i ? "~" + (i + 1) + "~" : (i + 1) + "";
        //     if (GUILayout.Button(buttonName, GUILayout.ExpandWidth(false)))
        //     {
        //         childrenIndex = i;

        //         message = "";
        //     }
        // }
        // GUILayout.EndHorizontal();


        // Credits
        GUILayout.Label("");
        GUILayout.Label("Timeline v0.1b by @matnesis");
    }


    void SyncSelectedWithMarker()
    {
        // Only with items
        if (!timeline || timeline.positions.Count < 1)
        {
            timelineIndex = 0;
            return;
        }

        // Limits
        timelineIndex = timelineIndex % timeline.positions.Count;
        timelineIndex = timelineIndex < 0 ? timeline.positions.Count - 1 : timelineIndex;

        // Selected +1
        timelinePos = timeline.positions[timelineIndex];
        timelineRot = timeline.rotations[timelineIndex];
        timelineSca = timeline.scales[timelineIndex];
    }


    bool IsAutoUpdateNeeded()
    {
        return
            timeline.transform.position != timeline.positions[timelineIndex] ||
            timeline.transform.eulerAngles != timeline.rotations[timelineIndex] ||
            timeline.transform.localScale != timeline.scales[timelineIndex];
    }
}
#endif
