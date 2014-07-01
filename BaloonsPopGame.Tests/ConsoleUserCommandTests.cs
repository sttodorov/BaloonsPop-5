using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class ConsoleUserCommandTest
    {
        [TestMethod]
        public void UserCommandRecievesRestartInput()
        {
            var frontEnd = new ConsoleUI();
            Command actualCommand = null;
            string input = "restArt";
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                actualCommand = frontEnd.UserCommand();
            }

            // Recover the standard output stream?

            Assert.AreEqual(CommandType.Restart, actualCommand.Type);
        }

        [TestMethod]
        public void UserCommandRecievesExitInput()
        {
            var frontEnd = new ConsoleUI();
            Command actualCommand = null;
            string input = "exit";
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                actualCommand = frontEnd.UserCommand();
            }

            // Recover the standard output stream?

            Assert.AreEqual(CommandType.Exit, actualCommand.Type);
        }

        [TestMethod]
        public void UserCommandRecievesTopInput()
        {
            var frontEnd = new ConsoleUI();
            Command actualCommand = null;
            string input = "Top";
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                actualCommand = frontEnd.UserCommand();
            }

            // Recover the standard output stream?

            Assert.AreEqual(CommandType.TopFive, actualCommand.Type);
        }

        [TestMethod]
        public void UserCommandRecievesValidCoordInput()
        {
            var frontEnd = new ConsoleUI();
            Command actualCommand = null;
            string input = "1 3";
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                actualCommand = frontEnd.UserCommand();
            }

            // Recover the standard output stream?
            bool typeCheck = (CommandType.PopBalloonAt == actualCommand.Type);
            var coords = (int[])actualCommand.Data;
            bool coordCheck = (coords[0] == 1) && (coords[1] == 3);

            Assert.IsTrue(typeCheck && coordCheck);
        }

        [TestMethod]
        public void UserCommandRecievesOutOfBoundsCoordInput()
        {
            var frontEnd = new ConsoleUI();
            Command actualCommand = null;
            string input = "9 9"+ Environment.NewLine +"1 3";
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                actualCommand = frontEnd.UserCommand();
            }

            // Recover the standard output stream?

            bool typeCheck = (CommandType.PopBalloonAt == actualCommand.Type);
            var coords = (int[])actualCommand.Data;
            bool coordCheck = (coords[0] == 1) && (coords[1] == 3);

            Assert.IsTrue(typeCheck && coordCheck);
        }

        [TestMethod]
        public void UserCommandRecievesInvalidCoordInput()
        {
            var frontEnd = new ConsoleUI();
            Command actualCommand = null;
            string input = "11_badinput" + Environment.NewLine + "1 3";
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                actualCommand = frontEnd.UserCommand();
            }

            // Recover the standard output stream?

            bool typeCheck = (CommandType.PopBalloonAt == actualCommand.Type);
            var coords = (int[])actualCommand.Data;
            bool coordCheck = (coords[0] == 1) && (coords[1] == 3);

            Assert.IsTrue(typeCheck && coordCheck);
        }
    }
}
