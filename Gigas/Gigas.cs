using System;

public static class Gigas
{
    // static Arrayx<int> all = new Arrayx<int>();
    // static Arrayx<int> result = new Arrayx<int>();

    public static Arrayx<T> Get<T>(Arrayx<int>[] idSources, Arrayx<T> source)
    {
        // Just one array means just one source!
        if (idSources.Length <= 1)
            return source;

        // Create an array that contains the answers
        var maxSize = 0;
        for (int i = 0; i < idSources.Length; i++)
            maxSize += idSources[i].Length;

        var result = new Arrayx<T>();
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

    // public static Arrayx<int> Intersect(params Arrayx<int>[] args)
    // {
    //     var maxSize = 0;
    //     for (int i = 0; i < args.Length; i++)
    //         maxSize += args[i].Length;

    //     all.Size = all.Size < maxSize ? maxSize : all.Size;
    //     all.Length = 0;

    //     if (all.Elements == null)
    //         all.Elements = new int[all.Size];

    //     if (all.Elements.Length <= all.Size)
    //         Array.Resize(ref all.Elements, all.Size);

    //     for (int i = 0; i < args.Length; i++)
    //     {
    //         for (int j = 0; j < args[i].Length; j++)
    //             all.Elements[all.Length++] = args[i].Elements[j];
    //     }

    //     result.Size = result.Size < maxSize ? maxSize : result.Size;
    //     result.Length = 0;

    //     if (result.Elements == null)
    //         result.Elements = new int[result.Size];

    //     if (result.Elements.Length <= result.Size)
    //         Array.Resize(ref result.Elements, result.Size);

    //     var validCount = args.Length;
    //     for (int i = 0; i < all.Length; i++)
    //     {
    //         var currentCount = 0;
    //         var current = all.Elements[i];
    //         for (int j = 0; j < all.Length; j++)
    //         {
    //             if (current == all.Elements[j])
    //                 currentCount++;
    //         }

    //         if (currentCount >= validCount)
    //             result.Elements[result.Length++] = current;
    //     }

    //     return result;
    // }

    // public static Arrayx<T> Get<T>(Arrayx<int> indexValues, Arrayx<int> indexSource, Arrayx<T> dataSource)
    // {
    //     var result = new Arrayx<T>();
    //     result.Size = indexValues.Length;
    //     result.Length = 0;
    //     result.Elements = new T[result.Size];

    //     for (int i = 0; i < indexValues.Length; i++)
    //     {
    //         var value = indexValues.Elements[i];
    //         var indexOfValue = -1;
    //         for (int j = 0; j < indexSource.Length; j++)
    //         {
    //             if (indexSource.Elements[j] == value)
    //             {
    //                 indexOfValue = j;
    //                 break;
    //             }
    //         }

    //         result.Elements[result.Length++] = dataSource.Elements[indexOfValue];
    //     }

    //     return result;
    // }

    // public static void Remove<T>(int id, Arrayx<int> index, Arrayx<T> data)
    // {
    //     var dataIndex = index.IndexOf(id);
    //     index.RemoveIndex(dataIndex);
    //     data.RemoveIndex(dataIndex);
    // }

    // public static void Remove<T>(int id, Arrayx<int> index, Arrayx<T> data, UnityEngine.GameObject obj = null)
    // {
    //     var indexOfValue = -1;
    //     for (int i = 0; i < index.Length; i++)
    //     {
    //         if (index.elements[i] == id)
    //         {
    //             indexOfValue = i;
    //             break;
    //         }
    //     }

    //     index.RemoveIndex(indexOfValue);
    //     data.RemoveIndex(indexOfValue);

    //     if (obj != null)
    //     {
    //         var objComp = obj.GetComponent(typeof(T));
    //         UnityEngine.Object.Destroy(objComp);
    //     }
    // }
}