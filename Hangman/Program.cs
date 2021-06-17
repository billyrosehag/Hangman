using System;
using System.IO;
using System.Text;


namespace Hangman
{
    public class myProgram
    {



        static void Main(string[] args)
        {
            TheGame myGame = new TheGame();

            //IntroScreen
            myGame.GameIntro();

            //Actual application
            myGame.Game();
        }

        public class TheGame
        {
            public bool isalive = true;

            public TheGame()
            {
                

            }
            public void Game()
            {

                do
                {
                    //Variables and objects used in different parts of the application
                    int playerGuesses = 10;
                    string strInput = string.Empty;
                    int intInput = 0;

                    Console.Clear();

                    string welcomeText = "Welcome to Hangman. We have three difficulty types." +
                                         "\n----------------------------------------------------"
                                        +"\n\t1. Easy" +
                                        "\n\t2. Medium" +
                                        "\n\t3. Hard" +
                                        "\n----------------------------------------------------"+
                                        "\nSelect difficulty by inputting corresponding number: ";

                    Console.Write(welcomeText);

                    //Player chooses difficulty
                    do
                    {
                        intInput = NumberRange(StringToInt(Console.ReadLine()), 1, 3);
                    } while (intInput == 0);



                    //String array where all secret words are stored, changes depending on what the player chooses 
                    string[] arrSecretWords = DifficultyLevel(intInput);

                    //Secret word is choosen from an array
                    string secretWord = arrSecretWords[RandomGenerator(0, arrSecretWords.Length)];
                    char[] charCorrectLetters = new char[0];

                    //StringBuilder that stores all the wrong chars
                    StringBuilder wrongCharacters = new StringBuilder();

                    string shownWord = HideWord(secretWord);

                    // ####### The actual hangman game #######
                    while (shownWord != secretWord && playerGuesses > 0)
                    {
                        Console.Clear();
                        //Displays hangman drawing in its current state
                        HangmanGraphic(playerGuesses);

                        // Displays the hidden word
                        Console.WriteLine($"\n\tCurrent word: {shownWord}");

                        // Displays the wrong letters that has been inputted by the player
                        Console.WriteLine("Current wrong discovered letter are: ");
                        MyBuilder(wrongCharacters, '1', true);

                        Console.WriteLine();

                        //Presents player with their options and amounts of guesses left
                        Console.WriteLine($"You can either guess on a single character or the whole word." +
                                         $"\nYou have {playerGuesses} guesses left to find the correct word. \n"
                                         + "What is you guess: ");

                        //Player input
                        strInput = Console.ReadLine().ToUpper();

                        //Creates char used if the player inputs a single character
                        char inputChar = 'l';

                        //Checks how many characters the player has inputted
                        if (strInput.Length == 1)
                        {
                            inputChar = Convert.ToChar(strInput);
                        }
                        else if (strInput == secretWord)
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
                            //Imports player input if it is one letter and is not already inside wrongCharacters string Builder
                            Console.WriteLine("Character not part of the secret word.");
                            if (strInput.Length == 1)
                            {
                                wrongCharacters = MyBuilder(wrongCharacters,inputChar,false);
                                playerGuesses--;
                            }
                        }
                    }

                    //####### PLAYER OUTCOME #######
                    Console.Clear();
                    HangmanGraphic(playerGuesses);
                    if (shownWord == secretWord)//Won
                    {
                        Console.WriteLine($"\tCurrent word: {shownWord}");
                        Console.WriteLine("Great work. You figured out the correct word and " +
                                          "\nsaved the hanging man.");
                        Console.Write("Want to go again (Y/N): ");
                    }
                    else
                    { //Lost
                        Console.WriteLine($"\t----GAME-OVER-----" +
                                        $"\n\nYou are out of guess. The correct word was {secretWord}.\n");
                        Console.Write("Want to go again (Y/N): ");
                    }

                    //The final section of the program, where the player chooses to play again or exit program.
                    isalive = ProgramEnding(Console.ReadLine().ToLower());


                } while (isalive);
            }
            //Replaces each letter of the secret word with lower dashes(_)
            public string HideWord(string secretWord)
            {
                char[] shownWord = new char[secretWord.Length];

                for (int i = 0; i < shownWord.Length; i++)
                {
                    shownWord[i] = '_';
                }
                string result = string.Join("", shownWord);
                return result;
            }

            //Checks if players input is found inside the word, and if true, replaces _ with the letter the player inputted.  
            public string InsertPlayerLetter(string secretWord, string shownWord, char guesschar)
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

            //Chooses which array with words to use 
            public string[] DifficultyLevel(int choosenDifficulty)
            {

                //Arrays that will be filled through a seperate document
                string[] arrLevel3 = new string[] {};

                string[] arrLevel2 = new string[] {};

                string[] arrLevel1 = new string[] {};

          
                //Where in the index each arrLevel array is
                int level1 = 0;
                int level2 = 0;
                int level3 = 0;
                string line;
                string test = "";
                
                //Get string from document
                try
                {
                    using (StreamReader sr = new StreamReader("HangmanWords.txt"))
                    {
                        
                        while ((line = sr.ReadLine()) != null)
                        {
                            test = line;
                        }

                    }
                   
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Size of file larger than available memory on your computer.");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Could not locate file.");
                }
                catch
                {
                    Console.WriteLine("Unforseen error.");
                }

               
                //Split it into an array
                string[] arrFromDoc = test.Split(",");


                //Choose which array to fill into depending on what number each word contains
                for (int i = 0; i < arrFromDoc.Length; i++)
                {
                    if (arrFromDoc[i].Contains('1'))
                    {
                        
                        Array.Resize(ref arrLevel1, arrLevel1.Length + 1);
                        arrLevel1[level1] = arrFromDoc[i];
                        arrLevel1[level1]=arrLevel1[level1].Remove(0, 1);
                        level1++;
                    }
                    else if (arrFromDoc[i].Contains('2'))
                    {
                        
                        Array.Resize(ref arrLevel2, arrLevel2.Length + 1);
                        arrLevel2[level2] = arrFromDoc[i];
                        arrLevel2[level2]=arrLevel2[level2].Remove(0, 1);
                        level2++;
                    }
                    else if (arrFromDoc[i].Contains('3'))
                    {
                        
                        Array.Resize(ref arrLevel3, arrLevel3.Length + 1);
                        arrLevel3[level3] = arrFromDoc[i];
                        arrLevel3[level3] = arrLevel3[level3].Remove(0, 1);
                        level3++;
                    }
                    else
                    {
                        Console.WriteLine("This did not work");
                    }
                }

                //Decides which array to return depending on what difficulty the player has choosen.
                switch (choosenDifficulty)
                {
                    case 3:
                        return arrLevel3;

                    case 2:
                        return arrLevel2;

                    case 1:
                        return arrLevel1;

                    default:
                        return arrLevel1;
                }

            }
            //Checks if the correct letter is not still in the char, and if it isnt, adds it to the char.
            public char[] CorrectLetters(char[] charMyChar, char input)
            {
                bool letterExists = false;
                for (int i = 0; i < charMyChar.Length; i++)
                {
                    if (charMyChar[i] == input)
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

            //Method shown at the end of the hangman program
            public bool ProgramEnding(string answer)
            {
                bool playerAnswer = false;

                //Checks whether the player wants to play again or not


                if (Equals(answer, "y") || Equals(answer, "yes"))
                {
                    //Game will begin again
                    playerAnswer = true;
                }
                else if (Equals(answer, "n") || Equals(answer, "no"))
                {
                    Console.Write("program will exit. Press any key to continue: ");
                    Console.ReadKey();
                    isalive = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Program will exit.");
                    Console.ReadKey();
                    playerAnswer = false;
                }
                return playerAnswer;
            }
            //These are the methods that I've turned into classes, in order to make Unit testing easier to manage

            //Checks to make sure that player input is a int 
            public int StringToInt(string input)
            {
                bool correctFormat = false;
                int result = 0;
               
                    try
                    {
                        correctFormat = int.TryParse(input, out result);
                        
                    }
                    catch (FormatException)
                    {
                        Console.Write("Wrong format. Please try again: ");
                    }
                    catch (OverflowException)
                    {
                        Console.Write("Too big number. Try again: ");
                    }
                
                return result;
            }

            public int RandomGenerator(int start, int exclusive)
            {
                Random rng = new Random();

                int result = rng.Next(start, exclusive);

                return result;

            }

            public StringBuilder MyBuilder(StringBuilder input, char character, bool show) {

              
                    if (!show &&!input.ToString().Contains(character))
                    {
                        input.Append(character);
                    }
                else
                {
                    foreach(char c in input.ToString())
                    {
                        Console.Write($" {c} "); 
                    }

                }
                

                return input;
            
            }

            //Checks to make sure that player input is a int and that the int is within the parameters start and end
            public int NumberRange(int value, int start, int end)
            {
               
                do
                {
                   
                    if (value < start || value > end)
                    {
                        Console.Write("The option is not available. Try again: ");
                        value = StringToInt(Console.ReadLine());
                    }


                } while (value < start || value > end);

                return value;
            }

            
            //The intro screen
            public void GameIntro()
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

            //The hangman drawing
            public char[,] HangmanGraphic(int guessesLeft)
            {

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

                return charHangmanDisplay;
            }

        }
    }

}


