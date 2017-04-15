using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    internal static class Program
    {
        private const  string FOLDER_PATH = @"../../res/";
        private static string _option    = "";
        private static string _fileName  = "";
        private static string _filePath  = "";

        private static List<string> _input;
        private static HuffmanNode _rootNode;
        private static List<string> _fileNames;
        private static Dictionary<int, string> _codingMap;
        private static List<KeyValuePair<int, int>> _freqList;

        private static void Main(string[] args)
        {
            LoadAvailableFiles();
            while (!_option.Equals("7"))
            {
                PrintWelcomeMessage();
                ReadMenuOption();
                switch (_option)
                {
                    case "1":
                        ChooseFile();
                        TryReadFile();
                        break;
                    case "2":
                        TryBuildFrequencyTable();
                        DisplayFreqTable();
                        Console.ReadLine();
                        break;
                    case "3":
                        TryBuildEncodingTree();
                        DisplayEncodingTree(_rootNode, "");
                        Console.Write("Press enter to return to menu");
                        Console.ReadLine();
                        break;
                    case "4":
                        TryBuildCodingMap();
                        DisplayEncodingMap();
                        Console.ReadLine();
                        break;
                    case "5":
                        TryEncodeFile();
                        break;
                    case "7":
                        Console.WriteLine("\nGoodbye...");
                        break;
                    default:
                        Console.WriteLine("Wrong input...");
                        break;
                }
            }
            Console.ReadLine();
        }

        private static void TryEncodeFile()
        {
            if (_codingMap == null)
            {
                Console.WriteLine("Need to build encoding map first");
            }
            else
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    using (
                        FileStream fsNew = new FileStream(FOLDER_PATH + "/output/" + _fileName,
                            FileMode.Create))
                    {
                        Encoding.EncodeData(fs, _codingMap, fsNew);
                    }
                }
            }
        }

        private static void TryBuildCodingMap()
        {
            if (_rootNode == null)
            {
                Console.WriteLine("Need to build encoding tree first");
                Console.ReadLine();
            }
            else
            {
                _codingMap = Encoding.BuildCodingMap(_rootNode);
            }
        }

        private static void TryBuildEncodingTree()
        {
            if (_freqList == null)
            {
                Console.WriteLine("Need to build frequency table first");
            }
            else
            {
                _rootNode = Encoding.BuildEncodingTree(_freqList);
            }
        }

        private static void TryBuildFrequencyTable()
        {
            if (!_input.Any())
            {
                Console.WriteLine("Need to select file to encode");
            }
            else
            {
                Dictionary<int, int> freqTable;
                using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    freqTable = Encoding.BuildFreqTable(fs);
                }
                _freqList = freqTable.ToList();
                _freqList.Sort(
                    (kvp1, kvp2) => kvp1.Value.CompareTo(kvp2.Value));
            }
        }

        private static void TryReadFile()
        {
            _input = File.ReadAllLines(_filePath).ToList();
        }

        private static void DisplayEncodingMap()
        {
            foreach (KeyValuePair<int, string> pair in _codingMap)
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

        private static void DisplayFreqTable()
        {
            Console.WriteLine("\nFound key => key frequency");
            foreach (KeyValuePair<int, int> kvp in _freqList)
            {
                Console.WriteLine("{0} => {1}", kvp.Key, kvp.Value);
            }
            Console.Write("Press enter to return to menu");
        }

        /// <summary>
        /// Retrieve all filenames in folderPath
        /// </summary>
        private static void LoadAvailableFiles()
        {
            _fileNames = Directory.GetFiles(FOLDER_PATH, "*.txt").Select(Path.GetFileName).ToList();
        }

        /// <summary>
        /// Welcome the user and display menu and currently selected file
        /// </summary>
        private static void PrintWelcomeMessage()
        {
            Console.Clear();
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
        private static void ReadMenuOption()
        {
            Console.Write("Select option: ");
            _option = Console.ReadLine();
        }

        /// <summary>
        /// Print all filenames
        /// </summary>
        private static void PrintFileNames()
        {
            Console.Clear();
            Console.WriteLine("Currently available files\n");

            foreach (string fileName in _fileNames)
            {
                Console.WriteLine(fileName);
            }
        }

        /// <summary>
        /// Prompt user to input a valid filename
        /// </summary>
        private static void ChooseFile()
        {
            while (true)
            {
                Console.Clear();

                PrintFileNames();

                Console.WriteLine();
                Console.Write("Select which file you want to compress; ");

                _fileName = Console.ReadLine();

                if (_fileNames.Contains(_fileName))
                {
                    Console.WriteLine("Found it!");
                    _filePath = FOLDER_PATH + _fileName;
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Couldn't find the file named {0}. Please try again", _fileName);
                    Console.ReadLine();
                }
            }
        }
    }
}