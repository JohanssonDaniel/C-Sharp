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
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace MazeRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Generate x and y coord 
        Random rnd = new Random();
        // Update every second
        TimeSpan MODERATE = new TimeSpan(0,0,1);
        // Gives each drawn object a unique index
        int objectIndex = 0;                        
        // Use to scale the rectangles
        double objectHeight = 1;                    
        double objectWidth = 1;

        string fileName = "";
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            // The timer inits timerTick() as an eventhandler
            timer.Tick += new EventHandler(timerTick);
            // Sets the tick interval and starts the timer
            timer.Interval = MODERATE;
            timer.Start();

            string[] file = System.IO.File.ReadAllLines("../../res/maze2.txt");

            Graph maze = new Graph(file);
            // Set the scaling of the rectangles
            objectHeight = MazeCanvas.Height / maze.Grid.Length;
            objectWidth = MazeCanvas.Width / maze.Grid[0].Length;

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
        // Draws an inputed object in the maze
        // Every object is represented by a rectangle
        // The rectangle's color corresponds to which maze object it is
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
            
            rectangle.Height = objectHeight;
            rectangle.Width = objectWidth;

            Canvas.SetTop(rectangle, y * objectHeight);
            Canvas.SetLeft(rectangle, x * objectWidth);

            MazeCanvas.Children.Insert(objectIndex++, rectangle);
        }
        // Open file and retrieve filename with .Split
        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
            // The openDlg.FileName will show the complete file path
            // The string is split and the filename is retrieved from the end of the list
            string[] tempFileName = openDlg.FileName.Split('\\');
            fileName = tempFileName[tempFileName.Length - 1];

            FileNameText.AppendText(fileName); 
        }
    }
}
