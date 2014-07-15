using System;
using System.Collections.Generic;
using System.Linq;

namespace BaloonsPopGame
{
    public class GameFieldOperations : GameField
    {
        public GameFieldOperations(byte numberOfRows, byte numbreofCols)
            :base(numberOfRows, numbreofCols)
        {

        }
        public bool IsFieldEmpty()
        {
            bool isWinner = true;
            int rowsCount = this.NumberOfRows;
            int columnsCount = this.NumberOfColumns;
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    if (this[row, col] != 0)
                    {
                        isWinner = false;
                        break;
                    }
                }
            }

            return isWinner;
        }

        public void RemovePoppedBaloons()
        {
            Stack<byte> remainingBaloons = new Stack<byte>();
            int rowsCount = this.NumberOfRows;
            int columnsCount = this.NumberOfColumns;
            for (int col = 0; col < columnsCount; col++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    if (this[row, col] != 0)
                    {
                        remainingBaloons.Push(this[row, col]);
                    }
                }

                for (int row = rowsCount - 1; row >= 0; row--)
                {
                    if (remainingBaloons.Count != 0)
                    {
                        this[row, col] = remainingBaloons.Pop();
                    }
                    else
                    {
                        this[row, col] = 0;
                    }
                }
            }
        }

        public byte[,] Clone()
        {
            //shallow copy
            var clone = (byte[,])GameFieldProp.Clone();
            return clone;
        }

       
    }
}
