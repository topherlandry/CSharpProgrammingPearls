using System.Collections.Generic;
using System.Linq;

namespace Problem1._1Sort
{
    /// <summary>
    /// Problem 1.1 - If memory were not scarce, how would you implement a sort
    /// in a language with libraries for representing and sorting sets?
    /// </summary>
    public class StringList
    {
        public List<string> List { get; set; }

        public StringList()
        {
            List = new List<string>();
        }

        /// <summary>
        /// Return a string list containing no duplicates and sorted by string
        /// comparison.
        /// </summary>
        /// <remarks>The problem called for a string list that did not contain
        /// any duplicates.</remarks>
        public List<string> GetDistinctSortedList()
        {
            return List.Distinct().OrderBy(s => s).ToList();
        }
    }
}
