using System;
using System.Collections.Generic;
using System.Linq;

namespace euler_project
{
    class Largest_Palindrome_Product
    {
        public void algorithm()
        {
            const int LARGEST_PRODUCT = 999;
            int product = 0;
            int largest_pal = 0;

            for (int i = LARGEST_PRODUCT; i > 1; i--)
            {
                for (int j = LARGEST_PRODUCT; j > 1; j--)
                {
                    product = j * i;
                    if (product > largest_pal && is_palindrome(product))
                    {
                        largest_pal = product;
                    }
                }
            }
            Console.WriteLine("Largest palindrome: {0}", largest_pal);
        }

        private bool is_palindrome(int val)
        {
            string og_val = val.ToString();
            string reverse_val = new string(og_val.ToCharArray().Reverse().ToArray());

            return og_val.Equals(reverse_val, StringComparison.Ordinal);
        }
    }
}
