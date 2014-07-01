namespace BaloonsPopGame.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PopEngineTests
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
                { 1, 1, 2, 2, 4, 4, 4, 6, 4, 1, 2 },
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

        [TestMethod]
        public void PopAtOneBaloonTest()
        {
            PopEngine.PopAt(2, 2, actualField);
            expectedField[2, 2] = 0;
            bool areEqual = CompareFields();

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PopAtOneWholeRowtest()
        {
            PopEngine.PopAt();

        }
    }
}
