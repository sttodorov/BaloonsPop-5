using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class PoppingLogic
    {
        private GameField field;
        public PoppingLogic(GameField gameField)
        {
            this.field = gameField;
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

            if (commandRow < 0 || commandRow >= this.field.NumberOfRows)
            {
                throw new IndexOutOfRangeException("Command Row is outside field.");
            }

            if (commandCol < 0 || commandCol >= this.field.NumberOfColumns)
            {
                throw new IndexOutOfRangeException("Command Col is outside field.");
            }

            byte selectedBaloon = this.field[commandRow, commandCol];
            if (selectedBaloon != 0)
            {
                //Pop Baloon
                this.field[commandRow, commandCol] = 0;

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

            while (0 <= currentRow && currentRow < this.field.NumberOfRows &&
                0 <= currentCol && currentCol < this.field.NumberOfColumns &&
                this.field[currentRow, currentCol] == searchedItem)
            {
                this.field[currentRow, currentCol] = 0;
                currentRow += rowDirection;
                currentCol += colDirection;
            }
        }
    }
}
