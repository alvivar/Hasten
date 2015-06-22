#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(PosData))]
public class PosDataEditor : Editor
{
    private PosData transformData;
    private int selectedPosMarker = 0;
    private Vector3 selectedPos;


    void OnEnable()
    {
        transformData = target as PosData;
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        // Aggregation
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save", GUILayout.ExpandWidth(false)))
        {
            Vector3 posToSave = transformData.transform.position;
            if (transformData.all.Contains(posToSave) == false)
            {
                transformData.all.Add(transformData.transform.position);
                selectedPosMarker = transformData.all.Count - 1;
                SyncSelectedPosWithMarker();
            }
        }


        if (transformData.all.Count > 0 && GUILayout.Button("Delete", GUILayout.ExpandWidth(false)))
        {
            transformData.all.RemoveAt(selectedPosMarker);
            selectedPosMarker -= 1;
            SyncSelectedPosWithMarker();
            transformData.transform.position = selectedPos;
        }
        GUILayout.EndHorizontal();


        // Cycle
        GUILayout.BeginHorizontal();
        if (transformData.all.Count > 0 && GUILayout.Button("<<<", GUILayout.ExpandWidth(false)))
        {
            selectedPosMarker -= 1;
            SyncSelectedPosWithMarker();
            transformData.transform.position = selectedPos;
        }

        if (transformData.all.Count > 0 && GUILayout.Button(">>>", GUILayout.ExpandWidth(false)))
        {
            selectedPosMarker += 1;
            SyncSelectedPosWithMarker();
            transformData.transform.position = selectedPos;
        }


        // Marker info
        if (transformData.all.Count < 1)
            GUILayout.Label("Empty.");
        else
            GUILayout.Label("Slot " + (selectedPosMarker + 1) + " of " + transformData.all.Count);
        GUILayout.EndHorizontal();
    }


    void SyncSelectedPosWithMarker()
    {
        // Only with items
        if (transformData.all.Count < 1)
        {
            selectedPosMarker = 0;
            transformData.selectedPos = "";
            return;
        }

        // Limits
        selectedPosMarker = selectedPosMarker % transformData.all.Count;
        selectedPosMarker = selectedPosMarker < 0 ? transformData.all.Count - 1 : selectedPosMarker;

        // Selected pos
        selectedPos = transformData.all[selectedPosMarker];
        transformData.selectedPos = selectedPos.x + ", " + selectedPos.y + ", " + selectedPos.z;
    }
}
#endif
