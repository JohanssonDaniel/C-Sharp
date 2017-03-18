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
            foreach (string line in file)
            {
                FileText.AppendText(line);
                FileText.AppendText("\n");
            }
        }
        // Generate random x and y coord and display them at the window title
        private void timerTick(Object sender, EventArgs e)
        {
            int x = rnd.Next(0,9);
            int y = rnd.Next(0,9);
            this.Title = "x:" + x.ToString() + "y:" + y.ToString(); 
        }
        private void paintMazeObject()
        {
            Rectangle rectangle = new Rectangle();

            rectangle.Fill = Brushes.Black;
            rectangle.Height = 10;
            rectangle.Width = 10;

            Canvas.SetTop(rectangle, 10);
            Canvas.SetLeft(rectangle, 10);

            MazeCanvas.Children.Insert(0, rectangle);
        }
    }
}
