using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedurallyGeneration
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        private const int MAXROOMSIZE  = 8;
        private const int MINROOMSIZE  = 3;

        private const int XMAX = 20;
        private const int YMAX = 20;

        private static readonly List<Room> Rooms = new List<Room>();
        private static string[][] _printRooms;

        static void Main(string[] args)
        {
            InitPrintRooms();

            Console.Write("G)enerate new room: ");
            while (Console.ReadLine().ToLower() == "g" )
            {
                Room newRoom = GenerateNewRoom();
                
                if (!CollideWithRooms(newRoom, Rooms))
                {
                    if (Rooms.Any())
                    {
                        Point center = newRoom.Center;
                        Point prevCenter = Rooms.Last().Center;

                        GenerateVerticalCorridor(prevCenter.Y, center.Y, center.X);
                        GenerateHorizontalCorridor(prevCenter.X, center.Y, center.X);
                    }
                    Rooms.Add(newRoom);
                }

                AddToPrintRooms();

                PrintRooms(_printRooms);
                Console.Write("G)enerate new room: ");
            }
        }

        private static void GenerateHorizontalCorridor(int x2, int x1, int y)
        {
            for (int i = x1; i < x2; i++)
            {
                _printRooms[y][i] = " ";
            }
        }

        private static void GenerateVerticalCorridor(int y2, int y1, int x)
        {
            for (int i = y1; i < y2; i++)
            {
                _printRooms[i][x] = " ";
            }
        }

        private static bool CollideWithRooms(Room newRoom, List<Room> rooms)
        {
            return rooms.Select(newRoom.Overlap).FirstOrDefault();
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

        private static void AddToPrintRooms()
        {
            foreach (Room room in Rooms)
            {
                for (int y = room.Y1; y < room.Y2; y++)
                {
                    for (int x = room.X1; x < room.X2; x++)
                    {
                        if (x < XMAX && y < YMAX)
                        {
                            _printRooms[y][x] = " ";
                        }
                    }
                }
            } 
        }

        private static Room GenerateNewRoom()
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

        private static void InitPrintRooms()
        {
            _printRooms = new string[YMAX][];

            for (int i = 0; i < _printRooms.Length; i++)
            {
                _printRooms[i] = new string[XMAX];
                for (int j = 0; j < _printRooms[i].Length; j++)
                {
                    _printRooms[i][j] = "*";
                }
            }
        }
    }
}
