using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class GameFieldFacade
    {
        private GameFieldOperations gameField;
        private PoppingLogic popEngine;

        public GameFieldFacade(byte numberOfRows, byte numbreofCols)
        {
            this.gameField = new GameFieldOperations(numberOfRows, numbreofCols);
            this.popEngine = new PoppingLogic(this.GameFieldOperationsProp);
        }

        public GameFieldOperations GameFieldOperationsProp
        {
            get
            {
                return this.gameField;
            }
            private set
            {
                this.gameField = value;
            }
        }

        public PoppingLogic PopEngine
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
            this.GameFieldOperationsProp = new GameFieldOperations( numberOfRows, numbreofCols);
        }

        public void PopAt(object data)
        {
            this.PopEngine.PopAt(data);
            this.GameFieldOperationsProp.RemovePoppedBaloons();
        }
    }
}
