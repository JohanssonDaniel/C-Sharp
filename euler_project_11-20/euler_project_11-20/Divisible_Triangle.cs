using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler_project_11_20
{
    class Divisible_Triangle
    {
        public void algorithm() {
            const int NO_DIVISORS = 500;

            int fact = 2;
            int triangle = 0;

            Dictionary<int, int> primeFactors = new Dictionary<int, int>();
            primeFactors.Add(1, 1); 

            for (int i = 2; i < int.MaxValue; i++)
            {
                int tempTriangle = Generate_Triangle_Number(i);
                triangle = tempTriangle;

                double maxPrime = Math.Sqrt(tempTriangle);

                fact = 2;

                primeFactors.Clear();

                primeFactors.Add(1, 1);

                while (fact <= triangle)
                {
                    if (tempTriangle % fact == 0)
                    {
                        if (primeFactors.ContainsKey(fact))
                        {
                            primeFactors[fact] += 1;
                        }
                        else
                        {
                            primeFactors.Add(fact, 1);
                        }
                    }
                    fact++;
                }
                if(No_Divisors(primeFactors) >= NO_DIVISORS) break;
            }
            Console.WriteLine("Triangle number with {0} divisors: {1}", NO_DIVISORS, triangle);
        }
        private int Generate_Triangle_Number(int n)
        {
            int triangleNumber = 0;
            for (int i = 0; i <= n; i++)
            {
                triangleNumber += i;
            }

            return triangleNumber;
        }

        // Taken from http://mathschallenge.net/library/number/number_of_divisors
        private int No_Divisors(Dictionary<int,int> primeFactors)
        {
            int NoDivisors = 0;

            foreach (KeyValuePair<int, int> prime in primeFactors)
            {
                NoDivisors += prime.Value;
            }

            return NoDivisors;
        }
    }
}
