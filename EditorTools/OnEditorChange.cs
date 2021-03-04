// #if UNITY_EDITOR

// using UnityEditor;
// using UnityEditor.SceneManagement;
// using UnityEngine;

// @todo Cool, but need some work.

// // Original script, found at
// // https://stackoverflow.com/questions/35586103/unity3d-load-a-specific-scene-on-play-mode

// [InitializeOnLoadAttribute]
// public static class DefaultSceneLoader
// {
//     static DefaultSceneLoader()
//     {
//         EditorApplication.playModeStateChanged += LoadDefaultScene;
//     }

//     static void LoadDefaultScene(PlayModeStateChange state)
//     {
//         if (state == PlayModeStateChange.ExitingEditMode)
//         {
//             EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
//             Debug.Log($"PlayModeStateChange.ExitingEditMode at {Time.time}");
//         }

//         if (state == PlayModeStateChange.EnteredPlayMode)
//         {
//             EditorSceneManager.LoadScene(0);
//             Debug.Log($"PlayModeStateChange.EnteredPlayMode at {Time.time}");
//         }
//     }
// }

// #endif