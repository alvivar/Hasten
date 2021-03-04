#if UNITY_EDITOR

using UnityEditor;

public static class PlayTools
{
    [MenuItem("Game/Play")]
    public static void Play()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Game/Scenes/Multiplayer/01-Lobby.unity");
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Game/Dev")]
    public static void Dev()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Game/Scenes/Multiplayer/02-City.unity");
    }
}

#endif