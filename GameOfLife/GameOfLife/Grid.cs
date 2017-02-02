using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Grid
    {
        private int numOfRows;
        private int numOfCols;

        private char[][] grid;
        
        public Grid(int nRows, int nCols)
        {
            NumOfRows = nRows;
            NumOfCols = nCols;
            InitGrid();
        }

        private void InitGrid()
        {
            grid = new char[NumOfRows][];
            for (int i = 0; i < NumOfRows; i++)
            {
                grid[i] = new char[NumOfCols]; 
            }
        }

        public int NumOfRows
        {
            get { return numOfRows; }
            set { numOfRows = value; }
        }

        public int NumOfCols
        {
            get { return numOfCols; }
            set { numOfCols = value; }
        }

        public char GetGrid(int row, int col)
        {
            char value = ' ';
            if (IsInBounds(row, col))
            {
                value = grid[row][col];
            }
            return value;
        }

        public void SetGrid(int row, int col, char value)
        {
            if (IsInBounds(row, col))
            {
                grid[row][col] = value;
            }
        }

        public bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < numOfRows && col >= 0 && col < numOfCols;
        }

        public void PrintGrid()
        {
            for (int i = 0; i < NumOfRows; i++)
            {
                Console.WriteLine(grid[i]);
            }
        }
    }
}
