#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

// Femto is a Unity code generator that creates the 'EntitySet.cs', a simple
// static entities database.

// Just write '// !Gigas' before any MonoBehaviour class that you consider a
// Component, and the API generated will be able to register that Component to
// any GameObject, using the GameObject as an Entity.

// To generate use the menu item 'Gigas/Generate EntitySet.cs'

// Truth
// 1. The GameObject GetInstanceID() is the Entity id.

public static class Femto
{
    [MenuItem("Gigas/Generate EntitySet.cs")]
    public static void GenerateEntitySet()
    {
        var (entitySetFile, classes) = ScanEntitySetAndFiles();

        // If no such file exists, use the save panel to select a folder to create it.
        string dir = "";
        if (string.IsNullOrEmpty(entitySetFile))
        {
            dir = EditorUtility.OpenFolderPanel("Select the location to save the EntitySet file", Application.dataPath, "");

            // Canceled?
            if (string.IsNullOrEmpty(dir))
                return;

            entitySetFile = Path.Combine(dir, "EntitySet.cs");
        }

        GenerateEntitySet(entitySetFile, classes);

        AssetDatabase.Refresh();
    }

    private static (string, List<string>) ScanEntitySetAndFiles()
    {
        string entitySetFile = "";
        List<string> classes = new List<string>();

        foreach (var file in Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories))
        {
            var onlyName = Path.GetFileNameWithoutExtension(file);

            // Ignore some special files.

            if (onlyName == "EntitySet")
            {
                entitySetFile = file; // Found!
                continue;
            }

            if (onlyName == "Femto")
                continue;

            // Look for '!commands' on each file.

            using (var fileWithGigas = new StreamReader(file))
            {
                var className = "";
                var gigasFound = false;

                string line = "";
                while ((line = fileWithGigas.ReadLine()) != null)
                {
                    // Found!
                    if (line.ToLower().Contains("!gigas"))
                        gigasFound = true;

                    // Extract the class name.
                    if (line.Contains("public class"))
                    {
                        var tokens = line.Split(' ');
                        for (var index = 0; index < tokens.Length; index++)
                        {
                            if (!tokens[index].Contains("class"))
                                continue;

                            if (index + 1 < tokens.Length)
                                className = tokens[index + 1].Trim();
                            break;
                        }

                        break;
                    }
                }

                if (gigasFound && !classes.Contains(className))
                    classes.Add(className);
            }
        }

        classes.Sort();

        return (entitySetFile, classes);
    }

    private static void GenerateEntitySet(string filePath, List<string> classes)
    {
        // Dates.
        var currentTime = DateTime.Now;
        var day = currentTime.Day;
        var dayName = currentTime.ToString("dddd");
        var monthName = currentTime.ToString("MMMM");
        var year = currentTime.Year;
        var time = currentTime.ToString("h:mm tt");

        // Write out our file.
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine();
            writer.WriteLine($"// {dayName}, {monthName} {day}, {year}");
            writer.WriteLine($"// {time}");
            writer.WriteLine();
            writer.WriteLine("// This file is auto-generated. Modifications can be overwritten.");
            writer.WriteLine();
            writer.WriteLine("// EntitySet is a static database of GameObjects (Entities) and MonoBehaviour classes (Components).");
            writer.WriteLine("// Check out 'Femto.cs' for more information about code generation.");
            writer.WriteLine();
            writer.WriteLine("// To update use the menu item 'Gigas/Generate EntitySet.cs'.");
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine("using UnityEngine;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine();
            writer.WriteLine("// namespace ?");
            writer.WriteLine("// {");

            writer.WriteLine("    public static class EntitySet");
            writer.WriteLine("    {");

            // The EntitySet API.
            for (int i = 0; i < classes.Count; i++)
            {
                var component = classes[i];
                var componentId = $"{component}Id";
                var components = $"{component}Component";
                var componentIdCache = $"{component}IdCache";
                var componentGetIds = $"{component}GetAllIds";
                var componentGetResult = $"{component}GetAllResult";

                writer.WriteLine($"        // {component}");
                writer.WriteLine();
                writer.WriteLine($"        public static Arrayx<int> {componentId} = new Arrayx<int>();");
                writer.WriteLine();
                writer.WriteLine($"        private static Arrayx<{component}> {components} = new Arrayx<{component}>();");
                writer.WriteLine($"        private static Dictionary<int, int> {componentIdCache} = new Dictionary<int, int>();");
                writer.WriteLine($"        private static Arrayx<Arrayx<int>> {componentGetIds} = new Arrayx<Arrayx<int>>();");
                writer.WriteLine($"        private static Arrayx<{component}> {componentGetResult} = new Arrayx<{component}>();");

                writer.WriteLine();
                writer.WriteLine($"        public static void Add{component}({component} component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            {componentId}.Add(component.gameObject.GetInstanceID());");
                writer.WriteLine($"            {components}.Add(component);");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static void Remove{component}({component} component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            var id = component.gameObject.GetInstanceID();");
                writer.WriteLine($"            var index = {componentId}.IndexOf(id);");
                writer.WriteLine();
                writer.WriteLine($"            {componentId}.RemoveAt(index);");
                writer.WriteLine($"            {components}.RemoveAt(index);");
                writer.WriteLine();
                writer.WriteLine($"            // Removing the element changes the cache order.");
                writer.WriteLine($"            {componentIdCache}.Clear();");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static {component} Get{component}(MonoBehaviour component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            return Get{component}(component.gameObject.GetInstanceID());");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static {component} Get{component}(GameObject gameobject)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            return Get{component}(gameobject.GetInstanceID());");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static {component} Get{component}(int instanceID)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            if ({componentIdCache}.TryGetValue(instanceID, out int cacheId))");
                writer.WriteLine($"                return {components}[cacheId];");
                writer.WriteLine();
                writer.WriteLine($"            var index = {componentId}.IndexOf(instanceID);");
                writer.WriteLine();
                writer.WriteLine($"            if (index < 0)");
                writer.WriteLine($"                return null;");
                writer.WriteLine();
                writer.WriteLine($"            {componentIdCache}[instanceID] = index;");
                writer.WriteLine();
                writer.WriteLine($"            return {components}[index];");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static Arrayx<{component}> GetAll{component}(params Arrayx<int>[] containingIds)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            if (containingIds.Length == 0)");
                writer.WriteLine($"                return {components};");
                writer.WriteLine();
                writer.WriteLine($"            {componentGetIds}.Clear();");
                writer.WriteLine($"            {componentGetIds}.Add({componentId});");
                writer.WriteLine($"            for (int i = 0; i < containingIds.Length; i++)");
                writer.WriteLine($"                {componentGetIds}.Add(containingIds[i]);");
                writer.WriteLine();
                writer.WriteLine($"            return Gigas.Get<{component}>({componentGetIds}, EntitySet.{components}, {componentGetResult});");
                writer.WriteLine($"        }}");

                if (i < classes.Count - 1)
                    writer.WriteLine();
            }

            // End of class.
            writer.WriteLine("    }");

            // End of namespace EntitySet.
            writer.WriteLine("// }");
        }
    }
}

#endif
