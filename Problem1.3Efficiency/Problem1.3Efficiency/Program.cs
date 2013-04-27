using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1._3Efficiency
{
    /// <summary>
    /// Implement the bitmap sort on your system and measure its runtime;
    /// how does it compare to the system sort and the sort in problem 1.1?
    /// 
    /// On my machine, the bit vector sort is consistently faster by
    /// approximately 30% with this code.
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
            var unsortedList = new List<int>();

            for(int i = 0;i < LIST_SIZE;i++)
                unsortedList.Add(seed.Next(MAX_INT));

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
    }
}
