﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Program
    {
        const string filePath = @"C:\Users\DannePanne\Documents\Arbeten\c-sharp\HuffmanEncoding\HuffmanEncoding\res\dictionary.txt";

        static void Main(string[] args)
        {

            string[] input = System.IO.File.ReadAllLines(filePath);
            Dictionary<char, int> freqTable = Encoding.BuildFreqTable(input);

            List<KeyValuePair<char, int>> freqList = freqTable.ToList();

            freqList.Sort(
                delegate(KeyValuePair<char, int> kvp1,
                KeyValuePair<char, int> kvp2){
                    return kvp1.Value.CompareTo(kvp2.Value); 
                });

            HuffmanNode node = Encoding.BuildEncodingTree(freqList);

            Dictionary<int, string> map = Encoding.BuildMap(node);



            Encoding.EncodeData(input, map, filePath);

            Console.ReadLine();
        }
    }
}
