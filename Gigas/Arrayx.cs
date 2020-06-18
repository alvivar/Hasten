// Arrayx is the simples array list.

// The idea is to use 'Length' as index when 'Elements' change, so we can resize
// the array as much as we like, and also be able to iterate on 'Length' for the
// real subset.

using System;

public class Arrayx<T>
{
    public T[] Elements = new T[8];
    public int Size = 8;
    public int Length = 0;

    // @todo Those functions below need a performance test.

    // @todo Would be better if those functions below become extensions?

    public void Add(T component)
    {
        Elements[Length++] = component;

        if (Length >= Size)
        {
            Size *= 2;
            Array.Resize(ref Elements, Size);
        }
    }

    public void RemoveAt(int index)
    {
        Array.Copy(
            Elements, index + 1,
            Elements, index,
            Length - index - 1);
        Length--;
    }

    public void Append(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Elements[Length++] = array[i];

            if (Length >= Size)
            {
                Size *= 2;
                Array.Resize(ref Elements, Size);
            }
        }
    }

    public void ForEach(Action<T> callback)
    {
        for (int i = 0; i < Length; i++)
            callback(Elements[i]);
    }

    public T[] Map(Func<T, T> callback)
    {
        var result = new T[Length];

        for (int i = 0; i < Length; i++)
            result[i] = callback(Elements[i]);

        return result;
    }

    public void Clear()
    {
        Length = 0;
    }

    // @todo Are those below better that the self referenced way up ^ there?

    // public static Arrayx<T> Add(Arrayx<T> arrx, T component)
    // {
    //     arrx.Elements[arrx.Length++] = component;

    //     if (arrx.Length >= arrx.Size)
    //     {
    //         arrx.Size *= 2;
    //         Array.Resize(ref arrx.Elements, arrx.Size);
    //     }

    //     return arrx;
    // }

    // public static Arrayx<T> RemoveAt(Arrayx<T> arrx, int indexToRemove)
    // {
    //     Array.Copy(
    //         arrx.Elements, indexToRemove + 1,
    //         arrx.Elements, indexToRemove,
    //         arrx.Length - indexToRemove - 1);
    //     arrx.Length--;

    //     return arrx;
    // }
}