using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting_with_C_sharp
{
    class MergeSort
    {
        public static List<int> Sort(List<int> a)
        {
            // Base case, list has one element (sorted)
            if (a.Count() == 1) return a;
            // Calculate and round down the index
            decimal halfI = a.Count() / 2;
            int i = (int) Math.Floor(halfI);
            // Divide the list
            List<int> a1 = a.Take(i).ToList();
            List<int> a2 = a.Skip(i).ToList();
            // Sort the lists again
            a1 = Sort(a1);
            a2 = Sort(a2);

            return Merge(a1, a2);
        }

        private static List<int> Merge(List<int> a1, List<int> a2)
        {
            List<int> b = new List<int>();
            // Merge the two lists. The lowest value is added to b and removed from parent array
            while (a1.Any() && a2.Any())
            {
                if (a1.First() < a2.First())
                {
                    b.Add(a1.First());
                    a1.RemoveAt(0);
                }
                else
                {
                    b.Add(a2.First());
                    a2.RemoveAt(0);   
                }
            }
            // Add the remaining elements from a1
            while (a1.Any())
            {
                b.Add(a1.First());
                a1.RemoveAt(0);
            }
            // Add the remaining elements from a2
            while (a2.Any())
            {
                b.Add(a2.First());
                a2.RemoveAt(0);
            }
            return b;
        }
    }
}
