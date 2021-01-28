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
        private readonly string[] letters = new string[] { "A", "B", "C", "D", // letters on the board
                "E", "F", "G", "H", "I", "J" };
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


        // Add a ship to the board
        public bool AddShip()
        {
            // this returns a boolean that tells if adding it was successful or not
            // NOTE testing for correct letter input must be done in the main program

            // variables
            bool successful = true; // sets to false if a space is already taken


            return successful; // return whether it was successful

        }

        // returns the number positions on a board based on a user's input
        // NOTE the input must be in this format "A1"
        public int[] MatchSpace(string space)
        {
            // variables
            int[] spots = new int[2];

            try
            {

            } catch (Exception)
            {
                Console.WriteLine("Error: could not match position on board.\nReturning empty array.");
            }

            return spots; // return result

        }




        // Generate random positions of ships for an AI board
        public void GeneratePositions()
        {
            // loop through the different ships (by size) to decide positions
            for (int ship = 0; ship < SHIP_SIZES.Length; ship++)
            {
                // do this one step at a time to avoid confusion

                // variables
                int shipSize = SHIP_SIZES[ship];
                int posX;
                int posY;
                int direction; // 1 is left, 2 is right, 3 is up, 4 is down
                bool valid; // determines if these are valid positions for that ship
                bool validDir; // determine if the direction chosen is valid for that ship
                int[] positionsX = new int[shipSize];
                int[] positionsY = new int[shipSize];
                Random random = new Random();

                // test
                Console.WriteLine($"\nShip size: {shipSize}");

                do // generate a ship spot until a valid space is found on the board
                {

                    // test
                    Console.WriteLine("Attempting to generate positions.");

                    // generate a random position on the board
                    posX = random.Next(0, 10);
                    posY = random.Next(0, 10);
                    valid = true; // reset valid to true until the opposite is determined
                    validDir = true;

                    // test
                    Console.WriteLine($"Position generated: {posX}, {posY}");

                    // check if that position has a ship already. If not, continue to the next iteration
                    if (!boardVals[posX, posY].Equals(" "))
                    {
                        valid = false; // may be unnecessary, check later

                        Console.WriteLine("Not a valid position."); // test

                        continue; // skip to next iteration
                    }

                    // generate a random direction
                    direction = random.Next(1, 5);

                    // test
                    Console.WriteLine($"Direction chosen: {direction}");

                    // check that the ship going in that direction would be on the board
                    // temp variables
                    int tempPosX = posX;
                    int tempPosY = posY;

                    for (int i = 0; i < shipSize; i++)
                    {
                        // test
                        Console.WriteLine($"Temp position {i}: {tempPosX}, {tempPosY}");

                        // make sure the position is valid
                        if (tempPosX < 0 || tempPosX > 9 || tempPosY < 0 || tempPosY > 9)
                        {
                            validDir = false; // if one of them is off the board then it's not valid
                            valid = false;

                            Console.WriteLine("Not a valid direction."); // test

                            break;
                        }
                        else
                        {
                            // change the direction positions now to avoid confusion later
                            // these will change again if the positions aren't valid
                            positionsX[i] = tempPosX;
                            positionsY[i] = tempPosY; // remember these will be canceled if it's not all valid

                            switch (direction) // if it's a valid position, change the position according to the direction
                            {
                                case (1):
                                    tempPosX -= 1;
                                    break;
                                case (2):
                                    tempPosX += 1;
                                    break;
                                case (3):
                                    tempPosY -= 1;
                                    break;
                                case (4):
                                    tempPosY += 1;
                                    break;
                                default:
                                    Console.WriteLine("Error picking a direction.");
                                    break;
                            }

                            
                        }

                        // check if it's still a valid direction
                        if (!validDir)
                        {
                            valid = false;

                            Console.WriteLine("Not a valid direction."); // test

                        }


                    }

                    // if it was a valid direction
                    if (validDir)
                    {

                        Console.WriteLine("Valid direction."); // test

                        // check that all those positions are empty on the board

                        Console.WriteLine("\nTesting for empty spots."); // test

                        for (int n = 0; n < shipSize; n++)
                        {
                            Console.WriteLine($"Index: {positionsX[n]},{positionsY[n]}"); // test

                            // check if that position on the board is empty
                            if (!boardVals[positionsX[n], positionsY[n]].Equals(" "))
                            {
                                Console.WriteLine("Not empty. Not a valid ship position."); // test
                                valid = false;
                            }
                            else
                            {
                                Console.WriteLine("Empty spot."); // test
                            }
                        }
                    }
                    

                } while (!valid);

                // NOW that a valid spot has been found for the ship, set those positions to +
                for (int x = 0; x < positionsX.Length; x++)
                {
                    for (int y = 0; y < positionsY.Length; y++)
                    {
                        boardVals[positionsX[x], positionsY[y]] = "+";
                    }
                }





            }
        }

    }
}
