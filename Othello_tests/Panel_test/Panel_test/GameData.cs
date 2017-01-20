using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panel_test
{
    public enum GameState { INIT, BLACK_TURN, WHITE_TURN, GAME_END }
    public enum BoardState { PLAYABLE_BLACK, PLAYABLE_WHITE, HIDDEN, PLACED_BLACK, PLACED_WHITE };  // the grid is populated with states

    class GameData
    {
        //ATTRIBUTES
        public int total_black
        {
            get;
            set;
        }
        public int total_white
        {
            get;
            set;
        }

        //METHODS
        //constructor
        public GameData()
        {
            total_black = 5;
            total_white = 5;
        }
    }
}
