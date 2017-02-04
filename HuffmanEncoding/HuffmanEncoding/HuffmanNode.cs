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
        public int character;
        public int count;
        public HuffmanNode zero;
        public HuffmanNode one;

        public HuffmanNode(int character, int count)
        {
            Character = character;
            Count = count;
        }

        public int Character
        {
            get { return character;  }
            set { character = value; }
        }

        public int Count
        {
            get { return Count; }
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
    }
}
