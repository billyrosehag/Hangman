using System;
using Xunit;
using Hangman;
using static Hangman.myProgram;

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


        [Fact]
        public void ExitProgramWhenCalled()
        {
            TheGame sut = new TheGame();

            sut.isalive = false;

            

            Assert.False(sut.ProgramEnding("n"));

        }

        [Fact]
        public void GiveIntBackWhenCalled()
        {
            TheGame sut = new TheGame();

            int expected = 3;

            int actual = sut.StringToInt(1, 3);

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



    }
}
