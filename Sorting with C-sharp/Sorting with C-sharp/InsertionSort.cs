using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_with_C_sharp
{
    class InsertionSort 
    {
        public static List<int> Sort(List<int> a)
        {
            for (int i = 1; i < a.Count; i++)
            {
                int j = i;
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
