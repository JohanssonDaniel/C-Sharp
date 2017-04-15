using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    public class Graph
    {
        const char WALL     = '#';
        const char START    = 'S';
        const char GOAL     = 'G';
        const char MUD      = ' ';
        const char MONSTER  = 'm';

        public Dictionary<char, int> cost = new Dictionary<char, int>() { { START, 0 }, { GOAL, 1 }, { MUD, 1 }, { MONSTER, 11 } };

        public Node[][] nodes;
        public List<Edge> edges = new List<Edge>();

        public Node Start { get; set; }
            
        public Node Goal { get; set; }

        public char[][] Grid { get; set; }

        public Graph(string[] file)
        {
            Grid = createGrid(file);
        }

        private char[][] createGrid(string[] file)
        {
            // Assuming here that every maze will be quadratic, the length of the col is same for every row
            int numOfRows = file.Length;

            // Init the graph, it will contain the same amount of rows as the input
            char[][] grid = new char[numOfRows][];

            // Init the rows
            for (int row = 0; row < numOfRows; row++)
            {
                grid[row] = file[row].ToCharArray();
            }

            return grid;
        }

        public void createNodes()
        {
            if (Grid.Length == 0)
            {
                Console.WriteLine("You have to create the grid first...");
            }
            else
            {
                initNodeGrid();
                for (int row = 0; row < Grid.Length; row++)
                {
                    for (int col = 0; col < Grid[row].Length; col++)
                    {
                        char mazeCharacter = Grid[row][col];
                        Node tempNode = new Node(mazeCharacter, col, row);
                        if (mazeCharacter.Equals(START))
                        {
                            Start = tempNode;
                        }
                        else if (mazeCharacter.Equals(GOAL))
                        {
                            Goal = tempNode;
                        }
                        nodes[row][col] = tempNode;
                    }
                }
            }
        }

        private void initNodeGrid() {
            nodes = new Node[Grid.Length][];
            for (int i = 0; i < Grid.Length; i++)
            {
                nodes[i] = new Node[Grid[i].Length];
            }
        }

        public void createEdges()
        {
            if (nodes.Length == 0)
            {
                Console.WriteLine("You have to create the nodes first...");
            }
            else
            {
                if (edges.Any()) edges.Clear();
                for (int row = 0; row < nodes.Length; row++)
                {
                    for (int col = 0; col < nodes[row].Length; col++)
                    {
                        Node node = nodes[row][col];
                        if (!node.TypeOfNode.Equals(WALL))
                        {
                            int x = node.X;
                            int y = node.Y;
                            int[] xValues = { x, x + 1, x, x - 1 };
                            int[] yValues = { y - 1, y, y + 1, y };

                            for (int i = 0; i < xValues.Length; i++)
                            {
                                if (inBounds(xValues[i], yValues[i]))
                                {
                                    Node tempNode = nodes[yValues[i]][xValues[i]];
                                    if (tempNode.TypeOfNode != WALL)
                                    {
                                        Edge tempEdge = new Edge(node, tempNode);
                                        tempEdge.Weight = cost[tempNode.TypeOfNode];
                                        edges.Add(tempEdge);
                                        node.Edges.Add(tempEdge);
                                        tempNode.Edges.Add(tempEdge);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool inBounds(int v1, int v2)
        {
            return (v1 > 0 && v1 < Grid.Length) && (v2 > 0 && v2 < Grid.Length);
        }

        public void printGraph() {
            if (nodes != null)
            {
                for (int row = 0; row < nodes.Length; row++)
                {
                    for (int col = 0; col < nodes[row].Length; col++)
                    {
                        Console.Write(nodes[row][col].TypeOfNode);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
