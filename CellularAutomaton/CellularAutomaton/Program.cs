using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomaton
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCols  = Int32.Parse(args[0]);
            int numOfRows  = Int32.Parse(args[1]);
            int ruleNumber = Int32.Parse(args[2]);

            CellAuto ca = new CellAuto(numOfRows, numOfCols, ruleNumber);
            
            //PrintRules();
            ca.PrintGrid();

            Console.ReadLine();
        }
    }
}
