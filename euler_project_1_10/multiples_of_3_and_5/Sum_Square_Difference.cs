using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler_project
{
    class Sum_Square_Difference
    {
        public void algorithm()
        {
            int sum = (int) Math.Pow(Sum_Series(100), 2);
            int sum_power_2 = Sum_Series_Power_2(100);

            int diff = sum - sum_power_2;

            Console.WriteLine("Sum: {0}, sum_series: {1}, diff: {2}", sum, sum_power_2, diff);


        }

        private int Sum_Series(int last)
        {
            return last * (last + 1) / 2;
        }

        private int Sum_Series_Power_2(int last)
        {
            return last * (last + 1) * (2 * last + 1) / 6;
        }
    }
}
