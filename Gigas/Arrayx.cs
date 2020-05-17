// Arrayx is the simples array list.

// The idea is to use 'Length' as index when 'Elements' change, so we can resize
// the array as much as we like, and also be able to iterate on 'Length' for the
// real subset.

public class Arrayx<T>
{
    public T[] Elements;
    public int Size;
    public int Length;
}