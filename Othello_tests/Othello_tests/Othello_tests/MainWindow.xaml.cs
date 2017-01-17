using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

/**
    https://programming-pages.com/2012/01/15/wpfs-grid-layout-in-xaml-and-c/
 */

namespace Othello_tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //
        MyData data;

        //CONSTRUCTOR : general initialization
        public MainWindow()
        {
            InitializeComponent();
            //add it here
            InitializeGrid();
            InitializeBoard();
            UpdateBoard();
        }

        //inside method : board initialization
        private void InitializeGrid()
        {
            //retrieve size information
            GridLengthConverter lengthConverter = new GridLengthConverter();
            GridLength gridSize = (GridLength)lengthConverter.ConvertFromString("Auto");

            //grid initialization
            for (int i = 0; i < 8; i++)
            {
                //column
                Board_grid.ColumnDefinitions.Add(new ColumnDefinition());
                Board_grid.ColumnDefinitions[i].Width = gridSize;
                //row
                Board_grid.RowDefinitions.Add(new RowDefinition());
                Board_grid.RowDefinitions[i].Height = gridSize;
            }
        }

        //inside method : test
        private void InitializeBoard()
        {
            data = new MyData();

            for(int row = 0; row < 8; row++)
            {
                for(int column = 0; column < 8; column++)
                {
                    data.StateArray[row, column] = BoardState.NOT_TAKEN;
                }
            }

            data.StateArray[3,3] = BoardState.TAKEN_B;
            data.StateArray[4,4] = BoardState.TAKEN_B;
            data.StateArray[3,4] = BoardState.TAKEN_W;
            data.StateArray[4,3] = BoardState.TAKEN_W;
        }

        //inside method : board update
        private void UpdateBoard()
        {
            
            //data = new MyData();
            ///TODO : ignore this part -> binding will be used
            //squares
            Rectangle[,] square = new Rectangle[8, 8];

            //colorization
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    //
                    square[row, column] = new Rectangle();
                    square[row, column].Height = Board_grid.Height / 8;
                    square[row, column].Width = Board_grid.Width / 8;
                    //
                    Grid.SetColumn(square[row, column], column);
                    Grid.SetRow(square[row, column], row);
                    // 
                    if (data.StateArray[row, column] == BoardState.TAKEN_B)
                        square[row, column].Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    if (data.StateArray[row, column] == BoardState.TAKEN_W)
                        square[row, column].Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    else if (data.StateArray[row, column] == BoardState.NOT_TAKEN)
                        square[row, column].Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                    //
                    Board_grid.Children.Add(square[row, column]);
                }
            }
        }
    }
}
