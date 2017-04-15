using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    public class Edge : IEquatable<Edge>
    {
        public Node Source { get; set; }
        public Node Destination { get; set; }

        public int Weight { get; set; }

        public Edge(Node s, Node d)
        {
            Source = s;
            Destination = d;
        }

        public bool Equals(Edge edge)
        {
            if(edge == null) return false;
            return (this.Source == edge.Source || this.Source == edge.Destination) &&
                (this.Destination == edge.Source || this.Destination == edge.Destination
                ); 
        }

        public override string ToString()
        {
            return Source + "-" + Destination;
        }
    }
}
