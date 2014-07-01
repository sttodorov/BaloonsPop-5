using System;
using System.Collections.Generic;
using System.Linq;

namespace BaloonsPopGame
{
    public class GameField
    {
        private byte[,] gameField;

        public GameField(byte numberOfRows, byte numbreofCols)
        {
            Random randomGeneretor = new Random();
            byte currentRandomByteNumber;
            byte[,] buildedField = new byte[numberOfRows, numbreofCols];
            for (int i = 0; i < buildedField.GetLength(0); i++)
            {
                for (int j = 0; j < buildedField.GetLength(1); j++)
                {
                    currentRandomByteNumber = (byte)randomGeneretor.Next(1, 5);
                    buildedField[i, j] = currentRandomByteNumber;
                }
            }
            this.GameFieldProp = buildedField;
        }

        /// <summary>
        /// This constructor will be deleted later!
        /// For test purposes only!
        /// </summary>
        public GameField(byte[,] initialField)
        {
            // No validation!
            this.GameFieldProp = initialField;
        }

        public byte[,] GameFieldProp
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

        public int NumberOfRows
        {
            get
            {
                return this.GameFieldProp.GetLength(0);
            }
        }
        public int NumberOfColumns
        {
            get
            {
                return this.GameFieldProp.GetLength(1);
            }
        }

        public byte this[int row, int col]
        {
            get
            {
                return this.gameField[row, col];
            }
            set
            {
                this.gameField[row, col] = value;
            }
        }

        public bool IsFieldEmpty()
        {
            bool isWinner = true;
            int rowsCount = this.GameFieldProp.GetLength(0);
            int columnsCount = this.GameFieldProp.GetLength(1);
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    if (this.GameFieldProp[row, col] != 0)
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
            int rowsCount = this.GameFieldProp.GetLength(0);
            int columnsCount = this.GameFieldProp.GetLength(1);
            for (int col = 0; col < columnsCount; col++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    if (this.GameFieldProp[row, col] != 0)
                    {
                        remainingBaloons.Push(this.GameFieldProp[row, col]);
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
            var clone = (byte[,])GameFieldProp.Clone();
            return clone;
        }
    }
}
