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
            for (int j = 0; j < columnsCount; j++)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    if (this.GameFieldProp[i, j] != 0)
                    {
                        isWinner = false;
                    }
                }
            }
            return isWinner;
        }

        public void RemovePopedBaloons()
        {
            Stack<byte> remainingBaloons = new Stack<byte>();
            int rowsCount = this.GameFieldProp.GetLength(0);
            int columnsCount = this.GameFieldProp.GetLength(1);
            for (int j = 0; j < columnsCount; j++)
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    if (this.GameFieldProp[i, j] != 0)
                    {
                        remainingBaloons.Push(this.GameFieldProp[i, j]);
                    }
                }
                for (int k = rowsCount - 1; k >= 0; k--)
                {
                    /*try
                    {
                        this[k, j] = remainingBaloons.Pop();
                    }
                    catch (Exception)
                    {
                        this.SetFieldCell(k, j, 0);
                    }*/
                    if (remainingBaloons.Count != 0)
                    {
                        this[k, j] = remainingBaloons.Pop();
                    }
                    else
                    {
                        this[k, j] = 0;
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
