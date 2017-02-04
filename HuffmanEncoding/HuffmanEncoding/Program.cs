using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\DannePanne\Documents\Arbeten\c-sharp\HuffmanEncoding\HuffmanEncoding\res\dictionary.txt");

            Dictionary<char, int> freqTable = Encoding.BuildFreqTable(input);

            var sortedDict = from entry in freqTable
                             orderby entry.Value descending
                             select entry;

            Console.ReadLine();
        }
    }
}
