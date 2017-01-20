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

namespace Panel_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //ATTRIBUTES
        GameData data;
        GameState currentGameState;

        //METHODS
        //constructor
        public MainWindow()
        {
            InitializeComponent();
            currentGameState = GameState.INIT;
            InitializePanel();
            Console.WriteLine("INFORMATION : panel initialization");
        }

        //inside method : panel initialization
        //TODO : rewrite 
        public void InitializePanel()
        {
            data = new GameData();
            int j = data.total_black;

            for (int i = 0; i < j; i++)
            {
                SideDisc disc = new SideDisc();
                disc.SetState(GameState.BLACK_TURN);
                Remaining_bdiscs.Children.Add(disc);
            }

            for (int i = 0; i < j; i++)
            {
                SideDisc disc = new SideDisc();
                disc.SetState(GameState.WHITE_TURN);
                Remaining_wdiscs.Children.Add(disc);
            }
        }

        //inside method : update panel
        public void UpdatePanel()
        {
            Console.WriteLine("Current GameState : {0}", currentGameState.ToString());
            if (currentGameState == GameState.INIT)
                currentGameState = GameState.BLACK_TURN;
            
            else if (data.total_white != 0 && currentGameState == GameState.BLACK_TURN)
            {
                data.total_black--;
                Remaining_wdiscs.Children.RemoveAt(data.total_black);
                Console.WriteLine("next : white turn");
                Console.WriteLine("total black : {0}", data.total_black);

                currentGameState = GameState.WHITE_TURN;
            }

            else if (data.total_white != 0 && currentGameState == GameState.WHITE_TURN)
            {
                data.total_white--;
                Remaining_bdiscs.Children.RemoveAt(data.total_white);
                Console.WriteLine("next : black turn");
                Console.WriteLine("total white : {0}", data.total_white);

                currentGameState = GameState.BLACK_TURN;
            }
            else if (data.total_white == 0 && data.total_black == 0)
                currentGameState = GameState.GAME_END;
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            if (currentGameState != GameState.GAME_END)
                UpdatePanel();
            else
                Console.WriteLine("No more update allowed");
        }
    }
}
