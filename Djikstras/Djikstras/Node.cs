using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    class Node : IEquatable<Node>
    {
        public int Cost {get; set;}

        public bool Visited { get; set; }

        public int NodeID { get; }

        public int X { get; set; }
        public int Y { get; set; }

        public char TypeOfNode { get; set; }

        public Node PreviousNode { get; set; }
        private static int id = 0;

        public Node(int cost, char type, int x, int y)
        {
            Cost = cost;
            TypeOfNode = type;
            X = x;
            Y = y;
            NodeID = id++;
        }

        public bool Equals(Node node)
        {
            if (node == null) return false;
            return this.NodeID.Equals(node.NodeID);
        }

        public override string ToString()
        {
            return TypeOfNode.ToString();
        }
    }
}
