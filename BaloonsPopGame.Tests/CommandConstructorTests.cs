using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class CommandConstructorTests
    {
        [TestMethod]
        public void CommandExitIsCorrectType()
        {
            var testCommand = new Command(CommandType.Exit);
            var expectedType = CommandType.Exit;

            Assert.AreEqual(expectedType, testCommand.Type);
        }

        [TestMethod]
        public void CommandRestartIsCorrectType()
        {
            var testCommand = new Command(CommandType.Restart);
            var expectedType = CommandType.Restart;

            Assert.AreEqual(expectedType, testCommand.Type);
        }

        [TestMethod]
        public void CommandPassesCoordinateDataCorrectly()
        {

            var expectedCoord = new int[2] { 2, 7 };
            var testCommand = new Command(CommandType.PopBalloonAt, expectedCoord);
            var actualCoord = (int[])testCommand.Data;

            bool sameCoord = expectedCoord[0] == actualCoord[0] &&
                expectedCoord[0] == actualCoord[0];

            Assert.IsTrue(sameCoord);
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CommandCallingDataPropertyIfNotTypePopBalloonAt_throwsException()
        {
            var testCommand = new Command(CommandType.Restart);
            var data = testCommand.Data;
        }

    }
}
