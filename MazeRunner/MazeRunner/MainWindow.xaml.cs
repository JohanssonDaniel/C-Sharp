using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Djikstras;
using System.Windows.Threading;

namespace MazeRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();                  // Generate x and y coord 
        TimeSpan MODERATE = new TimeSpan(0,0,1);    // Update every second
        int objectIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            // The timer inits timerTick() as an eventhandler
            //timer.Tick += new EventHandler(timerTick);
            // Sets the tick interval and starts the timer
            timer.Interval = MODERATE;
            timer.Start();

            string[] file = System.IO.File.ReadAllLines("../../res/maze3.txt");

            Graph maze = new Graph(file);

            for (int row = 0; row < maze.Grid.Length; row++)
            {
                for (int col = 0; col < maze.Grid[row].Length; col++)
                {
                    paintMazeObject(row, col, maze.Grid[row][col]);
                }
            }
        }
        // Generate random x and y coord and display them at the window title
        private void timerTick(Object sender, EventArgs e)
        {
            int x = rnd.Next(0,9);
            int y = rnd.Next(0,9);
            this.Title = "x:" + x.ToString() + "y:" + y.ToString(); 
        }
        private void paintMazeObject(int y, int x, char mazeObject)
        {
            Rectangle rectangle = new Rectangle();
            switch (mazeObject)
            {
                case 'S':
                    rectangle.Fill = Brushes.Blue;
                    break;
                case 'm':
                    rectangle.Fill = Brushes.Red;
                    break;
                case ' ':
                    rectangle.Fill = Brushes.White;
                    break;
                case 'G':
                    rectangle.Fill = Brushes.Green;
                    break;
                case '#':
                    rectangle.Fill = Brushes.Black;
                    break;   
                default:
                    break;
            }
            
            rectangle.Height = 10;
            rectangle.Width = 10;

            Canvas.SetTop(rectangle, y * 10);
            Canvas.SetLeft(rectangle, x * 10);

            MazeCanvas.Children.Insert(objectIndex++, rectangle);
        }
    }
}
