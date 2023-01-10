// Arrayx is the simplest array list.

// The idea is to use 'Length' as index when 'Elements' change, so we can resize
// the array as much as we like, and also be able to iterate on 'Length' for the
// real subset.

using System;

public class Arrayx<T>
{
    public T[] Elements;

    public int Size;
    public int Length;

    public Arrayx(int size = 1)
    {
        Size = size < 1 ? 1 : size;
        Elements = new T[size];
        Length = 0;
    }

    public void Grow(int size)
    {
        if (Size < size)
        {
            Size = size;
            Array.Resize(ref Elements, Size);
        }
    }

    public void Add(T element)
    {
        if (Length >= Size)
        {
            Size *= 2;
            Array.Resize(ref Elements, Size);
        }

        Elements[Length++] = element;
    }

    public Arrayx<T> Append(T[] array)
    {
        Grow(Length + array.Length);

        for (int i = 0; i < array.Length; i++)
            Elements[Length++] = array[i];

        return this;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public T First()
    {
        return Elements[0];
    }

    // This fails when Length is 0. Should this be an exception? Or we just let
    // it roll? Or maybe there is a nice trick to return the nullable from T
    // without overhead? Or it's your responsibility to check Length before?
    public T Last()
    {
        return Elements[Length - 1];
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

    public int IndexOf(T element)
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

        return index;
    }

    // Important: Beware when T is a numeric value like integer, because default
    // will be 0, and that may be a valid value for you.
    public T Find(Func<T, bool> callback)
    {
        for (int i = 0; i < Length; i++)
        {
            if (callback(Elements[i]))
                return Elements[i];
        }

        return default;
    }

    public Arrayx<T> FindAll(Func<T, bool> callback)
    {
        var result = new Arrayx<T>(Length);

        for (int i = 0; i < Length; i++)
        {
            if (callback(Elements[i]))
                result.Add(Elements[i]);
        }

        return result;
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

    public T Pop(int index)
    {
        var element = Elements[index];
        RemoveAt(index);

        return element;
    }

    public void Clear()
    {
        Length = 0;
    }

    public void ForEach(Action<T> callback)
    {
        for (int i = 0; i < Length; i++)
            callback(Elements[i]);
    }

    public Arrayx<T> Map(Func<T, T> callback)
    {
        var result = new Arrayx<T>(Length);

        for (int i = 0; i < Length; i++)
            result.Add(callback(Elements[i]));

        return result;
    }

    // @todo Untested!
    public Arrayx<TR> Map<TR>(Func<T, TR> callback)
    {
        var result = new Arrayx<TR>(Length);

        for (int i = 0; i < Length; i++)
            result.Add(callback(Elements[i]));

        return result;
    }

    public void MapSelf(Func<T, T> callback)
    {
        for (int i = 0; i < Length; i++)
            Elements[i] = callback(Elements[i]);
    }

    public TR Reduce<TR>(TR accumulator, Func<TR, T, TR> callback)
    {
        TR result = accumulator;

        for (int i = 0; i < Length; i++)
            result = callback(result, Elements[i]);

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
}
