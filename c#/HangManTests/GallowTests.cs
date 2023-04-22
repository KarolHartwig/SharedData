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


            int lifes = 6;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
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
            int lifes = 5;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
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
            int lifes = 4;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
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
            int lifes = 3;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
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
            int lifes = 2;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
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
            int lifes = 1;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
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
            int lifes = 0;

            Assert.AreEqual(expected, Gallow.ReturnStage(lifes));
        }

        [TestMethod]
        public void ReturnStage_NegativeOutOfRange_Throws()
        {
            // arrange
            int lifes = 10;

            // act and assert
            Assert.ThrowsException <System.Exception>(() => Gallow.ReturnStage(lifes));
                //ThrowsException<System.ArgumentException>(() => Gallow.ReturnStage(lifes));
        }

        [TestMethod]
        public void ReturnStage_OutOfRange_Throws()
        {
            // arrange
            int lifes = -5;

            // act and assert
            Assert.ThrowsException<System.Exception>(() => Gallow.ReturnStage(lifes));
        }
    }
}