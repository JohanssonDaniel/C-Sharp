using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomaton
{
    class Program
    {
        private static char[][] _grid;
        
        // Represents the total available rules (up to 256)
        private static readonly List<string> CellAutoRules = new List<string>()
            {"***", "** ", "* *", "*  ", " **", " * ", "  *", "   "};

        private static List<string> _listOfRules;

        static void Main(string[] args)
        {
            int numOfCols  = Int32.Parse(args[0]);
            int numOfRows  = Int32.Parse(args[1]);
            int ruleNumber = Int32.Parse(args[2]);

            InitGrid(numOfRows, numOfCols);

            InitRules(ruleNumber);

            GenerateCellularAutomaton(numOfRows, numOfCols);
            
            //PrintRules();
            PrintGrid();

            Console.ReadLine();
        }

        private static void GenerateCellularAutomaton(int numOfRows, int numOfCols)
        {
            bool wrap = false;
            for (int row = 1; row < numOfRows; row++)
            {
                for (int col = 0; col < numOfCols - 2; col++)
                {
                    _grid[row][col + 1] = GetGridValue(row, col);
                }
            }
        }

        private static char GetGridValue(int row, int col)
        {
            char[] gridRow = _grid[row - 1];
            string cellAndNeighbours = $"{gridRow[col]}{gridRow[col + 1]}{gridRow[col + 2]}";
            // Find the rule that match the string
            string rule = _listOfRules.Find(kvp => kvp.Equals(cellAndNeighbours));
            // If the rule is found return '*' otherwise ' '
            return rule != null ? '*' : ' ';
        }

        private static void PrintRules()
        {
            foreach (string rule in _listOfRules)
            {
                Console.WriteLine(rule);
            }
        }

        private static void InitRules(int ruleNumber)
        {
            // Convert the rules to a binary string representation
            List<char> bin = Convert.ToString(ruleNumber, 2).ToList();
            // The bin list determines which rules to pick (value 1) 
            // Sometimes the list will be made to small which cases indexing problems
            // It is therefore increased with 0:s
            for (int i = bin.Count; i < CellAutoRules.Count; i++)
            {
                bin.Insert(0,'0');
            }
            _listOfRules = CellAutoRules.Where((t, i) => bin[i] == '1').ToList();
        }

        private static void InitGrid(int numOfRows, int numOfCols)
        {
            _grid = new char[numOfRows][];

            for (int row = 0; row < _grid.Length; row++)
            {
                _grid[row] = new char[numOfCols];
            }

            foreach (char[] row in _grid)
            {
                for (int col = 0; col < row.Length; col++)
                {
                    row[col] = ' ';
                }
            }

            _grid[0][numOfCols / 2] = '*';
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
