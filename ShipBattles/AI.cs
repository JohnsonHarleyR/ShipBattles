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
            // variables
            Random random = new Random();
            string[,] boardVals = guessBoard.GetBoardVals(); // make it simpler
            int posX;
            int posY;
            bool validGuess = true;

            // start off just having the AI guess a random position

            // start with a loop that guesses until it hits one it hasn't guessed yet
            do
            {
                // generate position
                posX = random.Next(0, 10); // possibly change this to a board size constant in future
                posY = random.Next(0, 10);

                // check if that position is blank - if it's not, set validGuess to false
                if (!boardVals[posX, posY].Equals(" "))
                {
                    validGuess = false; // if it's not blank, it already hit it

                } // otherwise, return the position as its guess
                else
                {
                    return new int[] {posX, posY };
                }

            } while (!validGuess);

            // if for some reason it reaches this code after the top, return something random and log an error
            Console.WriteLine("Error: AI could not make random guess correctly");
            return new int[] { 0, 0 }; // placeholder basically



            // TODO Important: Once the main game is set up, use some logic
            // TODO If the AI gets a hit, it will start guessing positions around it too

        }
    }
}
