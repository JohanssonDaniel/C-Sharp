using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedurallyGeneration
{
    class Program
    {
        private const int MAXROOMSIZE  = 8;
        private const int MINROOMSIZE  = 3;

        private const int XMAX = 20;
        private const int YMAX = 20;

        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();

            string[][] printRooms = new string[YMAX][];

            for (int i = 0; i < printRooms.Length; i++)
            {
                printRooms[i] = new string[XMAX];
                for (int j = 0; j < printRooms[i].Length; j++)
                {
                    printRooms[i][j] = "*";
                }
            }

            //Create a new random room
            Random random = new Random();
            int randomWidth = random.Next(MINROOMSIZE, MAXROOMSIZE);
            int randomHeight = random.Next(MINROOMSIZE, MAXROOMSIZE);
            int randomX = random.Next(0, XMAX);
            int randomY = random.Next(0, YMAX);

            rooms.Add(new Room(randomWidth, randomHeight, randomX, randomY));

            foreach (Room room in rooms)
            {
                for (int y = room.Y1; y < room.Y2; y++)
                {
                    for (int x = room.X1; x < room.X2; x++)
                    {
                        printRooms[y][x] = " ";
                    }  
                }   
            }

            for (int row = 0; row < YMAX; row++)
            {
                for (int col = 0; col < XMAX; col++)
                {
                    Console.Write(printRooms[row][col]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
