// Arrayx uses 'Length' as a dual-purpose property: it both tracks the number of
// elements stored in 'Elements' and serves as the index for new entries.

// This design enables dynamic resizing of 'Elements' as required, and ensures
// iteration, mapping, and reduction operations work strictly on the active data
// subset, eliminating any interactions with unused array slots. This results in
// efficient memory usage and data integrity.

using System;
using System.Collections;
using System.Collections.Generic;

public class Arrayx<T> : IEnumerable<T>
{
    public T this[int index]
    {
        get => elements[index];
        set => elements[index] = value;
    }

    public int Length { get; private set; }

    private T[] elements;

    public Arrayx(int size = 1)
    {
        elements = new T[size < 1 ? 1 : size];
        Length = 0;
    }

    public void Grow(int minSize)
    {
        if (elements.Length >= minSize)
            return;

        int newSize = Math.Max(elements.Length == 0 ? 1 : elements.Length * 2, minSize);
        Array.Resize(ref elements, newSize);
    }

    public void Add(T element)
    {
        Grow(Length + 1);
        elements[Length++] = element;
    }

    public void Append(T[] array)
    {
        Grow(Length + array.Length);
        Array.Copy(array, 0, elements, Length, array.Length);
        Length += array.Length;
    }

    public bool IsEmpty() => Length == 0;

    public T First() => elements[0];

    // This fails when Length is 0. Should this be an exception? Or we just let
    // it roll? Or maybe there is a nice trick to return the nullable from T
    // without overhead? Or it's the programmer responsibility to check?
    public T Last() => elements[Length - 1];

    public bool Contains(T element)
    {
        for (int i = 0; i < Length; i++)
        {
            if (elements[i].Equals(element))
                return true;
        }

        return false;
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < Length; i++)
        {
            if (elements[i].Equals(element))
                return i;
        }

        return -1;
    }

    // Important: Beware when T is a numeric value like integer, because default
    // will be 0, and that may be a valid value for you.
    public T Find(Func<T, bool> callback)
    {
        for (int i = 0; i < Length; i++)
        {
            if (callback(elements[i]))
                return elements[i];
        }

        return default;
    }

    public void Remove(T element)
    {
        int index = IndexOf(element);
        if (index >= 0) RemoveAt(index);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Length)
            return;

        Array.Copy(elements, index + 1, elements, index, Length - index - 1);
        Length--;
    }

    public T Pop(int index)
    {
        var element = elements[index];
        RemoveAt(index);

        return element;
    }

    public void Clear() => Length = 0;

    public void ForEach(Action<T> callback)
    {
        for (int i = 0; i < Length; i++)
            callback(elements[i]);
    }

    public Arrayx<T> Map(Func<T, T> callback)
    {
        var result = new Arrayx<T>(Length);

        for (int i = 0; i < Length; i++)
            result.Add(callback(elements[i]));

        return result;
    }

    // @todo Untested.
    public Arrayx<TR> Map<TR>(Func<T, TR> callback)
    {
        var result = new Arrayx<TR>(Length);

        for (int i = 0; i < Length; i++)
            result.Add(callback(elements[i]));

        return result;
    }

    public void MapSelf(Func<T, T> callback)
    {
        for (int i = 0; i < Length; i++)
            elements[i] = callback(elements[i]);
    }

    public TR Reduce<TR>(TR accumulator, Func<TR, T, TR> callback)
    {
        TR result = accumulator;

        for (int i = 0; i < Length; i++)
            result = callback(result, elements[i]);

        return result;
    }

    public void Optimize()
    {
        if (Length == elements.Length)
            return;

        Array.Resize(ref elements, Length);
    }

    public T[] Clone()
    {
        var clone = new T[Length];
        Array.Copy(elements, 0, clone, 0, Length);

        return clone;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Length; i++)
            yield return elements[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
