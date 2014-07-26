namespace BaloonsPopGame.Engine
{
    using System;

    using BaloonsPopGame.Contracts;
    using BaloonsPopGame.GameField;

    public class PoppingLogic : IPoppingEngine
    {
        private GameField field;

        public PoppingLogic(GameField gameField)
        {
            this.Field = gameField;
        }

        public GameField Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
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

            if (commandRow < 0 || commandRow >= this.Field.NumberOfRows)
            {
                throw new IndexOutOfRangeException("Command Row is outside field.");
            }

            if (commandCol < 0 || commandCol >= this.Field.NumberOfColumns)
            {
                throw new IndexOutOfRangeException("Command Col is outside field.");
            }

            byte selectedBaloon = this.Field[commandRow, commandCol];
            if (selectedBaloon != 0)
            {
                // Pop Baloon
                this.Field[commandRow, commandCol] = 0;

                this.PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Right);
                this.PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Up);
                this.PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Down);
                this.PopBaloons(commandRow, commandCol, selectedBaloon, PoppingDirection.Left);
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
                case PoppingDirection.Left: 
                    colDirection = -1; 
                    break;
                case PoppingDirection.Right: 
                    colDirection = 1; 
                    break;
                case PoppingDirection.Up: 
                    rowDirection = -1; 
                    break;
                case PoppingDirection.Down: 
                    rowDirection = 1; 
                    break;
                default: 
                    throw new ArgumentException("Invalid direction!");
            }

            int currentRow = chosenRow + rowDirection;
            int currentCol = chosenColumn + colDirection;

            while (0 <= currentRow && currentRow < this.Field.NumberOfRows &&
                0 <= currentCol && currentCol < this.Field.NumberOfColumns &&
                this.Field[currentRow, currentCol] == searchedItem)
            {
                this.Field[currentRow, currentCol] = 0;
                currentRow += rowDirection;
                currentCol += colDirection;
            }
        }
    }
}
