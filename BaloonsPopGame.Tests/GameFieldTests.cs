using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class GameFieldTests
    {
        private GameFieldOperations actualField;
        private GameFieldOperations expectedField;

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

            GameFieldFacade facade1 = new GameFieldFacade(6, 6);

            actualField = facade1.GameFieldOperationsProp;
            expectedField = new GameFieldOperations(facade1.GameFieldClone());
            bool areEqual = CompareFields();
            Assert.IsTrue(areEqual);
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

        [TestMethod]
        public void IsFieldEmptyEmptyFieldTest()
        {

            byte[,] matrix = { 
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            actualField = new GameFieldOperations(matrix);
            bool isEmpty = actualField.IsFieldEmpty();

            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsFieldEmptyNonEmptyFieldTest()
        {
            byte[,] matrix = { 
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            actualField = new GameFieldOperations(matrix);
            bool isEmpty = actualField.IsFieldEmpty();

            Assert.IsFalse(isEmpty);
        }
    }
}
