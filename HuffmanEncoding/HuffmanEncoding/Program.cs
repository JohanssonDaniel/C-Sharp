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
        private const string FolderPath = @"../../res/";

        static void Main(string[] args)
        {
            string option   = "";
            string fileName = "";
            string filePath = "";

            List<string> input = new List<string>();

            HuffmanNode node                       = null;
            Dictionary<int, string> map            = null;
            List<KeyValuePair<int, int>> freqList  = null;

            var fileNames = LoadAvailableFiles();
            while (!option.Equals("7"))
            {
                PrintWelcomeMessage(fileName);

                option = ReadMenuOption();

                switch (option)
                {
                    case "1":
                        PrintFileNames(fileNames);
                        fileName = ReadFileOption(fileNames);
                        filePath = FolderPath + fileName;
                        input    = File.ReadAllLines(filePath).ToList();
                        break;
                    case "2":
                        if (!input.Any())
                        {
                            Console.WriteLine("Need to select file to encode");
                        }
                        else
                        {
                            Dictionary<int, int> freqTable = null;
                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                freqTable = Encoding.BuildFreqTable(fs);
                                DisplayFreqTable(freqTable);
                            }
                            freqList  = freqTable.ToList();
                            freqList.Sort(
                                (kvp1, kvp2) => kvp1.Value.CompareTo(kvp2.Value));
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        if (freqList == null)
                        {
                            Console.WriteLine("Need to build frequency table first");
                        }
                        else
                        {
                            node = Encoding.BuildEncodingTree(freqList);
                            DisplayEncodingTree(node, "");
                            Console.Write("Press enter to return to menu");
                        }
                        Console.ReadLine();
                        break;
                    case "4":
                        if (node == null)
                        {
                            Console.WriteLine("Need to build encoding tree first");
                        }
                        else
                        {
                            map = Encoding.BuildMap(node);
                            DisplayEncodingMap(map);
                        }
                        Console.ReadLine();
                        break;
                    case "5":
                        if (map == null)
                        {
                            Console.WriteLine("Need to build encoding map first");
                        }
                        else {
                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                using (FileStream fsNew = new FileStream(FolderPath + "/output/" + fileName, FileMode.Create))
                                {
                                    Encoding.EncodeData(fs, map, fsNew);
                                }
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

        private static void DisplayEncodingMap(Dictionary<int, string> map)
        {
            foreach (KeyValuePair<int, string> pair in map)
            {
                if (pair.Key == 256)
                {
                    Console.WriteLine(pair.Key + ": EOF" + " =>" + pair.Value);
                }
                else
                {
                    Console.WriteLine(pair.Key + ":\t" + (char) pair.Key + " =>" + pair.Value);
                }
            }
        }

        private static void DisplayEncodingTree(HuffmanNode node, string indent)
        {
            if (node == null)
            {
                return;
            }
            DisplayEncodingTree(node.One, indent + " ");
            Console.WriteLine(indent + node);
            DisplayEncodingTree(node.Zero, indent + " ");
        }

        private static void DisplayFreqTable(Dictionary<int, int> freqTable)
        {
            Console.WriteLine("\nFound key => key frequency");
            foreach (KeyValuePair<int, int> kvp in freqTable)
            {
                Console.WriteLine("{0} => {1}", kvp.Key, kvp.Value);
            }
            Console.Write("Press enter to return to menu");
        }

        /// <summary>
        /// Retrieve all filenames in folderPath
        /// </summary>
        /// <returns>List of available files</returns>
        private static List<string> LoadAvailableFiles()
        {
            var temp = Directory.GetFiles(FolderPath, "*.txt").Select(Path.GetFileName);
            return temp.ToList();
        }

        /// <summary>
        /// Welcome the user and display menu and currently selected file
        /// </summary>
        /// <param name="fileName">currently selected file</param>
        private static void PrintWelcomeMessage(string fileName)
        {
            Console.Clear();
            Console.WriteLine("Current file: {0}", fileName);
            Console.WriteLine("Welcome to my encoding program thas is based on Huffman-encoding");
            Console.WriteLine("1) Select file to encode");
            Console.WriteLine("2) Build frequency table");
            Console.WriteLine("3) Build encoding tree");
            Console.WriteLine("4) Build encoding map");
            Console.WriteLine("5) Build encode file");
            Console.WriteLine("7) Exit program");
        }
        
        /// <summary>
        /// Prompt user to select menu option
        /// </summary>
        /// <returns>Users option</returns>
        private static string ReadMenuOption()
        {
            Console.Write("Select option: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Print all the given fileNames
        /// </summary>
        /// <param name="fileNames">List of filenames in folderPath</param>
        private static void PrintFileNames(List<string> fileNames)
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
        private static string ReadFileOption(List<string> fileNames)
        {
            string readFile = "";
            while (true)
            {
                Console.Clear();
                PrintFileNames(fileNames);
                Console.WriteLine();
                Console.Write("Select which file you want to compress; ");

                readFile = Console.ReadLine();

                if (fileNames.Contains(readFile))
                {
                    Console.WriteLine("Found it!");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Couldn't find the file named {0}. Please try again", readFile);
                }

                Console.ReadLine();
            }
            return readFile;
        }
    }
}
