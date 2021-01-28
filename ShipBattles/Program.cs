using System;

namespace ShipBattles
{
    class Program
    {

        static void Main(string[] args)
        {
            // Variables
            Board playerShipBoard; // the board the player will place ships on
            Board playerGuessBoard; // the board where the player places their guesses
            Board compShipBoard; // the board the computer will place ships on
            Board compGuessBoard; // the board where the computer will guess

            string introMsg =
" _     _  _______  ___      _______  _______  __   __  _______    _______  _______                \n" +
"| | _ | ||       ||   |    |       ||       ||  |_|  ||       |  |       ||       |               \n" +
"| || || ||    ___||   |    |       ||   _   ||       ||    ___|  |_     _||   _   |               \n" +
"|       ||   |___ |   |    |       ||  | |  ||       ||   |___     |   |  |  | |  |               \n" +
"|       ||    ___||   |___ |      _||  |_|  ||       ||    ___|    |   |  |  |_|  |               \n" +
"|   _   ||   |___ |       ||     |_ |       || ||_|| ||   |___     |   |  |       |               \n" +
"|__| |__||_______||_______||_______||_______||_|   |_||_______|    |___|  |_______|               \n" +
" _______  __   __  ___   _______    _______  _______  _______  _______  ___      _______  _______ \n" +
"|       ||  | |  ||   | |       |  |  _    ||   _   ||       ||       ||   |    |       ||       |\n" +
"|  _____||  |_|  ||   | |    _  |  | |_|   ||  |_|  ||_     _||_     _||   |    |    ___||  _____|\n" +
"| |_____ |       ||   | |   |_| |  |       ||       |  |   |    |   |  |   |    |   |___ | |_____ \n" +
"|_____  ||       ||   | |    ___|  |  _   | |       |  |   |    |   |  |   |___ |    ___||_____  |\n" +
" _____| ||   _   ||   | |   |      | |_|   ||   _   |  |   |    |   |  |       ||   |___  _____| |\n" +
"|_______||__| |__||___| |___|      |_______||__| |__|  |___|    |___|  |_______||_______||_______|\n" +
                "\n(Psst, it's just like Battleship.)\n";
            bool cont = true; // determine whether to play another game or exit


            // loop as long as they want to play a game
            do
            {
                // introduction
                Console.WriteLine(introMsg);

                // TODO Add a menu to explain rules or play the game - do this after game is complete


                // START THE GAME

                // Generate new boards
                playerGuessBoard = new Board(); // the board where the player places their guesses
                playerShipBoard = new Board(); // the board the player will place ships on

                compGuessBoard = new Board(); // the board where the computer will guess
                compShipBoard = new Board(); // the board the computer will place ships on
                


                // Generate the positions for the AI's board
                compShipBoard.GenerateAIPositions();

                // Ask the player where they want to place their ships
                Console.WriteLine("\nYou will be playing against an AI who has already set up her ships.");
                Console.WriteLine("Let's get your ships set up!");
                AskAllShips(playerShipBoard);




            } while (cont); // loop as long as they want to play a game



            // testing area

            // test the board display
            //DisplayBoard(playerShipBoard);
            //DisplayBoth(playerGuessBoard, playerShipBoard);

            /*
            // test the generator for the computer positions
            compShipBoard.GenerateAIPositions();
            Console.WriteLine("\nTesting the board generator for the computer.");
            DisplayBoard(compShipBoard);
            */

            /*
            // test getting input from user for a position
            string pos = AskPosition("Input position: "); // automatically validates

            // test matching the space of that position on a board
            int[] testPos = playerShipBoard.MatchSpace(pos);
            Console.WriteLine($"Test positions: {testPos[0]}, {testPos[1]}\n");

            // test assigning that value as ship, then display board
            playerShipBoard.MarkSpaceAsShip(testPos);
            DisplayBoard(playerShipBoard);
            */

            /*
             * // test adding a ship to the player board
            Console.WriteLine("\nTest adding a the 'Carrier' ship with 5 spaces.");
            string pos1Temp = AskPosition("Position 1: ");
            string pos2Temp = AskPosition("Position 2: ");
            bool tempValid = playerShipBoard.ValidateShipSpace("Carrier", pos1Temp, pos2Temp);
            Console.WriteLine($"Valid spaces for ship? " +
                $"{tempValid}");
            // if it's valid, add to board and display
            if (tempValid)
            {
                playerShipBoard.AddShipSpace(pos1Temp, pos2Temp);
                DisplayBoard(playerShipBoard);
            }
            */

            /*
            // test adding a ship with the AskForShip function, then display
            //Console.WriteLine("\nTest adding the 'Battleship' ship with 4 spaces.\n");
            Console.WriteLine();
            DisplayBoard(playerShipBoard);
            AskForShip("Battleship", 4, playerShipBoard);
            DisplayBoard(playerShipBoard);
            */

            /*
            // test adding all ships at once with method AskAllShips
            //DisplayBoard(playerShipBoard);
            AskAllShips(playerShipBoard);
            DisplayBoard(playerShipBoard);
            */




            Console.WriteLine("Hello World!");
        }

        // Ask for all ships to place on a board - only do if board is empty
        public static void AskAllShips(Board board)
        {
            string[] NAMES = board.GetShipNames();
            int[] SIZES = board.GetShipSizes();

            // iterate through the ships to ask for them
            for (int i = 0; i < NAMES.Length; i++)
            {
                //Display board first so they can know where to place it
                Console.WriteLine(); // add a line for spacing
                DisplayBoard(board);
                AskForShip(NAMES[i], SIZES[i], board);
            }
        }

        // Ask for a single ship and place on board
        public static void AskForShip(string shipName, int shipSize, Board board)
        {
            bool valid = false;
            string pos1Temp;
            string pos2Temp;

            Console.WriteLine($"\nNow adding '{shipName}' to your board. There are {shipSize} spaces.");
            do // keep asking until they give valid positions for the ship.
            {
                Console.WriteLine($"Please give the coordinates for the first and last spaces of '{shipName}'.\n");
                pos1Temp = AskPosition("Position 1: ");
                pos2Temp = AskPosition("Position 2: ");
                valid = board.ValidateShipSpace(shipName, pos1Temp, pos2Temp);

                // if it's not valid, tell them it's an invalid place to put the ship
                if (!valid)
                {
                    Console.WriteLine($"Could not place this ship in that position.\n");
                }
            } while (!valid);
            
            
            // if it's valid, add to board
            if (valid)
            {
                board.AddShipSpace(pos1Temp, pos2Temp);
            }
        }


        // enter a letter, validate it and return that string with correct input
        public static string AskPosition(string message)
        {
            // test the position validator - reuse this to get input
            bool validEntry;
            string input;
            do
            {
                // get input for position
                Console.Write(message);
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
            string[] letters = new string[] { "A", "B", "C", "D", // letters on the board
                "E", "F", "G", "H", "I", "J" };
            string numbers = "   1  2  3  4  5  6  7  8  9  10\n";
            string[,] boardVals = board.GetBoardVals();

            // first print a line of "-"
            //Console.WriteLine(line);

            // interate through the full board
            for (int i = 0; i < boardVals.GetLength(0); i++)
            {
                if (i == 0)
                {
                    // write the initial |
                    Console.Write(numbers);
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
                            Console.Write(letters[i] + " ");
                            //Console.Write("\n|");
                        } else
                        {
                            // write the initial |
                            Console.Write(letters[i] + " ");
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
