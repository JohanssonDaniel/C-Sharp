using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler_project
{
    class _10001Prime
    {
        public void algorithm()
        {
            int i = 0;
            int primeIndex = 0;
            while (primeIndex < 10001)
            {
                i++;
                if (Is_Prime(i))
                {
                    primeIndex++;
                }
            }
            Console.WriteLine("10 001st prime = {0}", i);
        }
        //Taken from https://en.wikipedia.org/wiki/Primality_test#Pseudocode
        private bool Is_Prime(int val)
        {
            int i = 5;
            if (val <= 1) return false;

            else if (val <= 3) return true;

            else if ((val % 2 == 0) || (val % 3 == 0)) return false;

            while (i*i<=val)
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
