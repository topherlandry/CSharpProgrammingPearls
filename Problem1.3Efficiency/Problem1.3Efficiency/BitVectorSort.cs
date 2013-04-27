using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem1._3Efficiency
{
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