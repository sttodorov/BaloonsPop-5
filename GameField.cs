using System;
using System.Collections.Generic;
using System.Linq;

namespace BaloonsPopGame
{
    public class GameField
    {
        private byte[,] gameField;

        /// <summary>
        /// GameField constructor. This constructor depends on Random.
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <param name="numbreofCols"></param>
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
            // Validation in Prop.
            this.GameFieldProp = initialField;
        }

        private byte[,] GameFieldProp
        {
            get
            {
                return this.gameField;
            }
            set
            {
                // No validation!
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

        /// <summary>
        /// This method pop selected baloon and call poping method for equal baloons on the same row and col
        /// </summary>
        /// <param name="data">
        /// Selected row and col as object. Integer array
        /// </param>
        public void PopAt(object data)
        {
            int[] coordinates = data as int[];

            var commandRow = coordinates[0];
            var commandCol = coordinates[1];

            if (this == null)
            {
                throw new ArgumentNullException("Field cannot be null when popping a baloon!");
            }

            if (commandRow < 0 || commandRow >= this.NumberOfRows)
            {
                throw new IndexOutOfRangeException("Command Row is outside field.");
            }

            if (commandCol < 0 || commandCol >= this.NumberOfColumns)
            {
                throw new IndexOutOfRangeException("Command Col is outside field.");
            }

            byte selectedBaloon = this[commandRow, commandCol];
            if (selectedBaloon != 0)
            {
                //Pop Baloon
                this[commandRow, commandCol] = 0;

                PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Left);
                PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Right);
                PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Up);
                PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Down);
            }
            else
            {
                throw new InvalidOperationException("Cannot pop missing baloon!");
            }
        }

        /// <summary>
        /// Pop equal to selected baloon in single direction.
        /// </summary>
        /// <param name="chosenRow"></param>
        /// <param name="chosenColumn"></param>
        /// <param name="searchedItem">
        /// Selected baloon
        /// </param>
        /// <param name="direction"></param>
        private void PopBaloons(int chosenRow, int chosenColumn, byte searchedItem, PoppingDirection direction)
        {
            int rowDirection = 0;
            int colDirection = 0;

            switch (direction)
            {
                case PoppingDirection.Left: colDirection = -1; break;
                case PoppingDirection.Right: colDirection = 1; break;
                case PoppingDirection.Up: rowDirection = -1; break;
                case PoppingDirection.Down: rowDirection = 1; break;
                default: throw new ArgumentException("Invalid direction!");
            }

            int currentRow = chosenRow + rowDirection;
            int currentCol = chosenColumn + colDirection;

            while (0 <= currentRow && currentRow < this.NumberOfRows &&
                0 <= currentCol && currentCol < this.NumberOfColumns &&
                this[currentRow, currentCol] == searchedItem)
            {
                this[currentRow, currentCol] = 0;
                currentRow += rowDirection;
                currentCol += colDirection;
            }
        }
    }
}
