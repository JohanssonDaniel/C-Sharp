using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstras
{
    class Program
    {
        const int NUMOFMAZES = 3;
        const int NUMOFOPTIONS = 7;

        static void Main(string[] args)
        {

            string option = "";
            string mazeOption = "";
            string filePath = "";
            Stack<Node> path = new Stack<Node>();
            int cost = 0;
            Graph graph = null;

            while (!option.Equals("7"))
            {
                showWelcomeMessage(filePath);

                option = readOption();

                switch (option.ToLower())
                {
                    case "1":
                        mazeOption = readMazeOption();
                        filePath = "../../res/maze" + mazeOption + ".txt";
                        Console.WriteLine("The filepath is {0}", filePath);
                        break;
                    case "2":
                        makeGraphFromFile(filePath, out graph);
                        break;
                    case "3":
                        graph.createNodes();
                        break;
                    case "4":
                        graph.createEdges();
                        break;
                    case "5":
                        Djikstras.findShortestPath(ref graph, ref path, out cost);
                        Console.WriteLine("Total cost: {0}", cost);
                        returnToMenu();
                        break;
                    case "6":
                        if (graph != null)
                        {
                            Console.WriteLine("\nCurrent maze ");
                            graph.printGraph();
                        }
                        else
                            Console.WriteLine("Load a maze, then create the grid and the nodes first...");
                        returnToMenu();
                        break;
                    case "7":
                        Console.WriteLine("\nI guess you will forever be trapped in the maze...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong input...");
                        break;
                }
            }
        }

        private static void returnToMenu()
        {
            Console.Write("\nPress enter to return to main menu: ");
            Console.ReadKey();
        }

        private static void makeGraphFromFile(string filePath, out Graph graph)
        {
            string[] file = System.IO.File.ReadAllLines(filePath);
            graph = new Graph(file);
        }

        private static void showWelcomeMessage(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Welcome to my Mazesolver");
            Console.WriteLine("The current filepath of the maze: {0}", filePath);
            Console.WriteLine(" 1) Load maze file");
            Console.WriteLine(" 2) Create the graph");
            Console.WriteLine(" 3) Create nodes");
            Console.WriteLine(" 4) Create edges");
            Console.WriteLine(" 5) Solve the maze");
            Console.WriteLine(" 6) Print the maze");
            Console.WriteLine(" 7) Exit the program");
            Console.Write("Choose options: ");
        }

        private static string readOption()
        {
            string tempOption = Console.ReadLine();
            int tempOptionInt = Int32.Parse(tempOption);
            while (tempOptionInt <= 0 || tempOptionInt > NUMOFOPTIONS)
            {
                Console.Write("Please insert a number between 1 and {0}: ", NUMOFOPTIONS);
                tempOption = Console.ReadLine();
                tempOptionInt = Int32.Parse(tempOption);
            }
            return tempOption;
        }

        private static string readMazeOption()
        {
            Console.Write("Choose which maze you want to load(1,2,3): ");

            string temp = Console.ReadLine();
            int tempInt = Int32.Parse(temp);
            while (tempInt <= 0 || tempInt > NUMOFMAZES)
            {
                Console.Write("Please insert a number between 1 and {0}: ", NUMOFMAZES);
                temp = Console.ReadLine();
                tempInt = Int32.Parse(temp);
            }
            return temp;
        }

        
    }
}
