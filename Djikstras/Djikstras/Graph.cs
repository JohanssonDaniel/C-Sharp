using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    class Graph
    {
        const char WALL     = '#';
        const char START    = 'S';
        const char GOAL     = 'G';
        const char MUD      = ' ';
        const char MONSTER  = 'm';

        private Dictionary<char, int> cost = new Dictionary<char, int>() { { START, 0 }, { GOAL, 0 }, { MUD, 1 }, { MONSTER, 11 } };

        private List<Node> nodes = new List<Node>();
        private List<Edge> edges = new List<Edge>();

        private Node Start, Goal;

        private char[][] grid;

        public Graph(string[] file)
        {
            grid = createGrid(file);
            nodes = createNodeList(grid);
            edges = createEdgeList(nodes);
        }

        private char[][] createGrid(string[] file)
        {
            // Assuming here that every maze will be quadratic, the length of the col is same for every row
            int numOfRows = file.Length;
            //int numOfCols = file[0].Length;

            // Init the graph, it will contain the same amount of rows as the input
            char[][] grid = new char[numOfRows][];

            // Init the rows
            for (int row = 0; row < numOfRows; row++)
            {
                grid[row] = file[row].ToCharArray();
            }

            return grid;
        }

        private List<Node> createNodeList(char[][] grid)
        {
            List<Node> nodeList = new List<Node>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    char mazeCharacter = grid[row][col];
                    if (!(mazeCharacter.Equals(WALL)))
                    {
                        Node tempNode = new Node(cost[mazeCharacter], mazeCharacter, col, row);
                        if (mazeCharacter.Equals(START))
                        {
                            Start = tempNode;
                        }
                        else if (mazeCharacter.Equals(GOAL))
                        {
                            Goal = tempNode;
                        }
                        nodeList.Add(tempNode);
                    }
                }
            }
            return nodeList;
        }

        private List<Edge> createEdgeList(List<Node> nodes)
        {
            List<Edge> edgeList = new List<Edge>();
            foreach (Node node in nodes)
            {
                foreach (Node tempNode in nodes)
                {
                    if (isNeighbour(node, tempNode) && !edgeList.Contains(new Edge(tempNode, node)))
                    {
                        Edge tempEdge = new Edge(node, tempNode);
                        edgeList.Add(tempEdge);
                    }
                }
            }
            return edgeList;
        }

        public List<Node> findShortestPath()
        {
            List<Node> Q = new List<Node>();

            foreach (Node node in nodes)
            {
                node.PreviousNode = null;
                Q.Add(node);
            }

            while (Q.Any())
            {
                Node u = findCheapestNode(Q);
                Q.Remove(u);
                foreach (Node v in Q)
                {
                    if (isNeighbour(u,v))
                    {
                        int alt = u.Cost + length(u, v);
                        if (alt < v.Cost)
                        {
                            v.Cost = alt;
                            v.PreviousNode = u;
                        }
                    }
                }  
            }
            return Q;
        }

        private int length(Node u, Node v)
        {
            return u.Cost + cost[v.TypeOfNode];
        }

        private Node findCheapestNode(List<Node> q)
        {
            Node temp = q[0];
            foreach (Node node in q)
            {
                if (node.Cost < temp.Cost)
                {
                    temp = node;
                }
            }
            return temp;
        }

        

        

        private bool isNeighbour(Node node, Node temp)
        {
            int x = node.X;
            int y = node.Y;

            int[] xValues = { x, x + 1, x, x - 1 };
            int[] yValues = { y - 1, y, y + 1, y };

            for (int i = 0; i < xValues.Length; i++)
            {
                if ((xValues[i] == temp.X) && (yValues[i] == temp.Y))
                {
                    return true;
                }
            }
            return false;
        }


        

        public void PrintGraph()
        {
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge.ToString());
            }
        }
    }
}
