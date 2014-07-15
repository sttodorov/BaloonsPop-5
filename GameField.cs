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

        protected byte[,] GameFieldProp
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
    }
}
