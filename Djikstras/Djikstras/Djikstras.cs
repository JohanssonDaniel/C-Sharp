using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    class Djikstras
    {
        public static void findShortestPath(ref Graph graph, ref Stack<Node> path, out int cost)
        {
            setToInfinity(ref graph);

            List<Node> Q = new List<Node>();

            graph.Start.Cost = 0;

            Q.Add(graph.Start);

            while (Q.Any())
            {
                Node u = findCheapestNode(Q);
                u.Visited = true;
                if (u.Equals(graph.Goal))
                {
                    Q.Clear();
                }
                else
                {
                    Q.Remove(u);
                    
                    foreach (Edge edge in u.Edges)
                    {
                        if (!edge.Destination.Visited)
                        {
                            int tempCost = u.Cost + edge.Weight;
                            if (tempCost < edge.Destination.Cost)
                            {
                                edge.Destination.Cost = tempCost;
                                edge.Destination.PreviousNode = u;
                                if (Q.Contains(edge.Destination))
                                {
                                    var tempNode = Q.FirstOrDefault(x => x.Equals(u));
                                    if (tempNode != null) tempNode.Cost = tempCost;
                                }
                                else
                                {
                                    Q.Add(edge.Destination);
                                }
                            }
                        }
                    }
                }
            }
            Node tempV = graph.Goal;
            cost = graph.Goal.Cost;
            while (!tempV.Equals(graph.Start))
            {
                path.Push(tempV);
                tempV = tempV.PreviousNode;
            }
            path.Push(tempV);
        }

        private static void setToInfinity(ref Graph graph)
        {
            foreach (Edge edge in graph.edges)
            {
                edge.Destination.Cost = int.MaxValue;
            }
        }

        private int length(Node u, Node v, ref Graph graph)
        {
            return u.Cost + graph.cost[v.TypeOfNode];
        }

        private static Node findCheapestNode(List<Node> q)
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
    }
}
