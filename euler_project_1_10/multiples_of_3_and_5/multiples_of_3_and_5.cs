using System;

namespace euler_project
{
    class multiples_of_3_and_5
    {
        public void algorithm()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of all the multiples of 3 or 5 below 1000 = {0}", sum);
        }
    }
}
