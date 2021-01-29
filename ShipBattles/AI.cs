using System;
using System.Collections.Generic;
using System.Text;

namespace ShipBattles
{
    // This is basically a computer player -  a separate class allows it to guess with some logic
    // TODO move 'GenerateAIPositions' from Board class to this class
    class AI
    {
        // the AI's boards
        Board compGuessBoard; // the board where the computer will guess
        Board compShipBoard; // the board the computer will place ships on
        


        // logic variables to help AI make decisions after they get a hit
        private List<int[]> compHits = new List<int[]>(); // list of places the AI has hit
        int turn = 0; // the current turn
        int lastHitTurn; // the last turn where the AI made a hit - helps decide where to guess next


        public AI(Board compShipBoard, Board compGuessBoard)
        // these should all reference the same object, even in main program (right?))
        {
            this.compShipBoard = compShipBoard;
            this.compGuessBoard = compGuessBoard;

        }


        // Allow the AI to make a guess
        public int[] AIGuess(Board guessBoard) // takes in AI guess board, returns coordinates of their guess
        {
            // start off just having the AI guess a random position

            // TODO Important: Once the main gain is set up, use some logic
            // If the AI gets a hit, it will start guessing positions around it

        }
    }
}
