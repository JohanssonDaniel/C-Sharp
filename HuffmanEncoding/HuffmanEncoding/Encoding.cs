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
        private const int NOT_A_CHAR = 257;
        private const int PSEUDO_EOF = 256;

        /// <summary>
        /// Count the frequency of all the characters in a string list
        /// </summary>
        /// <param name="fs">FileStream</param>
        /// <returns>Dictionary where keys = letters in input and 
        /// value = frequency of every key </returns>
        public static Dictionary<int, int> BuildFreqTable(FileStream fs)
        {
            Dictionary<int, int> freqTable = new Dictionary<int, int> {{PSEUDO_EOF, 1}};
            byte[] bytes = new byte[fs.Length];

            int numBytesToRead = (int)fs.Length;

            fs.Read(bytes, 0, numBytesToRead);

            foreach (byte tempByte in bytes)
            {
                if (freqTable.ContainsKey(tempByte))
                {
                    freqTable[tempByte]++;
                }
                else
                {
                    freqTable.Add(tempByte, 1);
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
        public static HuffmanNode BuildEncodingTree(List<KeyValuePair<int, int>> freqList)
        {
            Queue<HuffmanNode> treeLevels = new Queue<HuffmanNode>();

            foreach (KeyValuePair<int, int> kvp in freqList)
            {
                HuffmanNode node = new HuffmanNode(kvp.Key, kvp.Value, null, null);
                treeLevels.Enqueue(node);
            }

            while (treeLevels.Count() != 1)
            {
                HuffmanNode left  = treeLevels.Dequeue();
                HuffmanNode right = treeLevels.Dequeue();
                int sum           = left.Count + right.Count;
                HuffmanNode node  = new HuffmanNode(NOT_A_CHAR, sum, left, right);

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
        public static Dictionary<int, string> BuildCodingMap(HuffmanNode encodingTree)
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

        public static void EncodeData(FileStream fs, Dictionary<int, string> map, FileStream fsNew)
        {
            byte[] bytes = new byte[fs.Length];
            byte inputByte = 0;
            int timesShifted = 0;
            int numBytesToRead = (int)fs.Length;

            fs.Read(bytes, 0, numBytesToRead);

            foreach (byte tempByte in bytes)
            {
                string tempCode = map[tempByte];
                foreach (char bit in tempCode)
                {
                    inputByte <<= 1;
                    timesShifted++;

                    if (bit.Equals('1'))
                    {
                        inputByte |= 0x1;
                    }

                    if (timesShifted != 8) continue;
                    fsNew.WriteByte(inputByte);

                    timesShifted = 0;
                    inputByte = 0;
                }
            } 
        }
    }
}
