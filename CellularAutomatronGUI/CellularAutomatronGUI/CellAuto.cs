using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomatronGUI
{
    class CellAuto
    {
        public string[][] Grid;

        // Represents the total available rules (up to 256)
        private static readonly List<string> CellAutoRules = new List<string>()
            {"***", "** ", "* *", "*  ", " **", " * ", "  *", "   "};

        private static List<string> _listOfRules;

        public CellAuto(int numOfRows, int numOfCols, int ruleNumber)
        {
            InitGrid(numOfRows, numOfCols);
            InitRules(ruleNumber);
            GenerateCellularAutomaton(numOfRows, numOfCols);    
        }

        private void GenerateCellularAutomaton(int numOfRows, int numOfCols)
        {
            for (int row = 1; row < numOfRows; row++)
            {
                for (int col = 0; col < numOfCols - 2; col++)
                {
                    Grid[row][col + 1] = GetGridValue(row, col);
                }
            }
        }

        private string GetGridValue(int row, int col)
        {
            string[] gridRow = Grid[row - 1];
            string cellAndNeighbours = $"{gridRow[col]}{gridRow[col + 1]}{gridRow[col + 2]}";
            // Find the rule that match the string
            string rule = _listOfRules.Find(kvp => kvp.Equals(cellAndNeighbours));
            // If the rule is found return '*' otherwise ' '
            return rule != null ? "*" : " ";
        }

        private void InitRules(int ruleNumber)
        {
            // Convert the rules to a binary string representation
            List<char> bin = Convert.ToString(ruleNumber, 2).ToList();
            // The bin list determines which rules to pick (value 1) 
            // Sometimes the list will be made to small which cases indexing problems
            // It is therefore increased with 0:s
            for (int i = bin.Count; i < CellAutoRules.Count; i++)
            {
                bin.Insert(0, '0');
            }
            _listOfRules = CellAutoRules.Where((t, i) => bin[i] == '1').ToList();
        }

        private void InitGrid(int numOfRows, int numOfCols)
        {
            Grid = new string[numOfRows][];

            for (int row = 0; row < Grid.Length; row++)
            {
                Grid[row] = new string[numOfCols];
            }

            foreach (string[] row in Grid)
            {
                for (int col = 0; col < row.Length; col++)
                {
                    row[col] = " ";
                }
            }

            Grid[0][numOfCols / 2] = "*";
        }

        public void PrintGrid()
        {
            foreach (string[] row in Grid)
            {
                foreach (string c in row)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
}
