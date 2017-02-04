using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Encoding
    {
        public static Dictionary<char, int> BuildFreqTable(string[] input)
        {
            Dictionary<char, int> freqTable = new Dictionary<char, int>();

            List<char[]> inputAsChar = makeToCharList(input);

            foreach (char[] line in inputAsChar)
            {
                foreach (char letter in line)
                {
                    if (freqTable.ContainsKey(letter))
                    {
                        freqTable[letter]++;
                    }
                    else
                    {
                        freqTable.Add(letter, 1);
                    }
                }
            }
            return freqTable;
        }

        private static List<char[]> makeToCharList(string[] input)
        {
            List<char[]> result = new List<char[]>();
            foreach (string line in input)
            {
                result.Add(line.ToCharArray());
            }
            return result;
        }
    }
}
