using System;
using System.Collections;
using System.Collections.Generic;

namespace Eflatun.Common
{
    /// <summary>
    /// Utilities for C# Generic Lists.
    /// </summary>
    public static class CollectionUtils
    {
        /// <summary>
        /// Returns the circular next index, this means it will return 0 if you call it for last index of list.
        /// </summary>
        public static int GetNextIndexCircular(this IList list, int currentIndex)
        {
            var count = list.Count;
            return count == 0 ? 0 : (currentIndex + 1) % count;
        }

        /// <summary>
        /// Swaps the indexes of items at <paramref name="i1"/> and <paramref name="i2"/> in <paramref name="list"/>.
        /// </summary>
        public static void Swap(this IList list, int i1, int i2)
        {
            if (list.Count < i1 + 1 || i1 < 0)
            {
                throw new ArgumentOutOfRangeException("i1", i1, "i1 is out of range of the list.");
            }
            else if (list.Count < i2 + 1 || i2 < 0)
            {
                throw new ArgumentOutOfRangeException("i2", i2, "i2 is out of range of the list.");
            }

            var temp = list[i1]; //save the item at i1 to temp
            list[i1] = list[i2]; //copy the item at i2 to i1
            list[i2] = temp; //copy the temp to i2
        }

        /// <summary>
        /// Swaps the indexes of <paramref name="item1"/> and <paramref name="item2"/> in <paramref name="list"/>.
        /// </summary>
        public static void Swap<T>(this IList<T> list, T item1, T item2)
        {
            if (!list.Contains(item1))
            {
                throw new ArgumentOutOfRangeException("item1", item1, "List does not contain item1.");
            }
            else if (!list.Contains(item2))
            {
                throw new ArgumentOutOfRangeException("item2", item2, "List does not contain item2.");
            }

            var i1 = list.IndexOf(item1);
            var i2 = list.IndexOf(item2);

            list[i1] = item2;
            list[i2] = item1;
        }

        /// <summary>
        /// Adds item to <paramref name="collection"/> if it doesn't contain the <paramref name="item"/> already.
        /// Returns true if <paramref name="item"/> is added, false otherwise.
        /// </summary>
        public static bool AddIfNotContains<T>(this ICollection<T> collection, T item)
        {
            if (collection.Contains(item))
            {
                return false;
            }

            collection.Add(item);
            return true;
        }

        /// <summary>
        /// Adds the <paramref name="key"/>-<paramref name="value"/> pair to <paramref name="dictionary"/> if it doesn't contain the <paramref name="key"/> already.
        /// Returns true if pair is added, false otherwise.
        /// </summary>
        public static bool AddIfNotContains<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
            TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                return false;
            }

            dictionary.Add(key, value);
            return true;
        }

        /// <summary>
        /// ---- NOTE: Dictionary indexer has this feature already. If you don't need the return bool, use the indexer instead. ---- <para/>
        /// <para> </para>
        /// If <paramref name="dictionary"/> contains <paramref name="key"/>, sets the value to <paramref name="value"/>; otherwise adds a new <paramref name="key"/>-<paramref name="value"/> pair to it.
        /// Returns true if pair is added, false otherwise.
        /// </summary>
        public static bool AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
                return false;
            }

            dictionary.Add(key, value);
            return true;
        }
    }
}
