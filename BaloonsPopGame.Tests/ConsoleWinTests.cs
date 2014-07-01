using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class ConsoleWinTests
    {
        [TestMethod]
        public void WinResturnsValidReccord()
        {
            var frontEnd = new ConsoleUI();
            var moves = 10;
            string input = "myName is UnitTest";
            RankListRecord reccord = null;
            var reader = new StringReader(input);
            using (reader)
            {
                Console.SetIn(reader);
                reccord = frontEnd.Win(moves);
            }

            bool movesCorrect = (moves == reccord.Value);
            bool nameCorrect = (input == reccord.Name);

            Assert.IsTrue(movesCorrect && nameCorrect);
        }

        [TestMethod]
        [Timeout(1000)]
        public void WinOutputsValidMessages()
        {
            var frontEnd = new ConsoleUI();
            var moves = 10;
            var output = new StringBuilder();
            string nameInput = "myName is UnitTest also";
            RankListRecord reccord = null;

            var writer = new StringWriter(output);
            using (writer)
            {
                Console.SetOut(writer);

                var nameReader = new StringReader(nameInput);
                using (nameReader)
                {
                    Console.SetIn(nameReader);
                    reccord = frontEnd.Win(moves);
                }
            }

            var outputAsString = output.ToString();
            string actualFirstLine = null;

            var reader = new StringReader(outputAsString);
            using (reader)
            {
                actualFirstLine = reader.ReadLine();
            }

            var expectedFirstLine = "Congratulations! You completed the game in 10 moves.";

            Assert.AreEqual(expectedFirstLine, actualFirstLine);
        }
    }
}
