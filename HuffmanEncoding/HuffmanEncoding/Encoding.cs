using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Encoding
    {
        private const char NOT_A_CHAR = ' ';

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
        
        public static HuffmanNode BuildEncodingTree(List<KeyValuePair<char, int>> freqList)
        {
            Queue<HuffmanNode> treeLevels = new Queue<HuffmanNode>();

            foreach (KeyValuePair<char, int> kvp in freqList)
            {
                HuffmanNode node = new HuffmanNode(kvp.Key, kvp.Value, null, null);
                treeLevels.Enqueue(node);
            }

            while (treeLevels.Count() != 1)
            {
                HuffmanNode left = treeLevels.Dequeue();
                HuffmanNode right = treeLevels.Dequeue();
                int sum = left.Count + right.Count;
                HuffmanNode node = new HuffmanNode(NOT_A_CHAR, sum, left, right);

                treeLevels.Enqueue(node);
            }

            return treeLevels.Dequeue();
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
