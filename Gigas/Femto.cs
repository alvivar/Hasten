#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

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
    public static List<string> entityClasses = new List<string>();

    [MenuItem("Gigas/Generate EntitySet.cs")]
    public static void GenerateGigasEntity()
    {
        // Try to find an existing file in the project called "EntitySet.cs".
        string filePath = "";
        foreach (var file in Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories))
        {
            // Ignore some of them.
            if (Path.GetFileNameWithoutExtension(file) == "EntitySet")
            {
                filePath = file;
                continue;
            }

            if (Path.GetFileNameWithoutExtension(file) == "Femto")
                continue;

            // Look for '!commands' on each file.
            string line = "";
            using (StreamReader fileWithGigas = new StreamReader(file))
            {
                var className = "";
                var gigasFound = false;

                while ((line = fileWithGigas.ReadLine()) != null)
                {
                    // Found!
                    if (line.ToLower().Contains("!gigas"))
                        gigasFound = true;

                    // Extract the class name.
                    if (line.Contains("class"))
                    {
                        var tokens = line.Split(' ');
                        var index = 0;
                        foreach (var token in tokens)
                        {
                            if (token.Contains("class"))
                            {
                                // I just don't care @hack.
                                try { className = tokens[index + 1].Trim(); }
                                catch { break; }
                                break;
                            }

                            index++;
                        }

                        break;
                    }
                }

                // For the normal API.
                if (gigasFound)
                {
                    if (!entityClasses.Contains(className))
                        entityClasses.Add(className);
                }
            }
        }

        // To be consistent on repositories.
        entityClasses.Sort();

        // If no such file exists already, use the save panel to get a folder in which the file will be placed.
        string directory = "";
        if (string.IsNullOrEmpty(filePath))
        {
            directory = EditorUtility.OpenFolderPanel("Choose the EntitySet.cs location", Application.dataPath, "");

            // Canceled choose? Do nothing.
            if (string.IsNullOrEmpty(directory))
                return;

            filePath = Path.Combine(directory, "EntitySet.cs");
        }

        // Dates.
        DateTime currentTime = DateTime.Now;
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
            for (int i = 0; i < entityClasses.Count; i++)
            {
                var entityClass = entityClasses[i];
                var entityName = $"{entityClass}s";
                var entityId = $"{entityClass}Ids";
                var entityIdCache = $"{entityClass}IdCache";
                var entityGetIds = $"{entityClass}GetIds";
                var entityGetResult = $"{entityClass}GetResult";

                writer.WriteLine($"        // {entityClass}");
                writer.WriteLine();
                writer.WriteLine($"        public static Arrayx<{entityClass}> {entityName} = new Arrayx<{entityClass}>();");
                writer.WriteLine($"        public static Arrayx<int> {entityId} = new Arrayx<int>();");
                writer.WriteLine();
                writer.WriteLine($"        private static Dictionary<int, int> {entityIdCache} = new Dictionary<int, int>();");
                writer.WriteLine($"        private static Arrayx<Arrayx<int>> {entityGetIds} = new Arrayx<Arrayx<int>>();");
                writer.WriteLine($"        private static Arrayx<{entityClass}> {entityGetResult} = new Arrayx<{entityClass}>();");

                writer.WriteLine();
                writer.WriteLine($"        public static void Add{entityClass}({entityClass} component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            {entityId}.Add(component.gameObject.GetInstanceID());");
                writer.WriteLine($"            {entityName}.Add(component);");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static void Remove{entityClass}({entityClass} component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            var id = component.gameObject.GetInstanceID();");
                writer.WriteLine($"            var index = {entityId}.IndexOf(id);");
                writer.WriteLine();
                writer.WriteLine($"            {entityId}.RemoveAt(index);");
                writer.WriteLine($"            {entityName}.RemoveAt(index);");
                writer.WriteLine();
                writer.WriteLine($"            // Removing the element changes the cache order.");
                writer.WriteLine($"            {entityIdCache}.Clear();");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static {entityClass} Get{entityClass}(MonoBehaviour component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            return Get{entityClass}(component.gameObject.GetInstanceID());");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static {entityClass} Get{entityClass}(GameObject gameobject)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            return Get{entityClass}(gameobject.GetInstanceID());");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static {entityClass} Get{entityClass}(int id)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            int cacheId;");
                writer.WriteLine($"            if ({entityIdCache}.TryGetValue(id, out cacheId))");
                writer.WriteLine($"                return {entityName}.Elements[cacheId];");
                writer.WriteLine();
                writer.WriteLine($"            var index = {entityId}.IndexOf(id);");
                writer.WriteLine();
                writer.WriteLine($"            if (index < 0)");
                writer.WriteLine($"                return null;");
                writer.WriteLine();
                writer.WriteLine($"            {entityIdCache}[id] = index;");
                writer.WriteLine();
                writer.WriteLine($"            return {entityName}.Elements[index];");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static Arrayx<{entityClass}> Get{entityClass}(params Arrayx<int>[] ids)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            // {entityId} needs to be the first in the array parameter,");
                writer.WriteLine($"            // that's how Gigas.Get relates the ids to the components.");
                writer.WriteLine();
                writer.WriteLine($"            {entityGetIds}.Clear();");
                writer.WriteLine($"            {entityGetIds}.Add({entityId});");
                writer.WriteLine($"            for (int i = 0; i < ids.Length; i++)");
                writer.WriteLine($"                {entityGetIds}.Add(ids[i]);");
                writer.WriteLine();
                writer.WriteLine($"            return Gigas.Get<{entityClass}>({entityGetIds}, EntitySet.{entityName}, {entityGetResult});");
                writer.WriteLine($"        }}");

                if (i < entityClasses.Count - 1)
                    writer.WriteLine();
            }

            // A function that clears all entities.
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine($"        public static void Clear()");
            writer.WriteLine($"        {{");
            for (int i = 0; i < entityClasses.Count; i++)
            {
                var entityClass = entityClasses[i];
                var entityName = $"{entityClass}s";
                var entityId = $"{entityClass}Ids";

                writer.WriteLine($"            {entityName}.Clear();");
                writer.WriteLine($"            {entityId}.Clear();");

                if (i < entityClasses.Count - 1)
                    writer.WriteLine();
            }
            writer.WriteLine($"        }}");

            // End of class.
            writer.WriteLine("    }");

            // End of namespace EntitySet.
            writer.WriteLine("// }");
        }

        // Refresh.
        AssetDatabase.Refresh();
    }
}

#endif
