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

            List<KeyValuePair<char, int>> freqList = freqTable.ToList();

            freqList.Sort(
                delegate(KeyValuePair<char, int> kvp1,
                KeyValuePair<char, int> kvp2){
                    return kvp1.Value.CompareTo(kvp2.Value); 
                });
            Encoding.BuildEncodingTree(freqList);



            Console.ReadLine();
        }
    }
}
