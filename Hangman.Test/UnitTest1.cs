using System;
using Xunit;
using Hangman;
using static Hangman.myProgram;
using System.Text;

namespace Hangman.Test
{
    public class HangmanShould
    {       
        //HideWord()
        [Fact]
        public void HideWordWhenCalled()
        {
            TheGame sut = new TheGame();

            string expected = "_____";

            string actual = sut.HideWord("Hello");

            Assert.Equal(expected, actual);

        }

        //ProgramEnding()
        [Fact]
        public void RestartProgramWhenCalled()
        {
            TheGame sut = new TheGame();

            //bool expected = false;

            bool actual = sut.ProgramEnding("y");

            Assert.True(actual);
        }
          
        //StringToInt
        [Fact]
        public void ReturnNumberIfCorrectInput()
        {
            TheGame sut = new TheGame();

            int expected = 5;
            int actual = sut.StringToInt("5");

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ReturnZeroIfWrongInput()
        {
            TheGame sut = new TheGame();

            int expected = 0;
            int actual = sut.StringToInt("Not a number");

            Assert.Equal(expected, actual);
        }

        //MyBuilder()
        [Fact]
        public void AddToWrongCharacters()
        {
            TheGame sut = new TheGame();

            StringBuilder actual = new StringBuilder("string");

            string expected = "stringy";

            actual = sut.MyBuilder(actual, 'y',false);

            Assert.Equal(expected, actual.ToString());

        }
        [Fact]
        public void ShowNotAdd()
        {
            TheGame sut = new TheGame();

            StringBuilder actual = new StringBuilder("string");

            string expected = "string";

            actual = sut.MyBuilder(actual, 'y', true);

            Assert.Equal(expected, actual.ToString());
        }

        [Fact]

        public void RandomCheck()
        {
            TheGame sut = new TheGame();

            int actual = sut.RandomGenerator(1, 11);

            Assert.InRange(actual, 1, 10);

        }

        //NumberRange();
        [Fact]
        public void ReturnNumberWhenInRange()
        {
            TheGame sut = new TheGame();

            int expected = 2;

            int actual = sut.NumberRange(2, 1, 3);


            Assert.Equal(expected, actual);

        }
  

        //InsertPlayerLetter();
        [Fact]
        public void GiveRevealCharinWord()
        {
            TheGame sut = new TheGame();

            string expected = "W___";

            string actual = sut.InsertPlayerLetter("WORD", "____", 'W');

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GiveNOtRevealCharinWord()
        {
            TheGame sut = new TheGame();

            string expected = "____";

            string actual = sut.InsertPlayerLetter("WORD", "____", 'P');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GiveLevel1ArrayWhenCalled()
        {
            TheGame sut = new TheGame();

            string[] expected = new string[] { "HAND", "TAPE", "CARRY", "DOG",
                                                    "WINE", "WATER", "HAPPY", "SAD" };

            string[] actual = sut.DifficultyLevel(1);

            Assert.Equal(expected, actual);

        }
       
        //DifficultyLevel();

        [Fact]
        public void Level1ArrayContainsHand()
        {
            TheGame sut = new TheGame();

            string expected = "HAND";

            string[] actual = sut.DifficultyLevel(1);

            Assert.Contains(expected, actual);

        }

        [Fact]
        public void GiveFirstIndexOfLevel1WhenCalled()
        {
            TheGame sut = new TheGame();

            string[] arrSut = sut.DifficultyLevel(1);

            string expected = "HAND";

            string actual = arrSut[0];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NoNullOrWhiteSpacesInLevel1To3()
        {
            //Checks to see if the arrays created during the DifficultyLevel phase have null or white spaces within them. Which they
            //Shouldn't
            TheGame sut = new TheGame();

            Assert.All(sut.DifficultyLevel(1), word=>Assert.False(string.IsNullOrWhiteSpace(word)));
            Assert.All(sut.DifficultyLevel(2), word => Assert.False(string.IsNullOrWhiteSpace(word)));
            Assert.All(sut.DifficultyLevel(3), word => Assert.False(string.IsNullOrWhiteSpace(word)));
        }

        //CorrectLetters();

        [Fact]
        public void AddCharAToCharArray()
        {
            TheGame sut = new TheGame();

            char[] expected = new char[] { 'a' };

            char[] actual = new char[0];

            actual = sut.CorrectLetters(actual, 'a');

            Assert.Equal(expected, actual);


        }
        [Fact]
        public void NotAddCharAToCharArray()
        {
            TheGame sut = new TheGame();

            char[] expected = new char[] { 'a' };

            char[] actual = new char[] { 'a' };

            actual = sut.CorrectLetters(actual, 'a');

            Assert.Equal(expected, actual);


        }
        [Fact]
        public void ExpandCharAToCharArray()
        {
            TheGame sut = new TheGame();

            

            char[] actual = new char[] { 'a' };
            char[] expected = actual;

            actual = sut.CorrectLetters(actual, 'b');

            Assert.NotEqual(expected, actual);


        }

        [Fact]
        public void LengthLayer1HangmanDrawing()
        {
            TheGame sut = new TheGame();

            int expected = 34;

            int actual = sut.HangmanGraphic(10).GetLength(1);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LengthLayer0HangmanDrawing()
        {
            TheGame sut = new TheGame();

            int expected = 10;

            int actual = sut.HangmanGraphic(10).GetLength(0);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetChangesToDrawingAt1GuessesLeft()
        {
            TheGame sut = new TheGame();

            char[,] arrSut = sut.HangmanGraphic(1);

            char expected = '/';

            char actual = arrSut[5, 12]; 

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BeAlive()
        {
            TheGame sut = new TheGame();


            Assert.True(sut.isalive);
        }





    }
}
