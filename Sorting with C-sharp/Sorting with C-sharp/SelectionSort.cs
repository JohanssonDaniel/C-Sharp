using System.Collections.Generic;
namespace Sorting_with_C_sharp
{
    class SelectionSort
    {
        public static List<int> Sort(List<int> a) {
            for (int i = 0; i < a.Count - 1; i++)
            {
                int minVal = i;
                for (int j = i+1; j < a.Count; j++)
                {
                    if (a[j] < a[minVal])
                    {
                        minVal = j;
                    }
                }
                if (minVal != i)
                {
                    int temp = a[i];
                    a[i] = a[minVal];
                    a[minVal] = temp;
                }
            }
            return a;
        }
    }
}
