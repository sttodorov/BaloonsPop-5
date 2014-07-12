namespace BaloonsPopGame.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFieldPopAtTests
    {
        private GameField actualField;
        private GameField expectedField;

        [TestInitialize]
        public void InitializeField()
        {
            byte[,] matrix = { 
                { 8, 5, 2, 2, 3, 4, 2, 3, 4, 5, 2 },
                { 2, 1, 4, 1, 3, 4, 2, 3, 4, 1, 4 },
                { 2, 3, 7, 3, 3, 4, 2, 3, 1, 3, 7 },
                { 8, 1, 2, 2, 3, 4, 2, 3, 4, 1, 2 },
                { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
                { 8, 5, 2, 2, 3, 4, 2, 3, 4, 5, 2 },
                { 1, 1, 2, 2, 4, 4, 4, 6, 4, 1, 3 },
                { 2, 1, 4, 1, 3, 4, 2, 3, 4, 1, 2 },
                { 2, 3, 7, 3, 3, 4, 2, 3, 1, 3, 2 },
                { 8, 1, 2, 2, 3, 4, 2, 3, 4, 2, 2 }
            };

            actualField = new GameField(matrix);
            expectedField = new GameField((byte[,])matrix.Clone());
        }

        private bool CompareFields()
        {
            for (int row = 0; row < actualField.NumberOfRows; row++)
            {
                for (int col = 0; col < actualField.NumberOfColumns; col++)
                {
                    if (actualField[row, col] != expectedField[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Not works when moved to GameField. Because you cannot call method PopAt of null.
        /// Can be deleted later.
        /// </summary>
        [Ignore]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PopAtNullFieldTest()
        {
            actualField = new GameField(null);
            actualField.PopAt(new int[2]{3,4});
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PopAtInvalidPositionTest()
        {
            actualField.PopAt(new int[2]{10, 10});
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopAtEmptyCell()
        {
            actualField[4, 6] = 0;
            actualField.PopAt(new int[2]{4, 6});
        }

        [TestMethod]
        public void PopAtOneBaloonTest()
        {
            actualField.PopAt(new int[2]{2, 2});
            expectedField[2, 2] = 0;
            bool areEqual = CompareFields();

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PopAtWholeRowTest()
        {
            actualField.PopAt(new int[2]{4, 0});
            for (int col = 0; col < actualField.NumberOfColumns; col++)
            {
                expectedField[4, col] = 0;
            }
            bool areEqual = CompareFields();

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PopAtWholeColTest()
        {
            actualField.PopAt(new int[2]{9, 5});
            for (int row = 0; row < actualField.NumberOfRows; row++)
            {
                expectedField[row, 5] = 0;
            }
            bool areEqual = CompareFields();

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PopAtWholeRowAndColTest()
        {
            actualField.PopAt(new int[2]{4,5});
            for (int col = 0; col < actualField.NumberOfColumns; col++)
            {
                expectedField[4, col] = 0;
            }

            for (int row = 0; row < actualField.NumberOfRows; row++)
            {
                expectedField[row, 5] = 0;
            }
            bool areEqual = CompareFields();

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PopAtCornerTest()
        {
            actualField.PopAt(new int[2]{9, 10});
            expectedField[9, 9] = 0;
            expectedField[9, 10] = 0;
            expectedField[8, 10] = 0;
            expectedField[7, 10] = 0;

            bool areEqual = CompareFields();

            Assert.IsTrue(areEqual);
        }
    }
}
