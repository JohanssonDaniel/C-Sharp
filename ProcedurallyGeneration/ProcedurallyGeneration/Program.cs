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

            string[][] printRooms = InitPrintRooms();

            Console.Write("G)enerate new room: ");
            while (Console.ReadLine().ToLower() == "g" )
            {
                rooms.Add(GenerateRoom());

                printRooms = AddToPrintRooms(rooms, printRooms);

                PrintRooms(printRooms);
                Console.Write("G)enerate new room: ");
            }
        }

        private static void PrintRooms(string[][] printRooms)
        {
            for (int row = 0; row < YMAX; row++)
            {
                for (int col = 0; col < XMAX; col++)
                {
                    Console.Write(printRooms[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static string[][] AddToPrintRooms(List<Room> rooms, string[][] printRooms)
        {
            foreach (Room room in rooms)
            {
                for (int y = room.Y1; y < room.Y2; y++)
                {
                    for (int x = room.X1; x < room.X2; x++)
                    {
                        if (x < XMAX && y < YMAX)
                        {
                            printRooms[y][x] = " ";
                        }
                    }
                }
            }
            return printRooms; 
        }

        private static Room GenerateRoom()
        {
//Create a new random room
            Random random = new Random();
            int randomWidth = random.Next(MINROOMSIZE, MAXROOMSIZE);
            int randomHeight = random.Next(MINROOMSIZE, MAXROOMSIZE);
            int randomX = random.Next(0, XMAX);
            int randomY = random.Next(0, YMAX);
            Room room = new Room(randomWidth, randomHeight, randomX, randomY);
            return room;
        }

        private static string[][] InitPrintRooms()
        {
            string[][] printRooms = new string[YMAX][];

            for (int i = 0; i < printRooms.Length; i++)
            {
                printRooms[i] = new string[XMAX];
                for (int j = 0; j < printRooms[i].Length; j++)
                {
                    printRooms[i][j] = "*";
                }
            }
            return printRooms;
        }
    }
}
