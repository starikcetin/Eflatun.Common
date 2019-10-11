using System.Collections;
using System.Collections.Generic;

namespace Eflatun.Common
{
    /// <summary>
    /// Includes methods to shuffle lists with seeding, using Fisher-Yates algorithm.
    /// </summary>
    public class ListShuffler
    {
        private System.Random _random;

        public ListShuffler()
        {
            _random = new System.Random();
        }

        public ListShuffler(int seed)
        {
            _random = new System.Random(seed);
        }

        public void ChangeSeed(int seed)
        {
            _random = new System.Random(seed);
        }

        /// <summary>
        /// <para>Returns a shuffled version of given list. Original doesn't change.</para>
        /// <para>(This method clones a new list and does shuffling operation on the clone; then returns the clone.)</para>
        /// </summary>
        public List<T> SafeShuffle<T>(IList<T> original)
        {
            var newList = new List<T>(original);
            FisherYatesShuffle(newList);
            return newList;
        }

        /// <summary>
        /// <para>Shuffles the given list. Original changes.</para>
        /// <para>(This method does shuffling operation on the original list.)</para>
        /// </summary>
        public void Shuffle(IList original)
        {
            FisherYatesShuffle(original);
        }

        private void FisherYatesShuffle(IList list)
        {
            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                int randomIndex = _random.Next(count); //Get a random index.
                list.Swap(i, randomIndex); //Swap the items at i and random index.
            }
        }
    }
}
