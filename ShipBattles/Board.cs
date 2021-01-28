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


    }
}
