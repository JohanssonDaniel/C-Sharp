using System.Collections.Generic;

namespace Sorting_with_C_sharp
{
    /// <summary>
    /// Insertion sort sorts list by iterating through the list and inserting the current value at the correct position
    /// by checking if it is larger or smaller than the value next to it (depending on what the user wants)
    /// Insertion is made by swapping the current value with each value it is checked against
    /// </summary>
    class InsertionSort 
    {
        public static List<int> Sort(List<int> a)
        {
            // Begins at 1 because the 0th value will not be checked against any value
            for (int i = 1; i < a.Count; i++)
            {
                int j = i;
                // Swap position with all the values in the list that are bigger than the current value
                while (j > 0 && a[j - 1] > a[j])
                {
                    int temp = a[j - 1];
                    a[j - 1] = a[j];
                    a[j] = temp;
                    j--;
                }
            }
            return a;
        } 
    }
}
