#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

// Femto is a Unity code generator that creates the entities database:
// EntitySet.

// Just write '// !Gigas' on any class that you consider an Entity, and all the
// required functionality will be generated.

// Check out the menu item 'Tools/Gigas/Generate EntitySet.cs'

// Truth
// 1. The GameObject GetInstanceID() is the Entity id.

public static class Femto
{
    public static int arrayxSize = 8; // 1024 * 1;
    public static List<string> entityClasses = new List<string>();

    [MenuItem("Tools/Gigas/Generate EntitySet.cs")]
    public static void GenerateGigasEntity()
    {
        // Try to find an existing file in the project called "EntitySet.cs"
        string filePath = "";
        foreach (var file in Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories))
        {
            // Ignore some of them
            if (Path.GetFileNameWithoutExtension(file) == "EntitySet")
            {
                filePath = file;
                continue;
            }

            if (Path.GetFileNameWithoutExtension(file) == "Femto")
                continue;

            // Look for '// !Gigas' on each file
            string line = "";
            using(StreamReader fileWithGigas = new StreamReader(file))
            {
                var className = "";
                var approved = false;
                while ((line = fileWithGigas.ReadLine()) != null)
                {
                    // Found!
                    if (line.ToLower().Contains("// !gigas"))
                        approved = true;

                    // Extract the class name
                    if (line.Contains("class"))
                    {
                        var tokens = line.Split(' ');
                        var index = 0;
                        foreach (var token in tokens)
                        {
                            if (token.Contains("class"))
                            {
                                // I just don't care @hack
                                try { className = tokens[index + 1].Trim(); }
                                catch { break; }
                                break;
                            }

                            index++;
                        }
                    }
                }

                if (approved)
                {
                    if (!entityClasses.Contains(className))
                        entityClasses.Add(className);
                }
            }
        }

        // To be consistent on repositories
        entityClasses.Sort();

        // If no such file exists already, use the save panel to get a folder in which the file will be placed
        string directory = "";
        if (string.IsNullOrEmpty(filePath))
        {
            directory = EditorUtility.OpenFolderPanel("Choose the location for EntitySet.cs", Application.dataPath, "");

            // Canceled choose? Do nothing
            if (string.IsNullOrEmpty(directory))
                return;

            filePath = Path.Combine(directory, "EntitySet.cs");
        }

        // Write out our file
        using(var writer = new StreamWriter(filePath))
        {
            writer.WriteLine("// This file is auto-generated. Modifications won't be saved, be cool.");
            writer.WriteLine();
            writer.WriteLine("// EntitySet is a static database of MonoBehaviour classes that are considered a");
            writer.WriteLine("// Entity, classes with '// !Gigas' somewhere in their file.");
            writer.WriteLine();
            writer.WriteLine("// Refresh with the menu item 'Tools/Gigas/Generate EntitySet.cs'");
            writer.WriteLine();
            writer.WriteLine("using System;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine("using UnityEngine;");
            writer.WriteLine();
            writer.WriteLine("//  namespace Gigas");
            writer.WriteLine("//  {");

            writer.WriteLine("    public static class EntitySet");
            writer.WriteLine("    {");

            // The EntitySet API
            for (int i = 0; i < entityClasses.Count; i++)
            {
                var entityClass = entityClasses[i];
                var entityName = $"{entityClass}s";
                var entityId = $"{entityClass}Ids";
                var entityCache = $"{entityClass}IdCache";

                writer.WriteLine($"        // {entityClass}");
                writer.WriteLine();
                writer.WriteLine($"        public static Arrayx<int> {entityId} = new Arrayx<int>();");
                writer.WriteLine($"        public static Arrayx<{entityClass}> {entityName} = new Arrayx<{entityClass}>();");

                writer.WriteLine();
                writer.WriteLine($"        public static void Add{entityClass}({entityClass} component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            // Setup");
                writer.WriteLine();
                writer.WriteLine($"            if ({entityId}.Elements == null)");
                writer.WriteLine($"            {{");
                writer.WriteLine($"                {entityId}.Size = {arrayxSize};");
                writer.WriteLine($"                {entityId}.Elements = new int[{entityId}.Size];");
                writer.WriteLine($"            }}");
                writer.WriteLine();
                writer.WriteLine($"            if ({entityName}.Elements == null)");
                writer.WriteLine($"            {{");
                writer.WriteLine($"                {entityName}.Size = {arrayxSize};");
                writer.WriteLine($"                {entityName}.Elements = new {entityClass}[{entityName}.Size];");
                writer.WriteLine($"            }}");
                writer.WriteLine();
                writer.WriteLine($"            // Add");
                writer.WriteLine();
                writer.WriteLine($"            {entityId}.Elements[{entityId}.Length++] = component.gameObject.GetInstanceID();");
                writer.WriteLine($"            {entityName}.Elements[{entityName}.Length++] = component;");
                writer.WriteLine();
                writer.WriteLine($"            // Resize check");
                writer.WriteLine();
                writer.WriteLine($"            if ({entityId}.Length >= {entityId}.Size)");
                writer.WriteLine($"            {{");
                writer.WriteLine($"                {entityId}.Size *= 2;");
                writer.WriteLine($"                Array.Resize(ref {entityId}.Elements, {entityId}.Size);");
                writer.WriteLine();
                writer.WriteLine($"                {entityName}.Size *= 2;");
                writer.WriteLine($"                Array.Resize(ref {entityName}.Elements, {entityName}.Size);");
                writer.WriteLine($"            }}");
                writer.WriteLine();
                writer.WriteLine($"            // Enable");
                writer.WriteLine();
                writer.WriteLine($"            component.enabled = true; ");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static void Remove{entityClass}({entityClass} component)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            // Index");
                writer.WriteLine();
                writer.WriteLine($"            var id = component.gameObject.GetInstanceID();");
                writer.WriteLine($"            var indexToRemove = -1;");
                writer.WriteLine($"            for (int i = 0; i < {entityId}.Length; i++)");
                writer.WriteLine($"            {{");
                writer.WriteLine($"                if ({entityId}.Elements[i] == id)");
                writer.WriteLine($"                {{");
                writer.WriteLine($"                    indexToRemove = i;");
                writer.WriteLine($"                    break;");
                writer.WriteLine($"                }}");
                writer.WriteLine($"            }}");
                writer.WriteLine();
                writer.WriteLine($"            // Overwrite");
                writer.WriteLine();
                writer.WriteLine($"            Array.Copy(");
                writer.WriteLine($"                {entityId}.Elements, indexToRemove + 1,");
                writer.WriteLine($"                {entityId}.Elements, indexToRemove,");
                writer.WriteLine($"                {entityId}.Length - indexToRemove - 1);");
                writer.WriteLine($"            {entityId}.Length--;");
                writer.WriteLine();
                writer.WriteLine($"            Array.Copy(");
                writer.WriteLine($"                {entityName}.Elements, indexToRemove + 1,");
                writer.WriteLine($"                {entityName}.Elements, indexToRemove,");
                writer.WriteLine($"                {entityName}.Length - indexToRemove - 1);");
                writer.WriteLine($"            {entityName}.Length--;");
                writer.WriteLine();
                writer.WriteLine($"            // Disable");
                writer.WriteLine();
                writer.WriteLine($"            component.enabled = false;");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        public static Arrayx<{entityClass}> Get{entityClass}(params Arrayx<int>[] ids)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            // {entityId} needs to be the first in the array parameter,");
                writer.WriteLine($"            // that's how Gigas.Get relates the ids to the components");
                writer.WriteLine();
                writer.WriteLine($"            Arrayx<int>[] {entityClass}PlusIds = new Arrayx<int>[ids.Length + 1];");
                writer.WriteLine($"            {entityClass}PlusIds[0] = {entityId};");
                writer.WriteLine($"            Array.Copy(ids, 0, {entityClass}PlusIds, 1, ids.Length);");
                writer.WriteLine();
                writer.WriteLine($"            return Gigas.Get<{entityClass}>({entityClass}PlusIds, EntitySet.{entityName});");
                writer.WriteLine($"        }}");

                writer.WriteLine();
                writer.WriteLine($"        private static Dictionary<int, int> {entityCache} = new Dictionary<int, int>();");
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
                writer.WriteLine($"        public static {entityClass} Get{entityClass}(int instanceID)");
                writer.WriteLine($"        {{");
                writer.WriteLine($"            var id = instanceID;");
                writer.WriteLine();
                writer.WriteLine($"            // Cache");
                writer.WriteLine();
                writer.WriteLine($"            if ({entityCache}.ContainsKey(id))");
                writer.WriteLine($"                return {entityName}.Elements[{entityCache}[id]];");
                writer.WriteLine();
                writer.WriteLine($"            // Index of");
                writer.WriteLine();
                writer.WriteLine($"            var index = -1;");
                writer.WriteLine($"            for (int i = 0; i < {entityId}.Length; i++)");
                writer.WriteLine($"            {{");
                writer.WriteLine($"                if ({entityId}.Elements[i] == id)");
                writer.WriteLine($"                {{");
                writer.WriteLine($"                    index = i;");
                writer.WriteLine($"                    {entityCache}[id] = i; // Cache");
                writer.WriteLine($"                    break;");
                writer.WriteLine($"                }}");
                writer.WriteLine($"            }}");
                writer.WriteLine();
                writer.WriteLine($"            // Value");
                writer.WriteLine();
                writer.WriteLine($"            if (index < 0)");
                writer.WriteLine($"                return null;");
                writer.WriteLine();
                writer.WriteLine($"            return {entityName}.Elements[index];");
                writer.WriteLine($"        }}");

                if (i < entityClasses.Count - 1)
                    writer.WriteLine();
            }

            // A function that clears all arrayxs
            writer.WriteLine();
            writer.WriteLine($"        public static void Clear()");
            writer.WriteLine($"        {{");
            for (int i = 0; i < entityClasses.Count; i++)
            {
                var entityClass = entityClasses[i];
                var entityName = $"{entityClass}s";
                var entityId = $"{entityClass}Ids";

                writer.WriteLine($"            {entityId}.Length = 0;");
                writer.WriteLine($"            {entityName}.Length = 0;");

                if (i < entityClasses.Count - 1)
                    writer.WriteLine();
            }
            writer.WriteLine($"        }}");

            // End of class
            writer.WriteLine("    }");

            // End of namespace EntitySet
            writer.WriteLine("//  }");
        }

        // Refresh
        AssetDatabase.Refresh();
    }

    private static string MakeSafeForCode(string text)
    {
        text = Regex.Replace(text, "[^a-zA-Z0-9_]", "_", RegexOptions.None);
        if (char.IsDigit(text[0])) text = "_" + text;

        return text;
    }

    private static string CamelCase(string text)
    {
        return $"{char.ToLowerInvariant(text[0])}{text.Substring(1)}";
    }
}

#endif