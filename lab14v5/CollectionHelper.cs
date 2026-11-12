using System;
using System.Collections.Generic;

public static class CollectionHelper<T>
{
    public static Dictionary<TKey, List<T>> GroupBy<TKey>(
        IEnumerable<T> collection,
        Func<T, TKey> keySelector)
        where TKey : notnull
    {
        var groups = new Dictionary<TKey, List<T>>();

        foreach (T item in collection)
        {
            TKey key = keySelector(item);

            if (!groups.ContainsKey(key))
            {
                groups[key] = new List<T>();
            }

            groups[key].Add(item);
        }

        return groups;
    }
}