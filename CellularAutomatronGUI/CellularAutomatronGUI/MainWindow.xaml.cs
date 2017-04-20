using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Int32;

namespace CellularAutomatronGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {                                            
            int numOfCols  = Parse(TapeBox.Text);
            int numOfRows  = Parse(RowsBox.Text);
            int ruleNumber = Parse(RuleBox.Text);

            CellAuto cs = new CellAuto(numOfRows, numOfCols, ruleNumber);

            string[][] grid = cs.Grid;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == "*")
                    {
                        DrawCell(row, col, numOfRows, numOfCols);
                    }
                }
            }
        }

        private void DrawCell(int y, int x, int numOfRows, int numOfCols)
        {
            double cellHeight = CellCanvas.Height / numOfRows;
            double cellWidth  = CellCanvas.Width  / numOfCols;

            Rectangle rectangle = new Rectangle
            {
                Width = cellWidth,
                Height = cellHeight,
                Fill = Brushes.Black
            };

            Canvas.SetTop(rectangle, y * cellHeight);
            Canvas.SetLeft(rectangle, x * cellWidth);

            CellCanvas.Children.Add(rectangle);
        }
    }
}
