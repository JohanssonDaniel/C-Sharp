using System;
using System.Collections.Generic;

namespace euler_project
{
    class Largest_Prime_Factor
    {
        public void algorithm()
        {
            const long PRIME = 600851475143;
            long dividedPrime = PRIME;

            long fact = 2, biggestFact = 1;

            while (dividedPrime > 1 || fact < dividedPrime)
            {
                if (dividedPrime % fact == 0)
                {
                    dividedPrime = dividedPrime / fact;
                    biggestFact = fact;
                    Console.WriteLine("dividedPrime: {0}, fact: {1}", dividedPrime, fact);
                }
                else
                {
                    fact++;
                }
            }

            Console.WriteLine("Biggest factorial: {0}", biggestFact);
            
        }
    }
}
