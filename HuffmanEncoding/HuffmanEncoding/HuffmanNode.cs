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
        public char character;
        public int count;
        public HuffmanNode zero;
        public HuffmanNode one;

        public HuffmanNode(char character, int count, 
            HuffmanNode zero, HuffmanNode one)
        {
            Character = character;
            Count = count;
            this.zero = zero;
            this.one = one;
        }

        public char Character
        {
            get { return character;  }
            set { character = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public HuffmanNode Zero
        {
            get { return zero; }
            set { zero = value; }
        }

        public HuffmanNode One
        {
            get { return one; }
            set { one = value; }
        }

        public bool IsLeaf()
        {
            return Zero == null && One == null;
        }

        public void printNode()
        {
            Console.WriteLine($"Character: {Character}");
            Console.WriteLine($"Count: {Count}");
        }
    }
}
