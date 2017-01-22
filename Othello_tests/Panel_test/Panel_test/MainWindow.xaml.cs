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
            black_label.DataContext = data;
            white_label.DataContext = data;
            Console.WriteLine("INFORMATION : panel initialization");
        }

        //inside method : panel initialization
        //TODO : rewrite 
        public void InitializePanel()
        {
            data = new GameData();
            int j = data.TotalBlack;

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
            
            else if (data.TotalWhite != 0 && currentGameState == GameState.BLACK_TURN)
            {
                data.TotalBlack--;
                Remaining_wdiscs.Children.RemoveAt(data.TotalBlack);
                Console.WriteLine("next : white turn");
                Console.WriteLine("total black : {0}", data.TotalBlack);

                currentGameState = GameState.WHITE_TURN;
            }

            else if (data.TotalWhite != 0 && currentGameState == GameState.WHITE_TURN)
            {
                data.TotalWhite--;
                Remaining_bdiscs.Children.RemoveAt(data.TotalWhite);
                Console.WriteLine("next : black turn");
                Console.WriteLine("total white : {0}", data.TotalWhite);

                currentGameState = GameState.BLACK_TURN;
            }
            else if (data.TotalWhite == 0 && data.TotalBlack == 0)
                currentGameState = GameState.GAME_END;
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentGameState != GameState.GAME_END)
            {
                if (currentGameState == GameState.WHITE_TURN)
                {
                    data.StopTimer(GameState.BLACK_TURN);
                    data.StartTimer(GameState.WHITE_TURN);
                }
                    
                else if (currentGameState == GameState.BLACK_TURN)
                {
                    data.StopTimer(GameState.WHITE_TURN);
                    data.StartTimer(GameState.BLACK_TURN);
                }
                    
                UpdatePanel();
            }
            else
            {
                data.StopTimer(GameState.BLACK_TURN);
                data.StopTimer(GameState.WHITE_TURN);
            }
        }
    }
}
