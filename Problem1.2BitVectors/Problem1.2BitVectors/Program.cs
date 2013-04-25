using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1._2BitVectors
{
    /// <summary>
    /// Problem 1.2 asks: How would you implement bit vectors using bitwise
    /// logical operations (such as and, or and shift)?
    /// 
    /// In C#, I wouldn't. I'd use a BitArray since it would be easy to
    /// check, set, and clear elements in the array. That's how this
    /// solution was implemented. BitVectorSort implements the bit vector.
    /// </summary>
    public class Program
    {
        private static int MAX_SIZE = 1000;

        static void Main(string[] args)
        {
            var randSeed = new Random();
            var intList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                intList.Add(randSeed.Next(MAX_SIZE));
            }

            var sort = new BitVectorSort(MAX_SIZE);
            sort.AddCollectionToVector(intList);

            for (int i = 0; i < MAX_SIZE; i++)
            {
                if (sort.IsSet(i))
                    Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
