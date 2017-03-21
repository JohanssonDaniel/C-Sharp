using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Encoding
    {
        private const char NOT_A_CHAR = ' ';

        //Counts the frequency of all the characters in a string list
        public static Dictionary<char, int> BuildFreqTable(List<string> input)
        {
            Dictionary<char, int> freqTable = new Dictionary<char, int>();

            foreach (string line in input)
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

        public static Dictionary<int, string> BuildMap(HuffmanNode encodingTree)
        {
            Dictionary<int, string> encodingMap = new Dictionary<int, string>();
            string code = "";
            EncodingHelper(encodingTree, code, ref encodingMap);
            return encodingMap;
        }

        private static void EncodingHelper(HuffmanNode encodingTree, string code, ref Dictionary<int, string> encodingMap)
        {
            if (encodingTree.IsLeaf())
            {
                encodingMap.Add(encodingTree.Character, code);
            }
            else
            {
                code += "0";
                EncodingHelper(encodingTree.Zero, code, ref encodingMap);
                //Remove the added 0 from before
                code = code.Remove(code.Length - 1);
                code += "1";
                EncodingHelper(encodingTree.One, code, ref encodingMap);
            }
        }

        public static void EncodeData(List<string> input, Dictionary<int, string> map, FileStream fs)
        {
            string tempCode = "";
            foreach (string line in input)
            {
                string tempCharacter;
                foreach (char character in line)
                {

                }
            }
        }
    }
}
