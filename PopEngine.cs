using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public static class PopEngine
    {
        public static void PopAt(int commandRow, int commandCol, GameField field)
        {
            throw new NotImplementedException();

            byte selectedBaloon = this.GameField.GetFieldCell(commandRow, commandCol);
            if (selectedBaloon != 0)
            {
                //Pop Baloon
                this.GameField.SetFieldCell(commandRow, commandCol, 0);

                this.PopBaloonsLeft(commandRow, commandCol, selectedBaloon);
                this.PopBaloonsRight(commandRow, commandCol, selectedBaloon);
                this.PopBaloonsUp(commandRow, commandCol, selectedBaloon);
                this.PopBaloonsDown(commandRow, commandCol, selectedBaloon);
            }
            else
            {
                throw new InvalidOperationException("Cannot pop missing baloon!");
            }
        }

        public static void PopBaloonsLeft(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn - 1;
            if (searchinInCol < 0)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsLeft(searchingInRow, searchinInCol, searchedItem);
            }
        }

        public static void PopBaloonsRight(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn + 1;
            if (searchinInCol >= this.GameField.NumberOfColumns)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsRight(searchingInRow, searchinInCol, searchedItem);
            }
        }

        public static void PopBaloonsUp(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow - 1;
            int searchinInCol = chosenColumn;
            if (searchingInRow < 0)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsUp(searchingInRow, searchinInCol, searchedItem);
            }
        }

        public static void PopBaloonsDown(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow + 1;
            int searchinInCol = chosenColumn;
            if (searchingInRow >= this.GameField.NumberOfRows)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsDown(searchingInRow, searchinInCol, searchedItem);
            }
        }

    }
}
