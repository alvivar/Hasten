// Gigas is just a cool name.

// Get is the main function to handle entities.

public static class Gigas
{
    // Returns the 'components' that belongs to the 'entities' intersected.
    // Let's assume that the first array on 'entities' is the one related
    // position by position to the 'components' in the result.
    public static Arrayx<T> Get<T>(Arrayx<int>[] entities, Arrayx<T> components)
    {
        // Just one array means just one source, no interception!
        if (entities.Length <= 1)
            return components;

        // Create an array with enough space to contain the answers
        var maxSize = 0;
        for (int i = 0; i < entities.Length; i++)
            maxSize += entities[i].Length;

        var result = new Arrayx<T>(); // @todo Could I squeeze more performance by caching this stuff?
        result.Size = result.Size < maxSize ? maxSize : result.Size;
        result.Length = 0;

        if (result.Elements == null)
            result.Elements = new T[result.Size];

        // The ids should repeat this much to detect being on each array
        var validCount = entities.Length;

        // Running over all the ids arrays
        for (int i = 0; i < entities.Length; i++)
        {
            // For each of element of that array
            for (int j = 0; j < entities[i].Length; j++)
            {
                var current = entities[i].Elements[j];
                var currentCount = 0;
                T idValue = default;

                // Let's run over all the ids arrays
                for (int k = 0; k < entities.Length; k++)
                {
                    // To compare the elements repetition
                    for (int l = 0; l < entities[k].Length; l++)
                    {
                        if (current == entities[k].Elements[l])
                        {
                            currentCount++;

                            // Assuming that the ids related to the source are on 0
                            if (k == 0)
                                idValue = components.Elements[l];

                            // We found what we are looking for
                            break;
                        }
                    }
                }

                // Is the element repeated in all the arrays? Let's save the
                // collected value
                if (currentCount >= validCount)
                    result.Elements[result.Length++] = idValue;
            }
        }

        return result;
    }
}