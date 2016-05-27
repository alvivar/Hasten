
// Found here
// http://answers.unity3d.com/questions/1172687/use-shortcut-other-than-ctrlp-for-play.html

// 2016/05/09 08:10 PM


#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class UnityExtendedShortKeys : ScriptableObject
{
    [MenuItem("HotKey/Run _F5")]
    static void PlayGame()
    {
        EditorApplication.ExecuteMenuItem("Edit/Play");
    }
}
#endif
