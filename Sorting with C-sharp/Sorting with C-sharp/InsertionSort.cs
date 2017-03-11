using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_with_C_sharp
{
    class InsertionSort 
    {
        public static int[] Sort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int j = i;
                while (j > 0 && list[j - 1] > list[j])
                {
                    int temp = list[j - 1];
                    list[j - 1] = list[j];
                    list[j] = temp;
                    j--;
                }
            }
            return list;
        } 
    }
}
