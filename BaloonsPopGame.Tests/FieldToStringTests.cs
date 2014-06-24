namespace BaloonsPopGame.Tests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FieldToStringTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrawNullMatrixTest()
        {
            string matrixString = FieldToString.Draw(null);
        }

        [TestMethod]
        public void DrawRegularMatrixTest()
        {
            byte[,] actualMatrix = 
            { 
                { 8, 5, 2, 2, 3, 4, 2, 3, 4, 5, 2 },
                { 1, 1, 2, 2, 4, 4, 4, 6, 4, 1, 2 },
                { 2, 1, 4, 1, 3, 4, 2, 3, 4, 1, 4 },
                { 2, 3, 7, 3, 3, 1, 2, 3, 1, 3, 7 },
                { 8, 1, 2, 2, 3, 9, 2, 3, 4, 1, 2 },
                { 8, 5, 2, 2, 3, 4, 2, 3, 4, 5, 2 },
                { 1, 1, 2, 2, 4, 4, 4, 6, 4, 1, 2 },
                { 2, 1, 4, 1, 3, 4, 2, 3, 4, 1, 4 },
                { 2, 3, 7, 3, 3, 1, 2, 3, 1, 3, 7 },
                { 8, 1, 2, 2, 3, 9, 2, 3, 4, 1, 2 }
            };
            string actualString = FieldToString.Draw(actualMatrix);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("    0 1 2 3 4 5 6 7 8 9 10 ");
            expected.AppendLine("   -----------------------");
            expected.AppendLine("0 | 8 5 2 2 3 4 2 3 4 5 2 |");
            expected.AppendLine("1 | 1 1 2 2 4 4 4 6 4 1 2 |");
            expected.AppendLine("2 | 2 1 4 1 3 4 2 3 4 1 4 |");
            expected.AppendLine("3 | 2 3 7 3 3 1 2 3 1 3 7 |");
            expected.AppendLine("4 | 8 1 2 2 3 9 2 3 4 1 2 |");
            expected.AppendLine("5 | 8 5 2 2 3 4 2 3 4 5 2 |");
            expected.AppendLine("6 | 1 1 2 2 4 4 4 6 4 1 2 |");
            expected.AppendLine("7 | 2 1 4 1 3 4 2 3 4 1 4 |");
            expected.AppendLine("8 | 2 3 7 3 3 1 2 3 1 3 7 |");
            expected.AppendLine("9 | 8 1 2 2 3 9 2 3 4 1 2 |");
            expected.AppendLine("   -----------------------");

            string expectedString = expected.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DrawHalfEmptyMatrixTest()
        {
            byte[,] actualMatrix = 
            { 
                { 0, 0, 0, 2, 3, 4, 2, 3, 4, 0 },
                { 1, 1, 2, 2, 4, 4, 4, 0, 4, 1 },
                { 2, 0, 4, 1, 3, 0, 2, 3, 4, 1 },
                { 2, 3, 0, 3, 3, 0, 2, 3, 1, 0 },
                { 0, 1, 2, 2, 3, 0, 2, 3, 4, 1 }
            };

            string actualString = FieldToString.Draw(actualMatrix);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("    0 1 2 3 4 5 6 7 8 9 ");
            expected.AppendLine("   ---------------------");
            expected.AppendLine("0 |       2 3 4 2 3 4   |");
            expected.AppendLine("1 | 1 1 2 2 4 4 4   4 1 |");
            expected.AppendLine("2 | 2   4 1 3   2 3 4 1 |");
            expected.AppendLine("3 | 2 3   3 3   2 3 1   |");
            expected.AppendLine("4 |   1 2 2 3   2 3 4 1 |");
            expected.AppendLine("   ---------------------");

            string expectedString = expected.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DrawEmptyMatrixTest()
        {
            byte[,] actualMatrix = 
            { 
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };

            string actualString = FieldToString.Draw(actualMatrix);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("    0 1 2 3 4 5 6 ");
            expected.AppendLine("   ---------------");
            expected.AppendLine("0 |               |");
            expected.AppendLine("1 |               |");
            expected.AppendLine("2 |               |");
            expected.AppendLine("3 |               |");
            expected.AppendLine("4 |               |");
            expected.AppendLine("5 |               |");
            expected.AppendLine("   ---------------");

            string expectedString = expected.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DrawOneRowMatrixTest()
        {
            byte[,] actualMatrix = 
            { 
                { 8, 5, 2, 2, 3, 4, 2, 3, 4, 5, 2 }
            };

            string actualString = FieldToString.Draw(actualMatrix);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("    0 1 2 3 4 5 6 7 8 9 10 ");
            expected.AppendLine("   -----------------------");
            expected.AppendLine("0 | 8 5 2 2 3 4 2 3 4 5 2 |");
            expected.AppendLine("   -----------------------");

            string expectedString = expected.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DrawOneColumnMatrixTest()
        {
            byte[,] actualMatrix = 
            { 
                { 8 },
                { 1 },
                { 2 },
                { 2 },
                { 8 },
                { 8 },
                { 2 },
                { 8 }
            };

            string actualString = FieldToString.Draw(actualMatrix);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("    0 ");
            expected.AppendLine("   ---");
            expected.AppendLine("0 | 8 |");
            expected.AppendLine("1 | 1 |");
            expected.AppendLine("2 | 2 |");
            expected.AppendLine("3 | 2 |");
            expected.AppendLine("4 | 8 |");
            expected.AppendLine("5 | 8 |");
            expected.AppendLine("6 | 2 |");
            expected.AppendLine("7 | 8 |");
            expected.AppendLine("   ---");

            string expectedString = expected.ToString();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
