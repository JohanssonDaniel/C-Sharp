using System.Collections.Generic;
namespace Sorting_with_C_sharp
{
    /// <summary>
    /// Selection sorts a list by finding the smallest value and swaps it with the current position
    /// </summary>
    class SelectionSort
    {
        public static List<int> Sort(List<int> a) {

            for (int i = 0; i < a.Count - 1; i++)
            {
                int minI = i;
                for (int j = i + 1; j < a.Count; j++)
                {
                    // If a lower value is found, use that instead
                    if (a[j] < a[minI])
                    {
                        minI = j;
                    }
                }
                // Swap the lowest found value to the current position
                int temp = a[i];
                a[i] = a[minI];
                a[minI] = temp;
            }
            return a;
        }
    }
}
