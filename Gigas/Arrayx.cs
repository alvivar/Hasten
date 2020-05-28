﻿// Arrayx is the simples array list.

// The idea is to use 'Length' as index when 'Elements' change, so we can resize
// the array as much as we like, and also be able to iterate on 'Length' for the
// real subset.

using System;
using System.Collections.Generic;

public class Arrayx<T>
{
    public T[] Elements = new T[8];
    public int Size = 8;
    public int Length = 0;

    public static Arrayx<T> Add(Arrayx<T> arrx, T component)
    {
        arrx.Elements[arrx.Length++] = component;

        if (arrx.Length >= arrx.Size)
        {
            arrx.Size *= 2;
            Array.Resize(ref arrx.Elements, arrx.Size);
        }

        return arrx;
    }

    public static Arrayx<T> RemoveAt(Arrayx<T> arrx, int indexToRemove)
    {
        // Overwrite

        Array.Copy(
            arrx.Elements, indexToRemove + 1,
            arrx.Elements, indexToRemove,
            arrx.Length - indexToRemove - 1);
        arrx.Length--;

        return arrx;
    }
}