using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the maze
            string[] file = System.IO.File.ReadAllLines("../../res/maze1.txt");
            Graph graph = new Graph(file);
            graph.PrintGraph();
            //graph.FindShortestPath();
            Console.ReadLine();
        }
    }
}
