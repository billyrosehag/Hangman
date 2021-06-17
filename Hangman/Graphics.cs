using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class Graphics
    {
        public Graphics()
        {

        }
        public void IntroScreen()
        {

            Console.WriteLine(".......................................");
            Console.WriteLine("......|...|.../\\\\...|\\\\..|..---........");
            Console.WriteLine("......|---|../--\\\\..|.\\\\.|.|.._........");
            Console.WriteLine("......|...|./....\\\\.|..\\\\|.|___|.......");
            Console.WriteLine(".......................................");
            Console.WriteLine("...........|\\\\..../|.../\\\\...|\\\\..|....");
            Console.WriteLine("...........|.\\\\../.|../--\\\\..|.\\\\.|....");
            Console.WriteLine("...........|..\\\\/..|./....\\\\.|..\\\\|....");
            Console.WriteLine(".......................................");


            Console.Write("\n\nPress any key to begin: ");
            Console.ReadKey();

        }
        public void HangmanDrawing(int guessesLeft)
        {
            /*


        0 ...................................  
        1 ..__________.......................      
        2 ..|./.......|...THE.MAN.WAS.HANGED.
        3 ..|/........()......YOU.LOSE.......
        4 ..|......../||\....................
        5 ..|........./\.....................
        6 ..|......../..\....................
        7 ..|................................      
        8 WM|_____MWMWMWMWMWMWMWMWMWMWMWMWMWM 4-9 struct     
        9 ...................................       

        */
            //The hangman drawing
            char[,] charHangmanDisplay = new char[10, 34]{
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},//34  
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
                                                  {'W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M','W','M'},
                                                  {',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',',','},
           };

            //The hangman gets drawn as the guesses depletes
            if (guessesLeft <= 9)
            {
                charHangmanDisplay[8, 4] = '_'; charHangmanDisplay[8, 5] = '_'; charHangmanDisplay[8, 6] = '_'; charHangmanDisplay[8, 7] = '_'; charHangmanDisplay[8, 8] = '_'; charHangmanDisplay[8, 9] = '_';
            }
            if (guessesLeft <= 8)
            {
                charHangmanDisplay[1, 3] = '|'; charHangmanDisplay[8, 3] = '|'; charHangmanDisplay[7, 3] = '|'; charHangmanDisplay[6, 3] = '|'; charHangmanDisplay[5, 3] = '|';
                charHangmanDisplay[4, 3] = '|'; charHangmanDisplay[3, 3] = '|'; charHangmanDisplay[2, 3] = '|';
            }
            if (guessesLeft <= 7)
            {
                charHangmanDisplay[1, 4] = '_'; charHangmanDisplay[1, 5] = '_'; charHangmanDisplay[1, 6] = '_'; charHangmanDisplay[1, 7] = '_';
                charHangmanDisplay[1, 8] = '_'; charHangmanDisplay[1, 9] = '_'; charHangmanDisplay[1, 10] = '_'; charHangmanDisplay[1, 11] = '_';
                charHangmanDisplay[1, 12] = '_'; charHangmanDisplay[1, 13] = '_'; charHangmanDisplay[1, 14] = '_';
            }
            if (guessesLeft <= 6)
            {
                charHangmanDisplay[3, 4] = '/'; charHangmanDisplay[2, 5] = '/';
            }
            if (guessesLeft <= 5)
            {
                charHangmanDisplay[2, 13] = '|';
            }
            if (guessesLeft <= 4)
            {
                charHangmanDisplay[3, 12] = '('; charHangmanDisplay[3, 13] = ')';
            }
            if (guessesLeft <= 3)
            {
                charHangmanDisplay[4, 12] = '|'; charHangmanDisplay[4, 13] = '|';
            }
            if (guessesLeft <= 2)
            {
                charHangmanDisplay[4, 11] = '/'; charHangmanDisplay[4, 14] = '\\';
            }
            if (guessesLeft <= 1)
            {
                charHangmanDisplay[5, 12] = '/'; charHangmanDisplay[6, 11] = '/'; charHangmanDisplay[5, 13] = '\\'; charHangmanDisplay[6, 14] = '\\';
            }


            for (int i = 0; i < charHangmanDisplay.GetLength(0); i++)
            {

                for (int j = 0; j < charHangmanDisplay.GetLength(1); j++)
                {
                    if (charHangmanDisplay[i, j] == '.')
                    {
                        if (guessesLeft > 0)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if
                        (charHangmanDisplay[i, j] == 'M' || charHangmanDisplay[i, j] == 'W')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if
                      (charHangmanDisplay[i, j] == ',')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(charHangmanDisplay[i, j]);

                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
