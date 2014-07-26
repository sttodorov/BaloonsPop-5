namespace BaloonsPopGame.GameField
{
    using System;

    using BaloonsPopGame.Contracts;
    using BaloonsPopGame.Engine;

    public class GameFieldFacade : IFacade
    {
        private GameFieldOperations gameField;
        private IPoppingEngine popEngine;
        private byte[,] previousState;

        public GameFieldFacade(byte numberOfRows, byte numbreofCols)
        {
            this.gameField = new GameFieldOperations(numberOfRows, numbreofCols);
            this.popEngine = new PoppingLogic(this.GameFieldOperationsProp);
        }

        public GameFieldFacade(byte[,] initialField)
        {
            this.gameField = new GameFieldOperations(initialField);
            this.popEngine = new PoppingLogic(this.GameFieldOperationsProp);
        }

        public GameFieldOperations GameFieldOperationsProp
        {
            get
            {
                return this.gameField;
            }

            set
            {
                this.gameField = value;
            }
        }

        public IPoppingEngine PopEngine
        {
            get
            {
                return this.popEngine;
            }
        }

        public bool IsWin()
        {
            return this.GameFieldOperationsProp.IsFieldEmpty();   
        }

        public byte[,] GameFieldClone()
        {
            return this.GameFieldOperationsProp.Clone();
        }

        public void CreateNewField(byte numberOfRows, byte numbreofCols)
        {
            this.GameFieldOperationsProp = new GameFieldOperations(numberOfRows, numbreofCols);
        }

        public void PopAt(object data)
        {
            var tempState = this.GameFieldClone();

            this.PopEngine.PopAt(data);
            this.GameFieldOperationsProp.RemovePoppedBaloons();

            // only assigned if Popping goes through
            this.previousState = tempState;
        }

        public void Undo() 
        {
            if (this.previousState == null)
            {
                throw new InvalidOperationException("Cannot undo from this point. No previous state available.");
            }

            this.GameFieldOperationsProp = new GameFieldOperations(this.previousState);
            this.previousState = null;
        }
    }
}
