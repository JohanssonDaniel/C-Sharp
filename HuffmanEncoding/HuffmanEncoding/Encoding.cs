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


        /// <summary>
        /// Count the frequency of all the characters in a string list
        /// </summary>
        /// <param name="input">List of strings</param>
        /// <returns>Dictionary where keys = letters in input and 
        /// value = frequency of every key </returns>
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

        /// <summary>
        /// Build a binary tree where each node have a key and a value from the frequency list
        /// The left and right children of a node is the next values in the sorted input freqList
        /// </summary>
        /// <param name="freqList">List sorted by the value (descending)</param>
        /// <returns>
        ///     Returns a tree where the root node is 
        ///     the key (char) with the largest value (frequency)
        /// </returns>
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

        /// <summary>
        /// Create an encoding dictionary by calling the recursive endocing helper
        /// </summary>
        /// <param name="encodingTree">Binary tree with Huffman-nodes</param>
        /// <returns>Dictionary were the key is the character that is encoded 
        /// and the value is the string that the key will be replaced by</returns>
        public static Dictionary<int, string> BuildMap(HuffmanNode encodingTree)
        {
            Dictionary<int, string> encodingMap = new Dictionary<int, string>();
            string code = "";
            EncodingHelper(encodingTree, code, ref encodingMap);
            return encodingMap;
        }

        /// <summary>
        /// Traverses the tree and adds a "0" or a "1" to the childs coding depending which
        /// side (left/right) of the parent node it is placed on
        /// </summary>
        /// <param name="encodingTree">Binary tree containing Huffman-nodes</param>
        /// <param name="code">binary string that will represent the coding of a character</param>
        /// <param name="encodingMap">Dictionary with key as character and value as code</param>
        private static void EncodingHelper(HuffmanNode encodingTree, string code, 
                                                ref Dictionary<int, string> encodingMap)
        {
            if (encodingTree.IsLeaf())
            {
                encodingMap.Add(encodingTree.Character, code);
            }
            else
            {
                code += "0";
                EncodingHelper(encodingTree.Zero, code, ref encodingMap);
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
