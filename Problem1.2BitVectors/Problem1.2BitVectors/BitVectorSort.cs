using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1._2BitVectors
{
    /// <summary>
    /// Class which reads in a list of ints of size n, and generates a bit 
    /// vector to sort and store the results.
    /// </summary>
    public class BitVectorSort
    {
        private BitArray _vector;
        private static bool SET_TO_NOT_FOUND = false;
        private static bool SET_TO_FOUND = true;

        public BitVectorSort(int size)
        {
            _vector = new BitArray(size, SET_TO_NOT_FOUND);
        }

        public BitArray Vector { get { return _vector; } }

        public void AddCollectionToVector(IEnumerable<int> collection)
        {
            foreach (var number in collection)
            {
                ThrowIfOutOfRange(number);
                _vector.Set(number, SET_TO_FOUND);
            }
        }

        public bool IsSet(int number)
        {
            ThrowIfOutOfRange(number);
            return _vector.Get(number);
        }

        public void Clear(int number)
        {
            ThrowIfOutOfRange(number);
            _vector.Set(number, SET_TO_NOT_FOUND);
        }

        public void Set(int number)
        {
            ThrowIfOutOfRange(number);
            _vector.Set(number, SET_TO_FOUND);
        }

        private void ThrowIfOutOfRange(int number)
        {
            string errorTemplate = "Index: {0} is out of bounds.";
            var errorMessage = String.Format(errorTemplate, number.ToString());
            if (number > _vector.Length)
                throw new ArgumentException(errorMessage);
        }
    }
}
