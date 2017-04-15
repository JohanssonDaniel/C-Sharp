namespace MazeRunner
{
    using Djikstras;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using static Djikstras.Djikstras;

    /// <summary>
    /// Handle logic for the main window
    /// </summary>
    public partial class MainWindow : Window
    {
        // Generate x and y coord 
        private Random rnd          = new Random();
        
        // Update every second
        private TimeSpan MODERATE   = new TimeSpan(0, 0, 1);
        
        // Gives each drawn object a unique index
        private int objectIndex     = 0;                        
        
        // Use to scale the rectangles
        private double objectHeight = 1;                    
        private double objectWidth  = 1;

        private string fileName     = String.Empty;

        private Graph maze          = null;
        private int cost            = 0;
        private Stack<Node> path    = new Stack<Node>();

        /// <summary>
        /// Initialize the components
        /// Create a dispatcher timer
        /// Create an eventhandler
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // The timer inits timerTick() as an eventhandler
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            
            // Sets the tick interval and starts the timer
            timer.Interval = MODERATE;
            timer.Start();

        }
        
        
        /// <summary>
        /// Generate x and y coords
        /// Update the window title with the coords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTick(Object sender, EventArgs e)
        {
            int x      = rnd.Next(0,9);
            int y      = rnd.Next(0,9);
            this.Title = "x:" + x.ToString() + "y:" + y.ToString(); 
        }
        
        /// <summary>
        /// Prompt      the user to choose a file
        /// Retrieve    the filename from the complete file path
        /// Display     the filename
        /// Retrieve    the data from the file
        /// Call        to draw the maze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
            
            // The openDlg.FileName will show the complete file path
            // The string is split and the filename is retrieved from the end of the list
            string[] tempFileName = openDlg.FileName.Split('\\');
            fileName              = tempFileName[tempFileName.Length - 1];

            FileNameText.Clear();
            FileNameText.AppendText(fileName);

            string[] file = System.IO.File.ReadAllLines("../../res/" + fileName);
            DrawMaze(file);
        }
        
        
        /// <summary>
        /// Create the maze (grid)
        /// Set the scaling of maze objects 
        /// Draw the maze
        /// </summary>
        /// <param name="file">Representation of the maze</param>
        private void DrawMaze(string[] file)
        {
            maze = new Graph(file);
            maze.createNodes();
            maze.createEdges();

            objectHeight = MazeCanvas.Height / maze.Grid.Length;
            objectWidth = MazeCanvas.Width / maze.Grid[0].Length;
            
            MazeCanvas.Children.Clear();
            objectIndex = 0;
            
            for (int row = 0; row < maze.Grid.Length; row++)
            {
                for (int col = 0; col < maze.Grid[row].Length; col++)
                {
                    paintMazeObject(row, col, maze.Grid[row][col]);
                }
            }
        }


        /// <summary>
        /// Draws an inputed object in the maze
        /// Every object is represented by a rectangle
        /// The rectangle's color corresponds to which maze object it is
        /// </summary>
        /// <param name="y">Y coord of the object</param>
        /// <param name="x">X coord of the object</param>
        /// <param name="mazeObject">The type of object</param>
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
                    rectangle.Fill = Brushes.Yellow;
                    break;
                case '#':
                    rectangle.Fill = Brushes.Black;
                    break;
                case 'w':
                    rectangle.Fill = Brushes.Green;
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
        
        
        /// <summary>
        /// Call the algorithm to solve for the shortest path and draw the path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            path = new Stack<Node>();
            findShortestPath(ref maze, ref path, out cost);
            
            // Draw the correct path
            CostBox.Clear();
            CostBox.AppendText(cost.ToString());
            foreach (Node node in path)
            {
                paintMazeObject(node.Y, node.X, 'w');
            }
        }
    }
}
