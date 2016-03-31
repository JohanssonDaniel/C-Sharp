using System;
using System.Collections.Generic;

namespace euler_project
{
    class Even_Fibonacci_Numbers
    {
        public void algorithm()
        {
            const int FIB_MAX_VAL = 4000000;

            int prev = 1, curr = 2, sum = 0;
            int temp;

            Console.WriteLine("Previous value:  {0}", prev);

            while (curr <= FIB_MAX_VAL)
            {
                temp = curr;
                curr = curr + prev;
                prev = temp;

                Console.WriteLine("Previous value:  {0}", prev);

                if (prev % 2 == 0)
                {
                    sum += prev;
                    Console.WriteLine("New sum:  {0}", sum);
                }
            }
        }
    }
}
