using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class GameFieldTests
    {
        private GameField actualField;
        private GameField expectedField;

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

        [TestInitialize]
        public void InitializeField()
        {
            actualField = new GameField(6, 6);
            expectedField = new GameField(actualField.Clone());

        }

        [TestMethod]
        public void CloneEqualTest()
        {
            bool areEqual = CompareFields();
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void CloneDifferentTest()
        {
            expectedField[4, 4] = 0;
            bool areEqual = CompareFields();
            Assert.IsFalse(areEqual);
        }
    }
}
