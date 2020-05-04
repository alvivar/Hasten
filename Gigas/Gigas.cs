public static class Gigas
{
    public static Arrayx<T> Get<T>(Arrayx<int>[] idSources, Arrayx<T> source)
    {
        // Just one array means just one source, no interception!
        if (idSources.Length <= 1)
            return source;

        // Create an array with enough space to contain the answers
        var maxSize = 0;
        for (int i = 0; i < idSources.Length; i++)
            maxSize += idSources[i].Length;

        var result = new Arrayx<T>(); // @todo Could I squeeze more performance by caching this stuff?
        result.Size = result.Size < maxSize ? maxSize : result.Size;
        result.Length = 0;

        if (result.Elements == null)
            result.Elements = new T[result.Size];

        // The ids should repeat this much to detect being on each array
        var validCount = idSources.Length;

        // Running over all the ids arrays
        for (int i = 0; i < idSources.Length; i++)
        {
            // For each of element of that array
            for (int j = 0; j < idSources[i].Length; j++)
            {
                var current = idSources[i].Elements[j];
                var currentCount = 0;
                T idValue = default;

                // Let's run over all the ids arrays
                for (int k = 0; k < idSources.Length; k++)
                {
                    // To compare the elements repetition
                    for (int l = 0; l < idSources[k].Length; l++)
                    {
                        if (current == idSources[k].Elements[l])
                        {
                            currentCount++;

                            // Assuming that the ids related to the source are on 0
                            if (k == 0)
                                idValue = source.Elements[l];

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