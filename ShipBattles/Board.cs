using System;
using System.Collections.Generic;
using System.Text;

namespace ShipBattles
{
    class Board
    {
        private readonly int[] SHIP_SIZES = new int[]{5, 4, 3, 3, 2}; // how big each ship is
        private readonly string[] SHIP_NAMES = new string[]{"Carrier", // the names of each ship, matches respectively to sizes
        "Battleship", "Cruiser", "Submarine", "Destroyer"};
        private string[,] boardVals = new string[10, 10];


        public Board()
        {
            // put an empty space in each spot on the board as it's created
            for (int i = 0; i < boardVals.GetLength(0); i++)
            {
                for (int n = 0; n < boardVals.GetLength(1); n++)
                {
                    // assign " "
                    boardVals[i, n] = " ";
                }
            }



        }

        // Get the array from the board
        public string[,] GetBoardVals()
        {
            return boardVals;
        }

    }
}
