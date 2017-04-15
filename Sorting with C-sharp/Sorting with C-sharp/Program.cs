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
            List<int> unsortedList = new List<int>{ 3, 7, 4, 9, 5, 2, 6, 1 };
            List<int> correctList  = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 9 };

            unsortedList = InsertionSort.Sort(unsortedList);

            foreach (int item in unsortedList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(unsortedList.SequenceEqual(correctList) ? "Sort successful" : "Sort failed");

            Console.ReadLine();
        }
    }
}
