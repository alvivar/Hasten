﻿
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LayerSorter))]
public class LayerSorterEditor : Editor
{
	private LayerSorter ls;


	void OnEnable()
	{
		ls = target as LayerSorter;
	}


	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		GUILayout.Label("");


		// +1 to sortingOrder
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Up", GUILayout.ExpandWidth(false)))
		{
			ls.AddToSortingOrder(1);

		}

		// -1 to sortingOrder
		if (GUILayout.Button("Down", GUILayout.ExpandWidth(false)))
		{
			ls.AddToSortingOrder(-1);
		}
		GUILayout.EndHorizontal();


		GUILayout.Label("");
		GUILayout.Label("LayerSorter v0.1");
	}

}
#endif
