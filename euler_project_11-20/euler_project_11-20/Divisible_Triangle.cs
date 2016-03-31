using System;

namespace euler_project_11_20
{
    class Divisible_Triangle
    {
        public void algorithm() {
            const int NO_DIVISORS = 500;

            int number = 0;
            int i = 1;

            while (NumberOfDivisors(number) < NO_DIVISORS)
            {
                number += i;
                i++;
            }
            Console.WriteLine("Triangle number with {0} divisors: {1}", NO_DIVISORS, number);
        }

        private int NumberOfDivisors(int number)
        {
            int nod = 0;
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    nod += 2;
                }
            }
            //Correction if the number is a perfect square
            if (sqrt * sqrt == number)
            {
                nod--;
            }

            return nod;
        }
    }
}
