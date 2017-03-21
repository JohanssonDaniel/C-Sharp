using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Program
    {
        const string folderPath = @"../../res/";

        static void Main(string[] args)
        {
            string option   = "";
            string fileName = "";
            string filePath = "";

            List<string> fileNames  = new List<string>();
            List<string> input      = new List<string>();

            HuffmanNode node                       = null;
            Dictionary<char, int> freqTable        = null;
            Dictionary<int, string> map            = null;
            List<KeyValuePair<char, int>> freqList = null;

            fileNames = loadAvailableFiles();

            while (!option.Equals("7"))
            {
                printWelcomeMessage(fileName);

                option = readMenuOption();

                switch (option)
                {
                    case "1":
                        printFileNames(fileNames);
                        fileName = readFileOption(fileNames);
                        filePath = folderPath + fileName;
                        input    = File.ReadAllLines(filePath).ToList();
                        break;
                    case "2":
                        if (input.Equals(""))
                        {
                            Console.WriteLine("Need to select file to encode");
                        }
                        else
                        {
                            freqTable = Encoding.BuildFreqTable(input);
                            freqList  = freqTable.ToList();
                            freqList.Sort(
                                            delegate (KeyValuePair<char, int> kvp1,
                                            KeyValuePair<char, int> kvp2)
                                            {
                                                return kvp1.Value.CompareTo(kvp2.Value);
                                            });
                        }
                        break;
                    case "3":
                        if (freqList == null) Console.WriteLine("Need to build frequency table first");
                        else node = Encoding.BuildEncodingTree(freqList);
                        break;
                    case "4":
                        if (node == null) Console.WriteLine("Need to build encoding tree first");
                        else map = Encoding.BuildMap(node);
                        break;
                    case "5":
                        if (map == null) Console.WriteLine("Need to build encoding map first");
                        else {
                            using (FileStream fs = new FileStream(folderPath + "/output/" + fileName, FileMode.Create))
                            {
                                Encoding.EncodeData(input, map, fs);
                                fs.Seek(0, SeekOrigin.Begin);
                            }

                        }
                        break;
                    case "7":
                        Console.WriteLine("\nGoodbye...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong input...");
                        break;
                }
            }

            Console.ReadLine();
        }
        
        /// <summary>
        /// Retrieve all filenames in folderPath
        /// </summary>
        /// <returns>List of available files</returns>
        private static List<string> loadAvailableFiles()
        {
            var temp = Directory.GetFiles(folderPath, "*.txt").Select(Path.GetFileName);
            return temp.ToList();
        }

        /// <summary>
        /// Welcome the user and display menu and currently selected file
        /// </summary>
        /// <param name="fileName">currently selected file</param>
        private static void printWelcomeMessage(string fileName)
        {
            Console.Clear();
            Console.WriteLine("Current file: {0}", fileName);
            Console.WriteLine("Welcome to my encoding program thas is based on Huffman-encoding");
            Console.WriteLine("1) Select file to encode");
            Console.WriteLine("2) Build frequency table");
            Console.WriteLine("3) Build encoding tree");
            Console.WriteLine("4) Build encoding map");
            Console.WriteLine("5) Build encode file");
        }
        
        /// <summary>
        /// Prompt user to select menu option
        /// </summary>
        /// <returns>Users option</returns>
        private static string readMenuOption()
        {
            Console.Write("Select option: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Print all the given fileNames
        /// </summary>
        /// <param name="fileNames">List of filenames in folderPath</param>
        private static void printFileNames(List<string> fileNames)
        {

            Console.Clear();
            Console.WriteLine("Currently available files\n");

            foreach (string fileName in fileNames)
            {
                Console.WriteLine(fileName);
            }

        }

        /// <summary>
        /// Prompt user to input a valid filename
        /// </summary>
        /// <param name="fileNames">List of all available files</param>
        /// <returns>name of selected file</returns>
        private static string readFileOption(List<string> fileNames)
        {
            string readFile = "";

            Console.WriteLine();
            Console.Write("Select which file you want to compress; ");

            readFile = Console.ReadLine();

            if (fileNames.Contains(readFile))
            {
                Console.WriteLine("Found it!");
            }
            else
            {
                Console.WriteLine("Couldn't find the file named {0}. Please try again", readFile);
            }

            Console.ReadLine();
            return readFile;
        }
    }
}
