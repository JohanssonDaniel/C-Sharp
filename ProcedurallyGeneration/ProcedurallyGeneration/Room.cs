using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedurallyGeneration
{
    class Room
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public Room(int w, int h, int x, int y)
        {
            Width = w;
            Height = h;
            X1 = x;
            X2 = x + w;
            Y1 = y;
            Y2 = y + h;
        }
    }
}
