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

            // test the generator for the computer positions
            compShipBoard.GeneratePositions();
            Console.WriteLine("\nTesting the board generator for the computer.");
            DisplayBoard(compShipBoard);

            // test getting input from user for a position
            string pos = AskPosition();

            // test matching the space of that position on a board
            int[] testPos = playerShipBoard.MatchSpace(pos);
            Console.WriteLine($"Test positions: {testPos[0]}, {testPos[1]}");


            Console.WriteLine("Hello World!");
        }



        // enter a letter, validate it and return that string with correct input
        public static string AskPosition()
        {
            // test the position validator - reuse this to get input
            bool validEntry;
            string input;
            do
            {
                // get input for position
                Console.Write("\nInput position: ");
                input = Console.ReadLine();
                validEntry = ValidatePosition(input);
                // tell them it's invalid if it's not valid
                if (!validEntry)
                {
                    Console.Write("Invalid Entry.");
                }
            } while (!validEntry);

            // format the input just in case
            input = input.ToUpper();
            input.Trim();

            return input;
        }

        // Validate the input from the user for a position - returns true if valid
        public static bool ValidatePosition(string position)
        {
            // variables
            string[] letters = new string[] { "A", "B", "C", "D", // letters on the board
                "E", "F", "G", "H", "I", "J" };

            bool valid = false;
            string pos1;
            int pos2 = 0;

            // first capitalize their input and trim it
            position = position.ToUpper();
            position.Trim();
            //Console.WriteLine($"Pos: {position}");

            // now check that the letter is from A - Z and in the first position
            pos1 = position.Substring(0, 1);
            foreach (string letter in letters)
            {
                // if it matches a letter in the array, then it's valid so far
                if (pos1.Equals(letter))
                {
                    valid = true;
                    //Console.WriteLine($"Valid letter.");
                    break;
                }

            }

            // now try to parse the number in the second position
            try
            {
                // see if the string is 3 letter long because if so, it might be a 10
                if (position.Length == 3)
                {
                    pos2 = Int32.Parse(position.Substring(1, 2));
                }
                else
                {
                    pos2 = Int32.Parse(position.Substring(1, 1));
                }

            }
            catch (Exception)
            {
                valid = false; // if it can't be parsed, then the input is not valid
            }

            // now make sure that the second number is in range from 1-10
            if (valid) // only do it if it's still valid
            {
                if (pos2 < 1 || pos2 > 10)
                {
                    valid = false;
                }
            }

            // return result
            return valid;
        }


        // Display a board
        public static void DisplayBoard(Board board)
        {
            // variables
            string letters = "    A  B  C  D  E  F  G  H  I  J\n";
            string[,] boardVals = board.GetBoardVals();

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
