using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Tests
{
    [TestClass()]
    public class GameTests
    {
        Game game = new Game();

        [TestMethod()]
        public void CheckLetterLowerCaseHTest()
        {
            char letter = 'h';
            bool expected = true;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterLowerCaseATest()
        {
            char letter = 'a';
            bool expected = true;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterUpperCaseGTest()
        {
            char letter = 'G';
            bool expected = true;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterUpperCaseNTest()
        {
            char letter = 'N';
            bool expected = true;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterLowerCasemTest()
        {
            char letter = 'm';
            bool expected = true;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterUpperCaseMTest()
        {
            char letter = 'M';
            bool expected = true;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterLowerCaseNegativeOTest()
        {
            char letter = 'o';
            bool expected = false;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterUpperCaseNegativeBTest()
        {
            char letter = 'B';
            bool expected = false;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterNumberTest()
        {
            char letter = '5';
            bool expected = false;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterWhiteTest()
        {
            char letter = '\n';
            bool expected = false;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CheckLetterWhiteSpaceTest()
        {
            char letter = (char)32;
            bool expected = false;
            bool result = game.CheckLetter(letter);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod()]
        public void CheckCanBeUsedUpperATest()
        {
            Assert.IsTrue(game.CheckCanBeUsed('A'));
        }
        [TestMethod()]
        public void CheckCanBeUsedLowerGTest()
        {
            Assert.IsTrue(game.CheckCanBeUsed('g'));
        }
        [TestMethod()]
        public void CheckCanBeUsedUpperZTest()
        {
            Assert.IsFalse(game.CheckCanBeUsed('Z'));
        }
        [TestMethod()]
        public void CheckCanBeUsedLowerXTest()
        {
            Assert.IsFalse(game.CheckCanBeUsed('x'));
        }
        [TestMethod()]
        public void CheckCanBeUsedNumberTest()
        {
            Assert.IsFalse(game.CheckCanBeUsed('5'));
        }
        [TestMethod()]
        public void CheckCanBeUsedWhiteSpaceTest()
        {
            Assert.IsFalse(game.CheckCanBeUsed('\t'));
        }
        [TestMethod()]
        public void CheckCanBeUsedSpaceTest()
        {
            Assert.IsFalse(game.CheckCanBeUsed(' '));
        }

        [TestMethod()]
        public void ShowGuessedLowerHTest()
        {
            char input = 'h';
            string expected = "H______";
            game.ShowGuessed(input);
            Assert.AreEqual(expected, game.Guess);
        }
        [TestMethod()]
        public void ShowGuessedUpperATest()
        {
            char input = 'A';
            string expected = "_A___A_";
            game.ShowGuessed(input);
            Assert.AreEqual(expected, game.Guess);
        }
        [TestMethod()]
        public void ShowGuessedNumberTest()
        {
            char input = '5';
            string expected = "_______";
            game.ShowGuessed(input);
            Assert.AreEqual(expected, game.Guess);
        }
        [TestMethod()]
        public void ShowGuessedSpaceTest()
        {
            char input = ' ';
            string expected = "_______";
            game.ShowGuessed(input);
            Assert.AreEqual(expected, game.Guess);
        }
        [TestMethod()]
        public void ShowGuessedUpperDTest()
        {
            char input = 'D';
            string expected = "_______";
            game.ShowGuessed(input);
            Assert.AreEqual(expected, game.Guess);
        }
        [TestMethod()]
        public void ShowGuessedLowerMandNTest()
        {
            char inputN = 'n';
            char inputM = 'm';
            string expected = "__N_M_N";
            game.ShowGuessed(inputN);
            game.ShowGuessed(inputM);
            Assert.AreEqual(expected, game.Guess);
        }
        [TestMethod()]
        public void RemoveLetterLowerBTest()
        {
            char input = 'b';
            game.RemoveLetter(input);
            Assert.IsTrue(!game.AvailableLetters.Contains(input));
        }
        [TestMethod()]
        public void RemoveLetterUpperKTest()
        {
            char input = 'K';
            game.RemoveLetter(input);
            Assert.IsTrue(!game.AvailableLetters.Contains(input));
        }
        [TestMethod()]
        public void RemoveLetterSignTest()
        {
            char input = ':';
            game.RemoveLetter(input);
            Assert.IsTrue(!game.AvailableLetters.Contains(input));
        }

        [TestMethod()]
        public void RemoveLifeTest()
        {
            game.RemoveLife();
            int expected = 5;
            Assert.AreEqual(expected, game.Lives);
        }
        [TestMethod()]
        public void RemoveFiveLivesTest()
        {
            for(int i = 0; i<5; i++)
                game.RemoveLife();
            int expected = 1;
            Assert.AreEqual(expected, game.Lives);
        }

        [TestMethod()]
        public void CheckIfWinLoseTest()
        {
            Game newGame = new Game();
            Assert.IsFalse(newGame.CheckIfWin());
        }
        [TestMethod()]
        public void CheckIfWinWinTest()
        {
            Game newGame = new Game();
            foreach (char letter in newGame.Word.Distinct())
                newGame.ShowGuessed(letter);
            Assert.IsTrue(newGame.CheckIfWin());
        }
    }
}
