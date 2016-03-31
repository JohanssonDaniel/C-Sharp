using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler_project
{
    class Smallest_Multiple
    {
        public void algorithm()
        {
            List<int> facts = new List<int>();
            bool smallestFound = false;
            int smallestMultiple = 1;

            facts.AddRange(Enumerable.Range(1, 20));
            
            while (!smallestFound)
            {
                foreach (int fact in facts)
                {
                    if (smallestMultiple % fact == 0)
                    {
                        smallestFound = true;
                    }
                    else
                    {
                        smallestFound = false;
                        break;
                    }
                }
                smallestMultiple++;
            }
            Console.WriteLine("Smallest multiple: {0}", smallestMultiple);
        }
    }
}
