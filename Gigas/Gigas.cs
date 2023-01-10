// Gigas is just a cool name.

// Get is the core, the function that queries Entities to obtain components.

public static class Gigas
{
    // Returns the 'components' that belongs to the 'entities' intersected.
    // Let's assume that the first array on 'entities' is the one related
    // position by position to the 'components' in the result.
    public static Arrayx<T> Get<T>(Arrayx<Arrayx<int>> entities, Arrayx<T> components, Arrayx<T> result)
    {
        // Just one array means just one source, no interception!
        if (entities.Length <= 1)
            return components;

        // Result cache.
        result.Clear();

        // The ids should repeat this much to detect being on each array.
        var validCount = entities.Length;

        // Running over all the ids arrays.
        for (int i = 0; i < entities.Length; i++)
        {
            // For each of element of that array.
            for (int j = 0; j < entities.Elements[i].Length; j++)
            {
                var current = entities.Elements[i].Elements[j];
                var currentFoundCount = 0;
                T matchedValue = default;

                // Let's run over all the ids arrays.
                for (int k = 0; k < entities.Length; k++)
                {
                    // To compare the elements repetition.
                    for (int l = 0; l < entities.Elements[k].Length; l++)
                    {
                        if (current == entities.Elements[k].Elements[l])
                        {
                            currentFoundCount++;

                            // Using 'i' because the match should happen only
                            // once and the ids related to the source are on 0.
                            if (i == 0 && k == 0)
                                matchedValue = components.Elements[l];

                            // We found what we are looking for.
                            break;
                        }
                    }
                }

                // Is the element repeated in all the arrays? Let's collect the
                // value if exists.
                if (currentFoundCount >= validCount && matchedValue != null)
                    result.Add(matchedValue);
            }
        }

        return result;
    }
}
