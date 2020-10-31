using System;
using System.Collections.Generic;
using System.Data;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[]
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static void FindWords()
        {
            //Find each of the words in the grid, outputting the start and end location of
            //each word, e.g.
            //PUPPY found at (10,7) to (10, 3) 

            //Loop through Words
            foreach (var word in Words)
            {
                //Loop through Grids
                for (int y = 0; y < 12; y++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        if (Grid[y, x].Equals(word[0]))
                        {
                            ScanCharacterByCoordinate(word, y, x);
                        }
                    }
                    Console.WriteLine("");
                }
            }
        }

        private static void ScanCharacterByCoordinate(string word, int y, int x)
        {
            //int[,] coordinates = new int[,] {
            //    {-1, -1 },  //North West
            //    {-1, 0 },   //North
            //    {-1, 1 },   //North East
            //    {0, -1 },   //West
            //    {0, 1 },    //East
            //    {1, -1 },   //South West
            //    {1, 0 },    //South
            //    {1, 1 },    //South East
            //};

            int[] y_coordinates = { -1, -1, -1, 0, 0, 1, 1, 1 };

            int[] x_coordinates = { -1, 0, 1, -1, 1, -1, 0, 1 };

            //Check 8 directions
            for(var i = 0; i < 8; i++)
            {
                //Direction
                int k, yc = y + y_coordinates[i], xc = x + x_coordinates[i];

                //Starts from second character
                for(k = 1; k < word.Length; k++)
                {
                    //Out of Grid's index
                    if(yc >= 12 || yc < 0 || xc >= 12 || xc < 0)
                    {
                        break;
                    }

                    //Not matched character
                    if(Grid[yc,xc] != word[k])
                    {
                        break;
                    }

                    //Else, keep going that way
                    yc += y_coordinates[i];
                    xc += x_coordinates[i];
                }

                if(k == word.Length)
                {
                    Console.WriteLine(word + " found at " + y + "," + x + " to " + (yc - y_coordinates[i]) + "," + (xc - x_coordinates[i]));
                }
            }
        }
    }
}
