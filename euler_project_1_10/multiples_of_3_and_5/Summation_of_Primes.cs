using System;

namespace euler_project
{
    class Summation_of_Primes
    {
        public void algorithm()
        {
            const long MAX_PRIME = 2000000;

            long sum = 0;

            for (int i = 3; i < MAX_PRIME; i+=2)
            {
                if (Is_Prime(i))
                {
                    sum += i;
                }
            }

            Console.WriteLine("Sum of primes below {0} = {1}", MAX_PRIME, sum);
        }

        //Taken from https://en.wikipedia.org/wiki/Primality_test#Pseudocode
        private bool Is_Prime(int val)
        {
            int i = 5;
            if (val <= 1) return false;

            else if (val <= 3) return true;

            else if ((val % 2 == 0) || (val % 3 == 0)) return false;

            while (i * i <= val)
            {
                if ((val % i == 0) || (val % (i + 2) == 0))
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}
