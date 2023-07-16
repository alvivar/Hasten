using System.Collections.Generic;

// Gigas provides static methods to query entities and obtain associated components.
public static class Gigas // v3
{
    private static HashSet<int> visited = new HashSet<int>(); // To avoid GC.

    // The method Get returns the components corresponding to the entities that exist in all entity arrays.
    public static Arrayx<T> Get<T>(Arrayx<Arrayx<int>> entities, Arrayx<T> components, Arrayx<T> result)
    {
        // Clear the result array to ensure no pre-existing data.
        result.Clear();

        // If there's only one or no entities source, return the components associated with it.
        if (entities.Length <= 1)
            return components;

        // Dictionary to hold the count of each entity across all sources and their corresponding component.
        // Key: Entity, Value: Tuple (Count of entity, Corresponding Component)
        Dictionary<int, (int Count, T Value)> counts = DictionaryPool<int, (int, T)>.Rent(); // From a pool to avoid GC.

        // Iterating over all entity arrays (entity sources).
        for (int i = 0; i < entities.Length; i++)
        {
            // HashSet to keep track of entities already visited in the current source.
            visited.Clear();

            // Iterating over each entity in the current source.
            for (int j = 0; j < entities[i].Length; j++)
            {
                var current = entities[i][j];

                // Skip entity if it's already visited in the current source.
                if (visited.Contains(current))
                    continue;

                // Mark the entity as visited.
                visited.Add(current);

                // If the entity is already in the dictionary, increment its count.
                // Otherwise, add it to the dictionary with count 1 and its associated component.
                // The component is only taken from the first source.
                if (counts.ContainsKey(current))
                {
                    counts[current] = (counts[current].Count + 1, counts[current].Value);
                }
                else
                {
                    counts[current] = (1, i == 0 ? components[j] : default);
                }
            }
        }

        // Iterating over the dictionary to add components to the result.
        // Components are only added if their corresponding entity exists in all sources and is not null.
        foreach (var pair in counts)
        {
            if (pair.Value.Count == entities.Length && pair.Value.Value != null)
                result.Add(pair.Value.Value);
        }

        // After using the dictionary, return it back to the pool.
        DictionaryPool<int, (int, T)>.Return(counts);

        // Return the result array containing components of intersecting entities.
        return result;
    }
}
