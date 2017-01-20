using System;

namespace Othello_tests
{
    public enum BoardState { TAKEN_B, TAKEN_W, NOT_TAKEN };

    /// <summary>
    /// This class contains program's data
    /// </summary>
    public class MyData
    {

        //ATTRIBUTES
        public BoardState[,] StateArray
        {
            get;
            set;
        }

        //CONSTRUCTOR : initialization
        public MyData()
        {
            StateArray = new BoardState[8, 8];
            FillArray();
        }

        //inside method : fill array
        private void FillArray()
        {
            Random random = new Random();
            
            // random filling
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    // <=a < b
                    int state = random.Next(1, 4);

                    if (state == 1)
                        StateArray[row, column] = BoardState.TAKEN_B;
                    if (state == 2)
                        StateArray[row, column] = BoardState.TAKEN_W;
                    if (state == 3)
                        StateArray[row, column] = BoardState.NOT_TAKEN;
                }
            }
        }
    }
}
