using System.Collections.Generic;

public static class DictionaryPool<TKey, TValue>
{
    private static readonly Stack<Dictionary<TKey, TValue>> Pool = new Stack<Dictionary<TKey, TValue>>();

    public static Dictionary<TKey, TValue> Rent()
    {
        if (Pool.Count > 0)
            return Pool.Pop();

        return new Dictionary<TKey, TValue>();
    }

    public static void Return(Dictionary<TKey, TValue> dictionary)
    {
        dictionary.Clear();
        Pool.Push(dictionary);
    }
}
