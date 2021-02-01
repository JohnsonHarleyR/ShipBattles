using System;
using System.Collections.Generic;
using System.Text;

namespace ShipBattles

// ChangeSpaceToNums() - turn string coordinates into number coordinates
// ChangeSpaceToString() - turn number coordinates into string

// GetSpaceVal(string input) - get value of space on board based on string input

//AddShip

// For marking a ship and determining if it's afloat or sunk

// GetAllShipCoords - dictionaries of ship coordinates and bools whether they're afloat - by name
// GetAllShipsAfloat
//CheckShipAfloat check if a particular ship is afloat - returns a bool
//DetermineShipBySpace - find out the name of a ship that has just been hit - returns a string with name
//TestDisplayShipCoords - a way to test that the coords were entered correctly into a list


//MarkSpaceAsHit
//MarkSpaceAsMiss
//MarkSpaceAsShip

//GenerateAIPositions - for the AI to generate a board - TODO move this to AI class when possible
{
    class Board
    {
        
        private readonly int[] SHIP_SIZES = new int[]{5, 4, 3, 3, 2}; // how big each ship is
        private readonly string[] SHIP_NAMES = new string[]{"Carrier", // the names of each ship, matches respectively to sizes
        "Battleship", "Cruiser", "Submarine", "Destroyer"};
        // private readonly string[] letters = new string[] { "A", "B", "C", "D", // letters on the board
           //     "E", "F", "G", "H", "I", "J" };
        private string[,] boardVals = new string[10, 10];

        // Information for ships - if it's a ship board
        private List<string> Carrier = new List<string>(); // these ships will store the coordinates of every position
        private List<string> Battleship = new List<string>(); // coordinates listed as string to simplify
        private List<string> Cruiser = new List<string>();
        private List<string> Submarine = new List<string>();
        private List<string> Destroyer = new List<string>();
        private Dictionary<string, List<string>> shipCoords = new Dictionary<string, List<string>>();
        private Dictionary<string, bool> shipsAfloat = new Dictionary<string, bool>(); // keeps track of whether a ship is still afloat
        // (the above correlates to ship sizes and names)

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

            // add ships to dictionary of ships
            shipCoords.Add("Carrier", Carrier); shipCoords.Add("Battleship", Battleship); shipCoords.Add("Cruiser", Cruiser);
            shipCoords.Add("Submarine", Submarine); shipCoords.Add("Destroyer", Destroyer);

            // add true values to ships afloat
            shipsAfloat.Add("Carrier", true); shipsAfloat.Add("Battleship", true); shipsAfloat.Add("Cruiser", true);
            shipsAfloat.Add("Submarine", true); shipsAfloat.Add("Destroyer", true);

        }

        // get the dictionary of ship coordinates
        public Dictionary<string, List<string>> GetAllShipCoords()
        {
            return shipCoords;
        }

        // get the list of ships still afloat
        public Dictionary<string, bool> GetAllShipsAfloat()
        {
            return shipsAfloat;
        }

        // get the ship names
        public string[] GetShipNames()
        {
            return SHIP_NAMES;
        }

        // get the ship sizes
        public int[] GetShipSizes()
        {
            return SHIP_SIZES;
        }

        // Get the array from the board
        public string[,] GetBoardVals()
        {
            return boardVals;
        }

        // Get the value of a space on the board based on input position
        public string GetSpaceVal(string input)
        {
            try // some validation just in case - TODO Add similar validation to other methods - try catch
            {
                int[] pos = ChangeSpaceToNums(input); // gets coordinates based on validated user input
                return boardVals[pos[0], pos[1]];
            } catch (Exception)
            {
                Console.WriteLine("Error: not a valid position to get value.");
                return "error";
            }
            
        }


        // check if a particular ship is afloat - returns a bool
        public bool CheckShipAfloat(string shipName)
        {
            bool afloat = false;
            

            // iterate through that ship's coordinates by it's name
            // if any of them are still marked "+", it is afloat
            foreach (string coord in shipCoords[shipName])
            {
                if (GetSpaceVal(coord).Equals("+"))
                {
                    afloat = true;
                }    
            }

            // also set that ship's boolean to that value (NOTE: this dictionary may not prove necessary)
            shipsAfloat[shipName] = afloat;

            Console.WriteLine($"Test - Ship afloat?: {afloat}"); // test

            return afloat; // return result

    }

        // determine which ship has a space in their coordinates - for when there's a hit
        public string DetermineShipBySpace(string space)
        {
            // loop through the dictionary of ships and their spaces, see if any of them match
            // if it does, return the name of that ship
            foreach (KeyValuePair<string, List<string>> ship in shipCoords)
            {
                // loop through that ships coordinates
                foreach(string coord in ship.Value)
                {
                    // if there's a match in the ship's coordinates, return that ship's name
                    if (coord == space)
                    {
                        Console.WriteLine($"Test - Found ship: {ship.Key}"); // test

                        return ship.Key;
                    }
                }

            }

            // if there's no match, return a string saying no match
            return "no match";

        }





        // mark as space on the board as hit
        public void MarkSpaceAsHit(string input)
        {
            int[] pos = ChangeSpaceToNums(input); // gets coordinates based on validated user input
            // mark that board value as "x"
            boardVals[pos[0], pos[1]] = "x";

        }

        // mark as space on the board as hit
        public void MarkSpaceAsMiss(string input)
        {
            int[] pos = ChangeSpaceToNums(input); // gets coordinates based on validated user input
            // mark that board value as "o"
            boardVals[pos[0], pos[1]] = "o";
        }


        // checking whether a ship is still afloat or not


        // display coordinates of a ship in the console - for testing
        public void TestDisplayShipCoord(string shipName)
        {
            List<string> ship = shipCoords[shipName];
            Console.Write($"\nTest - displaying '{shipName}' coords: ");
            foreach (string coord in ship)
            {
                Console.Write($"{coord},");
            }
        }



        // Add a ship to the board - do this only after the ship spaces have been validated
        public void AddShip(string shipName, string pos1String, string pos2String)
        {
            // variables
            //bool successful = true; // determines if a ship can be places where it's told to be placed
            int[] pos1 = ChangeSpaceToNums(pos1String); // get space coordinates as a number
            int[] pos2 = ChangeSpaceToNums(pos2String);
            List<string> ship;
            //int shipSize;

            // find out which ship is being assigned
            // find out what size the ship is supposed to be
            switch (shipName)
            {
                case "Carrier":
                    ship = Carrier; // assign the ship so coordinates can be added
                    break;
                case "Battleship":
                    ship = Battleship;
                    break;
                case "Cruiser":
                    ship = Cruiser;
                    break;
                case "Submarine":
                    ship = Submarine;
                    break;
                case "Destroyer":
                    ship = Destroyer;
                    break;
                default:
                    Console.WriteLine("Error: ship type is not valid.");
                    ship = new List<string>();
                    break;
            }

            // change spaces in line to "+"
            int tempX;
            int tempY;
            int tempTop; // the lst space in the line
            if (pos1[1] == pos2[1]) // if the y values are the same, then the different positions must be the x's
            {
                // figure out which value is lower, then set x and y
                // start with the lower position as the temp
                if (pos1[0] < pos2[0])
                {
                    tempX = pos1[0];
                    tempTop = pos2[0];
                }
                else
                {
                    tempX = pos2[0];
                    tempTop = pos1[0];
                }
                tempY = pos1[1]; // the y will be the same for both so set the temp to either one

                // loop through values to change
                for (int i = tempX; i <= tempTop; i++)
                {
                    boardVals[i, tempY] = "+";
                }

            }
            else // otherwise the x values are the same so do it the opposite
            {
                // figure out which value is lower, then set x and y
                // start with the lower position as the temp
                if (pos1[1] < pos2[1])
                {
                    tempY = pos1[1];
                    tempTop = pos2[1];
                }
                else
                {
                    tempY = pos2[1];
                    tempTop = pos1[1];
                }
                tempX = pos1[0]; // the x will be the same for both so set the temp to either one

                // loop through values to change
                for (int i = tempY; i <= tempTop; i++)
                {
                    boardVals[tempX, i] = "+";
                    ship.Add(ChangeSpaceToString(new int[] {tempX, i }));

                   
                }

                //TestDisplayShipCoord(shipName); // test

            }
        }

        // validate space for ship to enter board
        public bool ValidateShipSpace( string shipName, string pos1String, string pos2String)
        {
            // this returns a boolean that tells if adding it was successful or not
            // NOTE testing for correct letter input must be done in the main program

            // variables
            //bool successful = true; // determines if a ship can be places where it's told to be placed
            int[] pos1 = ChangeSpaceToNums(pos1String); // get space coordinates as a number
            int[] pos2 = ChangeSpaceToNums(pos2String);
            int xDif = Math.Abs(pos2[0] - pos1[0]) + 1;
            int yDif = Math.Abs(pos2[1] - pos1[1]) + 1;
            int shipSize;

            // find out what size the ship is supposed to be
            switch (shipName)
            {
                case "Carrier":
                    shipSize = 5;
                    break;
                case "Battleship":
                    shipSize = 4;
                    break;
                case "Cruiser":
                    shipSize = 3;
                    break;
                case "Submarine":
                    shipSize = 3;
                    break;
                case "Destroyer":
                    shipSize = 2;
                    break;
                default:
                    Console.WriteLine("Error: ship type is not valid.");
                    return false; // it didn't match a ship so return false - not successful - avoid going further
            }

            //Console.WriteLine($"Ship Size: {shipSize}"); // test

            //Console.WriteLine($"X Dif: {xDif}"); // test
            //Console.WriteLine($"Y Dif: {yDif}"); // test

            // first make sure that the difference in spaces matches what's necessary for that type of ship
            if (shipSize != xDif && shipSize != yDif)
            {
                //successful = false;
                //Console.WriteLine($"Difference does not match ship size."); // test

                return false;
            }

            // make sure the spaces are in line either vertically or horizonally
            if (pos1[0] != pos2[0] && pos1[1] != pos2[1])
            {
                //successful = false;
                return false; // it is not in a straight line so return false
            }

            // now test all spaces in that ship line to make sure they do not have "+" ****GOOD FOR ANOTHER FUNCTION****
            int tempX;
            int tempY;
            int tempTop; // the lst space in the line
            if (pos1[1] == pos2[1]) // if the y values are the same, then the different positions must be the x's
            {
                // figure out which value is lower, then set x and y
                // start with the lower position as the temp
                if (pos1[0] < pos2[0])
                {
                    tempX = pos1[0];
                    tempTop = pos2[0];
                } else
                {
                    tempX = pos2[0];
                    tempTop = pos1[0];
                }
                tempY = pos1[1]; // the y will be the same for both so set the temp to either one

                // loop through values to test
                for (int i = tempX; i <= tempTop; i++)
                {
                    // now test if all those positions are empty
                    if (!boardVals[i, tempY].Equals(" "))
                    {
                        return false; // if a space isn't empty, then it's not successful
                    }
                }

            } else // otherwise the x values are the same so do it the opposite
            {
                // figure out which value is lower, then set x and y
                // start with the lower position as the temp
                if (pos1[1] < pos2[1])
                {
                    tempY = pos1[1];
                    tempTop = pos2[1];
                }
                else
                {
                    tempY = pos2[1];
                    tempTop = pos1[1];
                }
                tempX = pos1[0]; // the x will be the same for both so set the temp to either one

                // loop through values to test
                for (int i = tempY; i <= tempTop; i++)
                {
                    // now test if all those positions are empty
                    if (!boardVals[tempX, i].Equals(" "))
                    {
                        return false; // if a space isn't empty, then it's not successful
                    }
                }

            }

            return true; // if it has survived thus far, it must be successful so return true
            //return successful; // return whether it was successful

        }

        // mark as space on the board as part of your ship
        public void MarkSpaceAsShip(int[] pos)
        {
            // mark that board value as "+"
            boardVals[pos[0], pos[1]] = "+";
        }


        // returns the number positions on a board based on a user's input
        // NOTE the input must be in this format "A1" - should already be validated
        public int[] ChangeSpaceToNums(string space)
        {
            // variables
            string posX;
            int posY;
            int[] positions = new int[2];

            // first get the first position based on the letter
            posX = space.Substring(0, 1);
            // figure out which one it matches and assign accordingly
            switch (posX)
            {
                case ("A"):
                    positions[0] = 0; 
                    break;
                case ("B"):
                    positions[0] = 1;
                    break;
                case ("C"):
                    positions[0] = 2;
                    break;
                case ("D"):
                    positions[0] = 3;
                    break;
                case ("E"):
                    positions[0] = 4;
                    break;
                case ("F"):
                    positions[0] = 5;
                    break;
                case ("G"):
                    positions[0] = 6;
                    break;
                case ("H"):
                    positions[0] = 7;
                    break;
                case ("I"):
                    positions[0] = 8;
                    break;
                case ("J"):
                    positions[0] = 9;
                    break;
                default:
                    Console.WriteLine("Error: could not match position of letter.");
                    break;
            }

            // now get the second position based on the number - subtract 1
            if (space.Length == 3) // if it's 3 letters long, that means this number is 10 so parse 2 numbers
            {
                posY = Int32.Parse(space.Substring(1, 2)) - 1; // subtract 1
            } else
            {
                posY = Int32.Parse(space.Substring(1, 1)) - 1; // subtract 1
            }

            // set it to the second position in the array
            positions[1] = posY;
            

            return positions; // return result

        }


        // Make a string based on a position
        public string ChangeSpaceToString(int[] pos)
        {
            string posString;

            // first add to string based on matching letter
            switch (pos[0])
            {
                case 0:
                    posString = "A";
                    break;
                case 1:
                    posString = "B";
                    break;
                case 2:
                    posString = "C";
                    break;
                case 3:
                    posString = "D";
                    break;
                case 4:
                    posString = "E";
                    break;
                case 5:
                    posString = "F";
                    break;
                case 6:
                    posString = "G";
                    break;
                case 7:
                    posString = "H";
                    break;
                case 8:
                    posString = "I";
                    break;
                case 9:
                    posString = "J";
                    break;
                default:
                    posString = "O";
                    Console.WriteLine("Error: position x did not match a letter.");
                    break;
            }

            // now add the number at the end - add 1
            int temp = pos[1] + 1;
            posString += temp;

            // return the string;
            return posString;
        }

        // Get the different ships
        public List<string> GetCarrier()
        {
            return Carrier;
        }
        public List<string> GetBattleship()
        {
            return Battleship;
        }
        public List<string> GetCruiser()
        {
            return Cruiser;
        }
        public List<string> GetSubmarine()
        {
            return Submarine;
        }
        public List<string> GetDestroyer()
        {
            return Destroyer;
        }



        // Generate random positions of ships for an AI board
        // TODO move this to the AI class
        public void GenerateAIPositions()
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
                //Console.WriteLine($"\nShip size: {shipSize}");

                do // generate a ship spot until a valid space is found on the board
                {

                    // test
                    //Console.WriteLine("Attempting to generate positions.");

                    // generate a random position on the board
                    posX = random.Next(0, 10);
                    posY = random.Next(0, 10);
                    valid = true; // reset valid to true until the opposite is determined
                    validDir = true;

                    // test
                    //Console.WriteLine($"Position generated: {posX}, {posY}");

                    // check if that position has a ship already. If not, continue to the next iteration
                    if (!boardVals[posX, posY].Equals(" "))
                    {
                        valid = false; // may be unnecessary, check later

                        //Console.WriteLine("Not a valid position."); // test

                        continue; // skip to next iteration
                    }

                    // generate a random direction
                    direction = random.Next(1, 5);

                    // test
                    //Console.WriteLine($"Direction chosen: {direction}");

                    // check that the ship going in that direction would be on the board
                    // temp variables
                    int tempPosX = posX;
                    int tempPosY = posY;

                    for (int i = 0; i < shipSize; i++)
                    {
                        // test
                        //Console.WriteLine($"Temp position {i}: {tempPosX}, {tempPosY}");

                        // make sure the position is valid
                        if (tempPosX < 0 || tempPosX > 9 || tempPosY < 0 || tempPosY > 9)
                        {
                            validDir = false; // if one of them is off the board then it's not valid
                            valid = false;

                            //Console.WriteLine("Not a valid direction."); // test

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

                            //Console.WriteLine("Not a valid direction."); // test

                        }


                    }

                    // if it was a valid direction
                    if (validDir)
                    {

                        //Console.WriteLine("Valid direction."); // test

                        // check that all those positions are empty on the board

                        //Console.WriteLine("\nTesting for empty spots."); // test

                        for (int n = 0; n < shipSize; n++)
                        {
                            //Console.WriteLine($"Index: {positionsX[n]},{positionsY[n]}"); // test

                            // check if that position on the board is empty
                            if (!boardVals[positionsX[n], positionsY[n]].Equals(" "))
                            {
                                //Console.WriteLine("Not empty. Not a valid ship position."); // test
                                valid = false;
                            }
                            else
                            {
                                //Console.WriteLine("Empty spot."); // test
                            }
                        }
                    }
                    

                } while (!valid);

                // NOW that a valid spot has been found for the ship, set those positions to +
                string shipName = SHIP_NAMES[ship];
                for (int x = 0; x < positionsX.Length; x++)
                {
                    for (int y = 0; y < positionsY.Length; y++)
                    {
                        boardVals[positionsX[x], positionsY[y]] = "+";
                        //also add coordinates to that ship in dictionary
                        if (!shipCoords[shipName].Contains(ChangeSpaceToString(new int[] { positionsX[x], positionsY[y] })))
                        { // avoid repeats in the list
                            shipCoords[shipName].Add(ChangeSpaceToString(new int[] { positionsX[x], positionsY[y] }));
                        }
                        

                    }
                }

                //TestDisplayShipCoord(shipName); // test



            }
        }

    }
}
