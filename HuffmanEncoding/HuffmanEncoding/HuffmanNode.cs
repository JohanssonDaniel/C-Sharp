using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class HuffmanNode
    {
        public int Character { get; set; }
        public int Count { get; set; }
        public HuffmanNode Zero { get; set; }
        public HuffmanNode One { get; set; }

        public HuffmanNode(int character, int count, 
            HuffmanNode zero, HuffmanNode one)
        {
            Character = character;
            Count = count;
            Zero = zero;
            One = one;
        }

        public bool IsLeaf()
        {
            return Zero == null && One == null;
        }

        public override string ToString()
        {
            switch (Character)
            {
                case 257:
                    return "{Character: NOT, Count: " + Count + "}";
                case 256:
                    return "{Character: EOF, Count: " + Count + "}";
                default:
                    return "{Character: '" + (char)Character + "', Count: " + Count + "}";
            }
        }
    }
}
