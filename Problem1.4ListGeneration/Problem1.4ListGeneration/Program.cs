using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem1._4ListGeneration
{
    /// <summary>
    /// Generate k integers less than n without duplicates.
    /// In random order.
    /// Short and efficient.
    /// 
    /// Perform same tests as in 1.3.
    /// 
    /// Results are still pointing in favor of the bit vector sort.
    /// 
    /// I implemented the random list generator in a number of different ways
    /// before settling on the HashSet implementation. Every other way I
    /// attempted to generate a distinct random list of m integers from n
    /// possibilities was incredibly slow with m = 1,000,000 and
    /// n = 10,000,000. This one executes fairly quickly.
    /// </summary>
    public class Program
    {
        // Problem called for list size of 1,000,000 with max int size of
        // 10,000,000.
        private const int LIST_SIZE = 1000000;
        private const int MAX_INT = 10000000;

        public static void Main()
        {
            var seed = new Random();
            var unsortedList = GenerateRandomList(LIST_SIZE, MAX_INT);

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            GetDistinctSortedList(unsortedList);
            stopwatch.Start();

            Console.WriteLine("System sort took {0} ms.", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();

            var bitVector = new BitVectorSort(MAX_INT);

            stopwatch.Start();
            bitVector.AddCollectionToVector(unsortedList);
            stopwatch.Stop();

            Console.WriteLine("Bit vector sort took {0} ms.", stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }

        /// <summary>
        /// Return a string list containing no duplicates and sorted by string
        /// comparison.
        /// </summary>
        /// <remarks>The problem called for a string list that did not contain
        /// any duplicates.</remarks>
        public static List<int> GetDistinctSortedList(List<int> list)
        {
            return list.Distinct().OrderBy(s => s).ToList();
        }

        private static List<int> GenerateRandomList(int size, int maxValue)
        {
            var set = new HashSet<int>();
            var seed = new Random();
            while (set.Count < size)
                set.Add(seed.Next(maxValue));

            return set.ToList();
        }
    }
}
