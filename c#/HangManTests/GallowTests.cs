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
    public class GallowTests
    {
        [TestMethod()]
        public void ReturnStageOneTest()
        {
            string expected = 
                "  +---+\n" +
                "  |   |\n" +
                "      |\n" +
                "      |\n" +
                "      |\n" +
                "      |\n" +
                "=========\n";


            int lives = 6;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod()]
        public void ReturnStageTwoTest()
        {
            string expected =
                "  +---+\n" +
                "  |   |\n" +
                "  O   |\n" +
                "      |\n" +
                "      |\n" +
                "      |\n" +
                "=========\n";
            int lives = 5;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod()]
        public void ReturnStageThreeTest()
        {
            string expected =
                "  +---+\n" +
                "  |   |\n" +
                "  O   |\n" +
                "  |   |\n" +
                "      |\n" +
                "      |\n" +
                "=========\n";
            int lives = 4;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod()]
        public void ReturnStageFourTest()
        {
            string expected =
                "  +---+\n" +
                "  |   |\n" +
                "  O   |\n" +
                " /|   |\n" +
                "      |\n" +
                "      |\n" +
                "=========\n";
            int lives = 3;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod()]
        public void ReturnStageFiveTest()
        {
            string expected =
                "  +---+\n" +
                "  |   |\n" +
                "  O   |\n" +
                " /|\\  |\n" +
                "      |\n" +
                "      |\n" +
                "=========\n";
            int lives = 2;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod()]
        public void ReturnStageSixTest()
        {
            string expected =
                "  +---+\n" +
                "  |   |\n" +
                "  O   |\n" +
                " /|\\  |\n" +
                " /    |\n" +
                "      |\n" +
                "=========\n";
            int lives = 1;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod()]
        public void ReturnStageFinalTest()
        {
            string expected =
                "  +---+\n" +
                "  |   |\n" +
                "  O   |\n" +
                " /|\\  |\n" +
                " / \\  |\n" +
                "      |\n" +
                "=========\n";
            int lives = 0;

            Assert.AreEqual(expected, Gallow.ReturnStage(lives));
        }

        [TestMethod]
        public void ReturnStage_NegativeOutOfRange_Throws()
        {
            // arrange
            int lives = 10;

            // act and assert
            Assert.ThrowsException <System.Exception>(() => Gallow.ReturnStage(lives));
                //ThrowsException<System.ArgumentException>(() => Gallow.ReturnStage(lives));
        }

        [TestMethod]
        public void ReturnStage_OutOfRange_Throws()
        {
            // arrange
            int lives = -5;

            // act and assert
            Assert.ThrowsException<System.Exception>(() => Gallow.ReturnStage(lives));
        }
    }
}
