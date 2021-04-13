// Arrayx is the simples array list.

// The idea is to use 'Length' as index when 'Elements' change, so we can resize
// the array as much as we like, and also be able to iterate on 'Length' for the
// real subset.

using System;

public class Arrayx<T>
{
    public int Size;
    public T[] Elements;
    public int Length;

    public static Arrayx<T> New(int size)
    {
        var x = new Arrayx<T>();
        x.Size = size < 1 ? 1 : size;
        x.Elements = new T[size];
        x.Length = 0;

        return x;
    }

    public void Add(T element)
    {
        Elements[Length++] = element;

        if (Length >= Size)
        {
            Size *= 2;
            Array.Resize(ref Elements, Size);
        }
    }

    public void Remove(T element)
    {
        var index = -1;
        for (int i = 0; i < Length; i++)
        {
            if (Elements[i].Equals(element))
            {
                index = i;
                break;
            }
        }

        if (index < 0)
            return;

        Array.Copy(
            Elements, index + 1,
            Elements, index,
            Length - index - 1);
        Length--;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Length)
            return;

        Array.Copy(
            Elements, index + 1,
            Elements, index,
            Length - index - 1);
        Length--;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < Length; i++)
        {
            if (Elements[i].Equals(element))
                return true;
        }

        return false;
    }

    public Arrayx<T> Append(T[] array)
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

        return this;
    }

    public void ForEach(Action<T> callback)
    {
        for (int i = 0; i < Length; i++)
            callback(Elements[i]);
    }

    public Arrayx<T> Map(Func<T, T> callback)
    {
        var result = Arrayx<T>.New(Length);

        for (int i = 0; i < Length; i++)
            result.Add(callback(Elements[i]));

        return result;
    }

    public TR Reduce<TR>(TR accumulator, Func<TR, T, TR> callback)
    {
        TR result = accumulator;

        for (int i = 0; i < Length; i++)
            result = callback(result, Elements[i]);

        return result;
    }

    public Arrayx<T> Filter(Func<T, bool> callback, bool first = false)
    {
        var result = Arrayx<T>.New(Length);

        for (int i = 0; i < Length; i++)
        {
            if (callback(Elements[i]))
            {
                result.Add(Elements[i]);
                if (first) break;
            }
        }

        return result;
    }

    public T[] ToArray()
    {
        var array = new T[Length];

        Array.Copy(
            Elements, 0,
            array, 0,
            Length);

        return array;
    }

    // If this is called when the Length is 0, it fails.

    // Check this for a possible solution
    // https://stackoverflow.com/questions/302096/how-can-i-return-null-from-a-generic-method-in-c

    // But returning default could be a problem with a list of ints.
    public T LastElement()
    {
        return Elements[Length - 1];
    }

    public void Clear()
    {
        Length = 0;
    }
}