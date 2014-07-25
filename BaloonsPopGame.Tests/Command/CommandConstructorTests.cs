namespace BaloonsPopGame.Engine.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void CommandCallingDataPropertyIfNotTypePopBalloonAtThrowsException()
        {
            var testCommand = new Command(CommandType.Restart);
            var data = testCommand.Data;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandPopBaloonAtWithNullCoordinates()
        {
            var testCommand = new Command(CommandType.PopBalloonAt, null);
        }
    }
}
