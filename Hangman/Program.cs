using System;
using System.Text;

namespace Hangman
{
    class Program
    {
        public static bool isalive = true;


        static void Main(string[] args)
        {
            HangmanGrafic();
            Hangman();

        }

        public static void Hangman()
        {
            do
            {

                int playerGuesses = 10;
                string input = string.Empty;
                Random r = new Random();

                Console.Clear();

                Console.Write($"Welcome to Hangman. We have three difficulty types.\n" +
                    $"1. Easy\n" +
                    $"2. Medium\n" +
                    $"3. Hard\n" +
                    $"Select difficulty by inputting corresponding number: ");
                
                int difficulty = StringToInt();

                //String array where all secret words are stored, changes depending on choosen 
                string[] arrSecretWords = DifficultyLevel(difficulty);

                string secretWord = arrSecretWords[r.Next(0, arrSecretWords.Length - 1)];
                char[] charCorrectLetters = new char[0];

                //StringBuilder that stores all the wrong chars
                StringBuilder wrongCharacters = new StringBuilder();

                

                string shownWord = HideWord(secretWord);


                //The actual hangman game
                while (shownWord != secretWord && playerGuesses > 0)
                {
                    Console.Clear();
                    
                    HangmanGrafic(playerGuesses);


                    Console.WriteLine($"\nCurrent word: {shownWord}");

                    Console.WriteLine("Current wrong discovered letter are: ");
                    foreach (char letter in wrongCharacters.ToString())
                    {
                        Console.Write($" {letter} ");
                    }
                    Console.WriteLine();

                    Console.WriteLine($"You can either guess on a single character or the whole word." +
                                    $"\nYou have {playerGuesses} guesses left to find the correct word. \n"
                                       + "What is you guess: ");
                    //Player input


                    input = Console.ReadLine().ToUpper();
                    


                    char inputChar = 'l';

                    //Checks how many characters the player has inputted
                    if (input.Length == 1)
                    {
                        inputChar = Convert.ToChar(input);
                    }
                    else if (input == secretWord)
                    {
                        shownWord = secretWord;
                    }
                    else
                    {
                        //Wrong string
                        playerGuesses--;
                    }

                    //Checks whether the input character is found in the secret word or not
                    if (secretWord.Contains(inputChar) && shownWord != secretWord)
                    {
                        shownWord = InsertPlayerLetter(secretWord, shownWord, inputChar);
                        Console.WriteLine("Correct Letter!");
                        charCorrectLetters = CorrectLetters(charCorrectLetters, inputChar);
                        

                    }
                    else
                    {
                        Console.WriteLine("Character not part of the secret word.");
                        if (!wrongCharacters.ToString().Contains(inputChar))
                        {
                            wrongCharacters.Append(inputChar);
                            playerGuesses--;
                        }
                    }

                    if (input == secretWord)
                    {
                        shownWord = secretWord;
                    }
                }
                
                //End Message
                Console.Clear();
                if (shownWord == secretWord)//Won
                {
                    HangmanGrafic(playerGuesses);
                    Console.WriteLine($"Current word: {shownWord}");
                    Console.WriteLine("Great work. You figured out the correct word and " +
                                      "\nsaved the hanging man.");
                    Console.Write("Want to go again (Y/N): ");
                }
                else
                { //Lost
                    HangmanGrafic(playerGuesses);
                    Console.WriteLine($"----GAME-OVER-----" +
                                    $"\nYou are out of guess. The correct word was {secretWord}.\n");
                    Console.Write("Want to go again (Y/N: ");
                }
                //Checks whether the player wants to play again or not
                string answer = Console.ReadLine().ToLower();

                if(answer == "y" || answer == "yes")
                {
                    //Game will begin again
                }
                else if (answer == "n" || answer == "no")
                {
                    Console.Write("program will exit. Press any key to continue: ");
                    Console.ReadKey();
                    isalive = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Program will exit.");
                    Console.ReadKey();
                    isalive = false;
                }


            } while (isalive);
        }
        private static string HideWord(string secretWord)
        {
            char[] shownWord = new char[secretWord.Length];

            for (int i = 0; i < shownWord.Length; i++)
            {
                shownWord[i] = '_';
            }
            string result = string.Join("", shownWord);
            return result;
        }


        private static string InsertPlayerLetter(string secretWord, string shownWord, char guesschar)
        {
            char[] charCheck = shownWord.ToCharArray();
            char[] charSecretWord = secretWord.ToCharArray();

            for (int i = 0; i < charCheck.Length; i++)
            {
                if (charSecretWord[i] == guesschar)
                {
                    charCheck[i] = guesschar;
                }
            }
            shownWord = new string(charCheck);

            return shownWord;
        }
    
        static void HangmanGrafic()
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

        static void HangmanGrafic(int guessesLeft)
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

            if(guessesLeft <= 9)
            {
                charHangmanDisplay[8,4] = '_'; charHangmanDisplay[8,5] = '_'; charHangmanDisplay[8,6] = '_'; charHangmanDisplay[8, 7] = '_'; charHangmanDisplay[8, 8] = '_'; charHangmanDisplay[8, 9] = '_';
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
            if(guessesLeft<= 6)
            {
                charHangmanDisplay[3, 4] = '/'; charHangmanDisplay[2, 5] = '/';
            }
            if(guessesLeft<=5)
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

                for(int j = 0; j < charHangmanDisplay.GetLength(1); j++)
                {
                    if (charHangmanDisplay[i, j] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
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

        static string[] DifficultyLevel(int choosenDifficulty)
        {
            string[] arrLevel3 = new string[] { "NEIGHBOOR", "LOCOMOTIVE", "WATERFALL", "INDEPENDENCE",
                                                    "SLAVARY", "GRASSHOPPER", "PROGRAMMING", "STARLIGHT" };

            string[] arrLevel2 = new string[] { "BEHIND", "DRINK", "FALLEN", "KITTEN",
                                                    "HOPEFUL", "FASTER", "VICTORY", "JESTER" };

            string[] arrLevel1 = new string[] { "HAND", "TAPE", "CARRY", "DOG",
                                                    "WINE", "WATER", "HAPPY", "SAD" };

            if(choosenDifficulty == 3)
            {
                return arrLevel3;
            }
            else if(choosenDifficulty == 2)
            {
                return arrLevel2;
            }
            else
            {
                return arrLevel1;
            }

        }

        static int StringToInt()
        {
            bool isNumber = false;
            int input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    isNumber = true;
                }
                catch (FormatException)
                {
                    Console.Write("Wrong format. Please try again: ");
                }
                catch (OverflowException)
                {
                    Console.Write("Too big number. Try again: ");
                }


            } while (!isNumber);

            return input;
        }

        static char[] CorrectLetters(char[] charMyChar,char input)
        {
            bool letterExists = false;
            for(int i=0; i<charMyChar.Length; i++)
            {
                if(charMyChar[i] == input)
                {
                    letterExists = true;
                    break;
                }
            }
            if (letterExists == false)
            {
                Array.Resize(ref charMyChar, charMyChar.Length + 1);
                charMyChar[charMyChar.Length - 1] = input;
            }

            return charMyChar;
        }
            
            

        }

    }


