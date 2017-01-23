using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.ComponentModel;
namespace Panel_test
{
    public enum GameState { INIT, BLACK_TURN, WHITE_TURN, GAME_END }
    public enum BoardState { PLAYABLE_BLACK, PLAYABLE_WHITE, HIDDEN, PLACED_BLACK, PLACED_WHITE };  // the grid is populated with states

    class GameData : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        //ATTRIBUTES
        //black
        public int TotalBlack { get; set; }
        public DispatcherTimer blackTimer;
        public string BlackTimerStr { get; private set; }
        private int blackElapsedTime = 0;
        //white
        public int TotalWhite { get; set; }
        public DispatcherTimer whiteTimer;
        public string WhiteTimerStr { get; private set; }
        private int whiteElapsedTime = 0;
        

        //METHODS
        //constructor
        public GameData()
        {
            //side discs
            TotalBlack = 5;
            TotalWhite = 5;
            //timers
            InitializeTimer();
            BlackTimerStr = "00:00:00";
            WhiteTimerStr = "00:00:00";
        }

        //inside method : timers' initialization
        public void InitializeTimer()
        {
            //black
            blackTimer = new DispatcherTimer();
            blackTimer.Interval = TimeSpan.FromSeconds(1);
            blackTimer.Tick += BlackTimerTick;
            //white
            whiteTimer = new DispatcherTimer();
            whiteTimer.Interval = TimeSpan.FromSeconds(1);
            whiteTimer.Tick += WhiteTimerTick;
        }

        public void StartTimer(GameState currentState)
        {
            if (currentState == GameState.BLACK_TURN)
                blackTimer.Start();
            else if (currentState == GameState.WHITE_TURN)
                whiteTimer.Start();
        }

        public void StopTimer(GameState currentState)
        {
            if (currentState == GameState.BLACK_TURN)
                blackTimer.Stop();
            else if (currentState == GameState.WHITE_TURN)
                whiteTimer.Stop();
        }
        

        void BlackTimerTick(object sender, EventArgs e)
        {
            BlackTimerStr = TimeSpan.FromSeconds(++blackElapsedTime).ToString();
            OnPropertyChanged("BlackTimerStr");
        }

        void WhiteTimerTick(object sender, EventArgs e)
        {
            WhiteTimerStr = TimeSpan.FromSeconds(++whiteElapsedTime).ToString();
            OnPropertyChanged("WhiteTimerStr");
        }

        protected void OnPropertyChanged(string name)
        {         
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));           
        }
    }
}
