using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_with_C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 3, 7, 4, 9, 5, 2, 6, 1 };
            int[] correctList = { 1, 2, 3, 4, 5, 6, 7, 9 };

            list = InsertionSort.Sort(list);

            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            if (Enumerable.SequenceEqual(list, correctList)) Console.WriteLine("Sort successful");
            else Console.WriteLine("Sort failed");

            Console.ReadLine();
        }
    }
}
