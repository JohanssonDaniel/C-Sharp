using System;

namespace euler_project
{
    class Pyth_Triplet
    {
        public void algorithm()
        {
            int a=0, b=0, c=0;
            int[] trippleArray = new int[3];

            for (int n = 0; n < 20; n++)
            {

                int m = n + 1;

                do
                {
                    trippleArray = Find_Next_Triple(m, n);

                    a = trippleArray[0];
                    b = trippleArray[1];
                    c = trippleArray[2];

                    if (a + b + c == 1000)
                    {
                        break;
                    }

                    m++;

                } while ((a+b+c)<1000);
            }
            int ans = a * b * c;
            Console.WriteLine("Value of a*b*c = {0}", ans);
        }

        //Taken from https://en.wikipedia.org/wiki/Pythagorean_triple#Generating_a_triple
        private int[] Find_Next_Triple(int m, int n)
        {
            int a = (int) (Math.Pow(m, 2) - Math.Pow(n, 2));
            int b = 2 * m * n;
            int c = (int) (Math.Pow(m, 2) + Math.Pow(n, 2));

            return new int[] {a,b,c};
        }
    }
}
