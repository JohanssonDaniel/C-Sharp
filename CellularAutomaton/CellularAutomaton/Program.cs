using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    class Program
    {
        private static char[][] _grid = new char[50][];
        // Represents the total available rules (up to 256)
        private static readonly List<KeyValuePair<string,string>> CellAutoRules = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("***", " "),
            new KeyValuePair<string, string>("** ", " "),
            new KeyValuePair<string, string>("*  ", " "),
            new KeyValuePair<string, string>(" **", "*"),
            new KeyValuePair<string, string>(" * ", "*"),
            new KeyValuePair<string, string>("  *", "*"),
            new KeyValuePair<string, string>("   ", " ")
        };

        private static List<KeyValuePair<string, string>> _currentRules;

        static void Main(string[] args)
        {
            InitGrid();
            InitRules();

            PrintGrid();
            Console.ReadLine();
        }

        private static void InitRules()
        {
            byte ruleNumber = 30;
            // Convert the rules to a binary string representation
            char[] bin = Convert.ToString(ruleNumber, 2).ToCharArray();
            _currentRules = CellAutoRules.Where((t, i) => bin[i] == '1').ToList();
        }

        private static void InitGrid()
        {
            for (int row = 0; row < _grid.Length; row++)
            {
                _grid[row] = new char[50];
            }

            _grid[0][24] = '*';
        }

        private static void PrintGrid()
        {
            foreach (char[] row in _grid)
            {
                foreach (char c in row)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
}
