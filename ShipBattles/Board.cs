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

                        for (int x = 0; x < shipSize; x++)
                        {
                            Console.WriteLine($"Index: {positionsX[x]},{positionsY[x]}"); // test

                            // check if that position on the board is empty
                            if (!boardVals[positionsX[x], positionsY[x]].Equals(" "))
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

                


                /*
                // variables
                bool valid = true; // determines if these are valid positions for that ship
                int posX;
                int posY;
                int direction; // 1 is left, 2 is right, 3 is up, 4 is down
                Random random = new Random();

                // generate a random position for the first spot on the ship
                do // if valid remains true, break, otherwise find a different position
                {
                    // variables
                    bool validDir = true; // determine if it's going in a valid direction without running into problems

                    // generate position
                    posX = random.Next(0, 10);
                    posY = random.Next(0, 10);

                    // check if that position is taken or not
                    if (boardVals[posX, posY] != " ") // if it's not " " then it's taken
                    {
                        valid = false; // it's no longer valid if this is the case so it will generate a new position
                        Console.WriteLine("Not valid"); // test
                    }

                    // if it's still valid, generate a direction
                    if (valid) // if it's still alid, continue
                    {
                        do
                        {

                            // generate a direction
                            direction = random.Next(1, 5); // determine which direction to go

                            // determine if all items in that direction are blank, or within range
                            // decide which way it's going though first
                            if (direction == 1) // left
                            {
                                int tempPosX = posX;
                                int tempPosY = posY;


                                // go through positions for that ship
                                for (int i = 0; i < SHIP_SIZES[ship]; i++)
                                {
                                    // test
                                    Console.WriteLine("Ship size: " + SHIP_SIZES[ship]);


                                    // see if it's less than 0
                                    if (tempPosX < 0)
                                    {
                                        validDir = false; // if it's not in the grid, valid is false
                                    }

                                    // check if it's taken or not, and if it's still valid
                                    if (validDir)
                                    {
                                        if (boardVals[tempPosX, tempPosY] != " ")
                                        {
                                            Console.WriteLine("Positions: " + tempPosX + " " + tempPosY); // test
                                            validDir = false; // if the space is taken or off the board, it's not valid
                                        }
                                            
                                    }

                                    // if it's still valid, keep checking, otherwise break
                                    if (validDir)
                                    {
                                        // change the pos
                                        tempPosX -= 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    
                                }
                                

                            } else if (direction == 2) // right
                            {
                                int tempPosX = posX;
                                int tempPosY = posY;


                                // go through positions for that ship
                                for (int i = 0; i < SHIP_SIZES[ship]; i++)
                                {
                                    // see if it's greater than 9
                                    if (tempPosX > 9)
                                    {
                                        validDir = false; // if it's not in the grid, valid is false
                                    }

                                    // check if it's taken or not, and if it's still valid
                                    Console.WriteLine("Positions: " + tempPosX + " " + tempPosY); // test
                                    if (validDir && !boardVals[tempPosX, tempPosY].Equals(" "))
                                    {
                                        validDir = false; // if the space is taken or off the board, it's not valid
                                    }

                                    // if it's still valid, keep checking, otherwise break
                                    if (validDir)
                                    {
                                        // change the pos
                                        tempPosX += 1;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                            } else if (direction == 3) // up 
                            {
                                int tempPosX = posX;
                                int tempPosY = posY;


                                // go through positions for that ship
                                for (int i = 0; i < ship; i++)
                                {
                                    // see if it's less than 0
                                    if (tempPosY < 0)
                                    {
                                        validDir = false; // if it's not in the grid, valid is false
                                    }

                                    // check if it's taken or not, and if it's still valid
                                    if (validDir )
                                    {
                                        if (boardVals[tempPosX, tempPosY].Equals(" "))
                                        {
                                            Console.WriteLine("Positions: " + tempPosX + " " + tempPosY); // test

                                            validDir = false; // if the space is taken or off the board, it's not valid
                                        }
                                        
                                    }

                                    // if it's still valid, keep checking, otherwise break
                                    if (validDir)
                                    {
                                        // change the pos
                                        tempPosY -= 1;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                            } else if (direction == 4) // down
                            {
                                int tempPosX = posX;
                                int tempPosY = posY;


                                // go through positions for that ship
                                for (int i = 0; i < ship; i++)
                                {


                                    // see if it's greater than 9
                                    if (tempPosY > 9)
                                    {
                                        validDir = false; // if it's not in the grid, valid is false
                                    }

                                    // check if it's taken or not, and if it's still valid
                                    if (validDir && !boardVals[tempPosX, tempPosY].Equals(" "))
                                    {
                                        if (boardVals[tempPosX, tempPosY] != " ")
                                        {
                                            Console.WriteLine("Positions: " + tempPosX + " " + tempPosY); // test
                                            validDir = false; // if the space is taken or off the board, it's not valid
                                        }
                                    }

                                    // if it's still valid, keep checking, otherwise break
                                    if (validDir)
                                    {
                                        // change the pos
                                        tempPosY += 1;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                            }

                            // if validDir is still true, then it's valid, so set those positions
                            if (validDir)
                            {
                                for (int i = 0; i < ship; i++)
                                {
                                    int tempPosX = posX;
                                    int tempPosY = posY;

                                    if (direction == 1)
                                    {
                                        
                                        // loop through ship size and set those positions to +
                                        boardVals[posX, posY] = "+";

                                        posX -= 1;
                                    } 
                                    else if (direction == 2)
                                    {

                                        // loop through ship size and set those positions to +
                                        boardVals[posX, posY] = "+";

                                        posX += 1;
                                    }
                                    else if (direction == 3)
                                    {

                                        // loop through ship size and set those positions to +
                                        boardVals[posX, posY] = "+";

                                        posY -= 1;
                                    }
                                    else if (direction == 4)
                                    {

                                        // loop through ship size and set those positions to +
                                        boardVals[posX, posY] = "+";

                                        posY += 1;
                                    }
                                }
                            }
                            


                        } while (!validDir);
                        
                    }


                } while (!valid);

            }
        }
                */

    }
}
