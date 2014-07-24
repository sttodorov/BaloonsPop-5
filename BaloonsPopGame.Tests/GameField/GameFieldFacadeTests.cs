namespace BaloonsPopGame.GameField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameFieldFacadeTests
    {
        private GameFieldFacade facade;

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
        public void InitializeFacade()
        {
            facade = new GameFieldFacade(6, 6);
            actualField = facade.GameFieldOperationsProp;
            expectedField = new GameFieldOperations(facade.GameFieldClone());

            bool areEqual = CompareFields();
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void FacadeCloneEqualTest()
        {
            this.actualField = this.facade.GameFieldOperationsProp;
            this.expectedField = new GameFieldOperations(this.facade.GameFieldClone());

            bool areEqual = this.CompareFields();
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void FacadeCloneDifferentTest()
        {
            expectedField[4, 4] = 0;
            bool areEqual = CompareFields();
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void IsWinTest()
        {

            byte[,] matrix = { 
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            facade = new GameFieldFacade(matrix);
            bool isEmpty = facade.IsWin();

            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsNotWinTestTest()
        {
            byte[,] matrix = { 
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            facade = new GameFieldFacade(matrix);
            bool isEmpty = facade.IsWin();

            Assert.IsFalse(isEmpty);
        }


    }
}
