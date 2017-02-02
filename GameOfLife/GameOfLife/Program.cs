using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        /* Constants for the different tile types. */
        const char LIVINGCELL = 'X';
        const char EMPTYCELL = '-';

        static void Main(string[] args)
        {

            String[] input;
            OpenUserFile(out input);
            int rows = Int32.Parse(input[0]);
            int cols = Int32.Parse(input[1]);
            Grid grid = new Grid(rows,cols);

            LoadWorld(ref grid, ref input);
            RunSimulation(ref grid);
            Console.ReadLine();
        }

        private static void RunSimulation(ref Grid grid)
        {
            string option;
            while (true)
            {
                Console.Write("a)nimate, t)tick, q)uit? ");
                option = Console.ReadLine();

                if (option.Equals("a"))
                {
                    AnimateWorld(ref grid);
                }
                else if (option.Equals("t"))
                {
                    TickLife(ref grid);
                }
                else if (option.Equals("q"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option...");
                }
            }
            
        }

        private static void AnimateWorld(ref Grid grid)
        {
            while (true)
            {
                TickLife(ref grid);
                System.Threading.Thread.Sleep(100);
            }
        }

        private static void TickLife(ref Grid grid)
        {
            Console.Clear();
            grid.PrintGrid();
            Grid tempGrid = new Grid(grid.NumOfRows,grid.NumOfCols);

            for (int row = 0; row < grid.NumOfRows; ++row)
            {
                for (int col = 0; col < grid.NumOfRows; ++col)
                {
                    int NumOfNeigbours = FindNumOfNeighbours(grid, row, col);
                    if (NumOfNeigbours <= 1)
                    {
                        tempGrid.SetGrid(row, col, EMPTYCELL);
                    }
                    else if (NumOfNeigbours == 2)
                    {
                        tempGrid.SetGrid(row, col, grid.GetGrid(row, col));
                    }
                    else if (NumOfNeigbours == 3)
                    {
                        tempGrid.SetGrid(row, col, LIVINGCELL);
                    }
                    else {
                        tempGrid.SetGrid(row, col, EMPTYCELL);
                    }
                }
            }
            grid = tempGrid;
        }

        private static int FindNumOfNeighbours(Grid grid, int row, int col)
        {
                int[] rowValues = { row - 1,   row,      row + 1,  row - 1,  row + 1,  row - 1,  row,      row + 1};
                int[] colValues = { col - 1,   col - 1,  col - 1,  col,      col,      col + 1,  col + 1,  col + 1};

                int noNeighbours = 0;

                // Count neighbours algorithm
                for (int i = 0; i < 8; i++)
                {
                    if (grid.IsInBounds(rowValues[i], colValues[i]))
                    {
                        if (grid.GetGrid(rowValues[i], colValues[i]) == 'X')
                        {
                            noNeighbours++;
                        }
                    }
                }
                return noNeighbours;
            }

        private static void LoadWorld(ref Grid grid, ref string[] input)
        {
            grid.NumOfRows = Int32.Parse(input[0]);
            grid.NumOfCols = Int32.Parse(input[1]);

            string temp_row;

            for (int i = 0; i < grid.NumOfRows; i++)
            {
                temp_row = input[i+2];
                for (int j = 0; j < grid.NumOfCols; j++)
                {
                    grid.SetGrid(i, j, temp_row.ElementAt(j));
                }
            }
        }

        private static void OpenUserFile(out string[] input)
        {
            while (true)
            {
                string filePath = @"C:\Users\DannePanne\Documents\Arbeten\c-sharp\GameOfLife\GameOfLife\res\";
                Console.Write("Enter filename: ");
                filePath += Console.ReadLine();
                if (File.Exists(filePath))
                {
                    input = File.ReadAllLines(filePath);
                    break;
                }
                else
                {
                    Console.Write("File not found...");
                }
            }
            
        }
    }
}
