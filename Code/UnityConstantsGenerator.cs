// Creates a file with all the Unity constants: UnityConst.cs

// Found here
// https://github.com/nickgravelyn/UnityToolbag/blob/master/UnityConstants/Editor/UnityConstantsGenerator.cs

//  2016/10/09 01:52 PM

#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public static class UnityConstantsGenerator
{
    [MenuItem("Tools/Code/Generate UnityConst.cs")]
    public static void Generate()
    {
        // Try to find an existing file in the project called "UnityConst.cs".
        string filePath = string.Empty;
        foreach (var file in Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories))
        {
            if (Path.GetFileNameWithoutExtension(file) == "UnityConst")
            {
                filePath = file;
                break;
            }
        }

        // If no such file exists already, use the save panel to get a folder in
        // which the file will be placed.
        if (string.IsNullOrEmpty(filePath))
        {
            string directory = EditorUtility.OpenFolderPanel("Choose location for UnityConst.cs", Application.dataPath, "");

            // Canceled choose? Do nothing.
            if (string.IsNullOrEmpty(directory))
            {
                return;
            }

            filePath = Path.Combine(directory, "UnityConst.cs");
        }

        // Write out our file.
        using(var writer = new StreamWriter(filePath))
        {
            writer.WriteLine();
            writer.WriteLine("// This file is auto-generated. Modifications are not saved.");
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine("namespace UnityConst");
            writer.WriteLine("{");

            // Write out the tags.
            writer.WriteLine("    public static class Tag");
            writer.WriteLine("    {");
            foreach (var tag in UnityEditorInternal.InternalEditorUtility.tags)
            {
                writer.WriteLine("        public const string {0} = \"{1}\";", MakeSafeForCode(tag), tag);
            }
            writer.WriteLine("    }");
            writer.WriteLine();
            writer.WriteLine();

            // Write out layers.
            writer.WriteLine("    public static class Layer");
            writer.WriteLine("    {");
            for (int i = 0; i < 32; i++)
            {
                string layer = UnityEditorInternal.InternalEditorUtility.GetLayerName(i);
                if (!string.IsNullOrEmpty(layer))
                {
                    writer.WriteLine("        public const int {0} = {1};", MakeSafeForCode(layer), i);
                }
            }
            writer.WriteLine();
            for (int i = 0; i < 32; i++)
            {
                string layer = UnityEditorInternal.InternalEditorUtility.GetLayerName(i);
                if (!string.IsNullOrEmpty(layer))
                {
                    writer.WriteLine("        public const int {0}Mask = 1 << {1};", MakeSafeForCode(layer), i);
                }
            }
            writer.WriteLine("    }");
            writer.WriteLine();
            writer.WriteLine();

            // Write out sorting layers.
            writer.WriteLine("    public static class SortingLayer");
            writer.WriteLine("    {");
            foreach (var layer in SortingLayer.layers)
            {
                writer.WriteLine("        public const int {0} = {1};", MakeSafeForCode(layer.name), layer.id);
            }
            writer.WriteLine("    }");
            writer.WriteLine();
            writer.WriteLine();

            // Write out scenes.
            writer.WriteLine("    public static class Scene");
            writer.WriteLine("    {");
            int sceneIndex = 0;
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled)
                {
                    continue;
                }

                var sceneName = Path.GetFileNameWithoutExtension(scene.path);

                writer.WriteLine("        public const int {0} = {1};", MakeSafeForCode(sceneName), sceneIndex);

                sceneIndex++;
            }
            writer.WriteLine("    }");
            writer.WriteLine();
            writer.WriteLine();

            // Write out Input axes.
            writer.WriteLine("    public static class Axe");
            writer.WriteLine("    {");
            var axes = new HashSet<string>();
            var inputManagerProp = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset") [0]);
            foreach (SerializedProperty axe in inputManagerProp.FindProperty("m_Axes"))
            {
                var name = axe.FindPropertyRelative("m_Name").stringValue;
                var variableName = MakeSafeForCode(name);
                if (!axes.Contains(variableName))
                {
                    writer.WriteLine("        public const string {0} = \"{1}\";", variableName, name);
                    axes.Add(variableName);
                }
            }
            writer.WriteLine("    }");

            // End of namespace UnityConst.
            writer.WriteLine("}");
        }

        // Refresh.
        AssetDatabase.Refresh();
    }

    private static string MakeSafeForCode(string text)
    {
        text = Regex.Replace(text, "[^a-zA-Z0-9_]", "_", RegexOptions.None);
        if (char.IsDigit(text[0])) text = "_" + text;

        return text;
    }
}

#endif