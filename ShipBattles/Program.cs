using System;

namespace ShipBattles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            Board playerShipBoard = new Board(); // the board the player will place ships on
            Board playerGuessBoard = new Board(); // the board where the player places their guesses
            Board compShipBoard = new Board(); // the board the computer will place ships on
            Board compGuessBoard = new Board(); // the board where the computer will guess

            // test the board display
            //DisplayBoard(playerShipBoard);
            DisplayBoth(playerGuessBoard, playerShipBoard);

            Console.WriteLine("Hello World!");
        }




        // Display a board
        public static void DisplayBoard(Board board)
        {
            // variables
            string[,] boardVals = board.GetBoardVals();
            string letters = "    A  B  C  D  E  F  G  H  I  J\n";

            // first print a line of "-"
            //Console.WriteLine(line);

            // interate through the full board
            for (int i = 0; i < boardVals.GetLength(0); i++)
            {
                if (i == 0)
                {
                    // write the initial |
                    Console.Write(letters);
                    //Console.Write("\n|");
                }

                for (int n = 0; n < boardVals.GetLength(1); n++)
                {

                    // if it's the first value in the line, do this
                    if (n == 0)
                    {
                        if (i != 9)
                        {
                            // write the initial |
                            Console.Write(" " + (i + 1) + " ");
                            //Console.Write("\n|");
                        } else
                        {
                            // write the initial |
                            Console.Write((i + 1) + " ");
                            //Console.Write("\n|");
                        }

                    }

                    // otherwise write the value and then |
                    Console.Write("[" + boardVals[i, n] + "]");

                    // if it's the last value in the line, do this
                    
                }

                // write another line of "-" after a the line of values is finished
                Console.Write("\n");
            }

            // test
            // ---------------------
            // | | | | | | | | | | |
        }

        // Display both boards on your own side
        public static void DisplayBoth(Board guessBoard, Board shipBoard)
        {
            string line = "---------------------------------";

            DisplayBoard(guessBoard);
            Console.WriteLine(line);
            DisplayBoard(shipBoard);

        }

    }
}
