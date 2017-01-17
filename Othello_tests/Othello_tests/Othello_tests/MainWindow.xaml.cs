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

        //ATTRIBUTES
        MyData data;
        DiscView[,] discs;

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
            //retrieve size information from *.xaml
            GridLengthConverter lengthConverter = new GridLengthConverter();
            GridLength gridSize = (GridLength)lengthConverter.ConvertFromString("Auto");

            //grid initialization
            for (int i = 0; i < 8; i++)
            {
                Board_grid.ColumnDefinitions.Add(new ColumnDefinition());
                Board_grid.RowDefinitions.Add(new RowDefinition());
            }
        }

        //inside method : initialized board
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
            //create discs' array
            discs = new DiscView[8, 8];
            
            //populate array + UI
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    //
                    discs[row, column] = new DiscView();
                    //
                    Grid.SetColumn(discs[row, column], column);
                    Grid.SetRow(discs[row, column], row);

                    //BLACK
                    if (data.StateArray[row, column] == BoardState.TAKEN_B)
                    {
                        discs[row, column].SetState(BoardState.TAKEN_B);
                    }
                    //WHITE
                    if (data.StateArray[row, column] == BoardState.TAKEN_W)
                    {
                        discs[row, column].SetState(BoardState.TAKEN_W);
                    }
                    //EMPTY
                    else if (data.StateArray[row, column] == BoardState.NOT_TAKEN)
                    {
                        discs[row, column].SetState(BoardState.NOT_TAKEN);
                    }
                    
                    //populate Board (visual)
                    Board_grid.Children.Add(discs[row, column]);
                }
            }
        }
    }
}
