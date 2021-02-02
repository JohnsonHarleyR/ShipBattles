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
        private List<string> compHits = new List<string>(); // list of places the AI has hit
        
        private bool hitShip = false; // turns true once there's a hit, stays true until the ship sinks
        private bool strikeLastTurn = true; // default is true until there's a miss
        private Stack<string> directions = new Stack<string>();
        private string currentDirection;



        public AI(Board compShipBoard, Board compGuessBoard)
        // these should all reference the same object, even in main program (right?))
        {
            this.compShipBoard = compShipBoard;
            this.compGuessBoard = compGuessBoard;

            // add directions to direction stack, then shuffle
            directions.Push("left");
            directions.Push("right");
            directions.Push("up");
            directions.Push("down");

            // now shuffle the directions stack
            Shuffle(directions);

            // now set currentDirection to top of stack


        }

        // test method - make them guess a specific guess to test the AIGuess method
        // WARNING: this doesn't have validation since it's only a test method - be sure to type
        // position with capital letters
        // NOTE: I'm only taking input from the console here because it's a test method
        public void MakeCertainGuess(Board guessBoard, Board shipBoard) // should take in the AI's guess board & player's board
        {
            //variables
            string guess;

            // get the position to guess specifically for testing - must be input correctly
            Console.Write("\nTest which AI guess?: ");
            guess = Console.ReadLine();

            // turn that spot on the boards to x
            guessBoard.MarkSpaceAsHit(guess);
            shipBoard.MarkSpaceAsHit(guess);
            // add spot to compHits, as if it had just randomly guessed this position
            compHits.Add(guess);
            // set hitShip as true, as if the AI had randomly guessed it
            hitShip = true;
            // strikeLastTurn should already be true

        }


        // Allow the AI to make a guess
        public int[] AIGuess(Board guessBoard) // takes in AI guess board, returns coordinates of their guess
        {
            // variables
            Random random = new Random();
            string[,] boardVals = guessBoard.GetBoardVals(); // make it simpler
            int posX;
            int posY;
            bool validGuess;

            // if a ship hasn't been hit, guess a random position
            if (!hitShip)
            {
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
                        // first, turn hitShip to true
                        hitShip = true; // it should not sink after one random guess, so don't worry about checks for that
                        // add the position to computer hits
                        compHits.Add(guessBoard.ChangeSpaceToString(new int[] {posX, posY }));
                        return new int[] { posX, posY };
                    }

                } while (!validGuess);

                // if for some reason it reaches this code after the top, return something random and log an error
                Console.WriteLine("Error: AI could not make random guess correctly");
                return new int[] { 0, 0 }; // placeholder basically
            }

            // otherwise, start guessing around that hit until a ship gets sunk
            else // 'hitShip' must otherwise be true
            {

                //TODO Make sure the game accounts for if the AI guessing a space that
                // happens to be on a DIFFERENT ship

                // check if the ship in the lastHit position has sunk or not

                // if the ship has not sunk, keep gussing positions around it

                // if strikeLastTurn is false, find a new currentDirection

                // otherwise, keep guessing in that direction

                // attempt to hit a ship in the current direction

                // if there's a hit, strikeLastTurn is now true and add last hit to compHits

                // otherwise, strikeLastTurn becomes false so a new direction can be taken

                // if strikeLastTurn is now false, check if there is more than one item in compHits

                // if there's more than one, that means we are in line with the ship, but
                // the hits ran out in that direction - so simply reverse direction
                // if the currentDirection is left, go right. If it's up, go down. Etc.


                // check if the ship has now sunk after hitting a spot

                // if it has sunk, reset the stack and randomize the directions again

                // after randomized, set currentDirection to top of stack again for next time

                // reset strikeLastTurn to false - allows if-then to work correctly

                // clear compHits for the next ship that gets hit


                return new int[] { 0, 0 }; // placeholder basically
            }


                



            // TODO Important: Once the main game is set up, use some logic
            // TODO If the AI gets a hit, it will start guessing positions around it too

        }

        // shuffle a stack
        public void Shuffle(Stack<string> stack)
        {
            // variables
            Random random = new Random();
            List<string> list = new List<string>(); // this will be changed to a new stack
            List<int> nums = new List<int>(); // use random to pull position from list
            int max = stack.Count; // decreases with each random number

            // add values to nums depending on size of stack stack
            for (int i = 0; i < stack.Count; i++)
            {
                nums.Add(i);
            }

            var values = stack.ToArray();
            stack.Clear();

            // test
            //Console.Write(nums.Count);

            // testing the shuffle method
            //Console.Write("\nTesting shuffle: ");

            while (nums.Count > 0)
            {
                // get random value from list
                int num = nums[random.Next(0, nums.Count)]; // the next value to add
                nums.Remove(num); // remove that value from list
                string value = values[num];
                // add random value to the stack
                stack.Push(value);

                //Console.Write($"{value}, "); //testing
            }


        }

    }
}
