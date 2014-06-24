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
            byte selectedBaloon = field.GetFieldCell(commandRow, commandCol);
            if (selectedBaloon != 0)
            {
                //Pop Baloon
                field.SetFieldCell(commandRow, commandCol, 0);

                PopBaloonsLeft(commandRow, commandCol, selectedBaloon, field);
                PopBaloonsRight(commandRow, commandCol, selectedBaloon, field);
                PopBaloonsUp(commandRow, commandCol, selectedBaloon, field);
                PopBaloonsDown(commandRow, commandCol, selectedBaloon, field);
            }
            else
            {
                throw new InvalidOperationException("Cannot pop missing baloon!");
            }
        }

        public static void PopBaloonsLeft(int chosenRow, int chosenColumn, byte searchedItem, GameField field)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn - 1;
            if (searchinInCol < 0)
            {
                return;
            }

            if (field.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                field.SetFieldCell(searchingInRow, searchinInCol, 0);
                PopBaloonsLeft(searchingInRow, searchinInCol, searchedItem, field);
            }
        }

        public static void PopBaloonsRight(int chosenRow, int chosenColumn, byte searchedItem, GameField field)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn + 1;
            if (searchinInCol >= field.NumberOfColumns)
            {
                return;
            }

            if (field.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                field.SetFieldCell(searchingInRow, searchinInCol, 0);
                PopBaloonsRight(searchingInRow, searchinInCol, searchedItem, field);
            }
        }

        public static void PopBaloonsUp(int chosenRow, int chosenColumn, byte searchedItem, GameField field)
        {
            int searchingInRow = chosenRow - 1;
            int searchinInCol = chosenColumn;
            if (searchingInRow < 0)
            {
                return;
            }

            if (field.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                field.SetFieldCell(searchingInRow, searchinInCol, 0);
                PopBaloonsUp(searchingInRow, searchinInCol, searchedItem, field);
            }
        }

        public static void PopBaloonsDown(int chosenRow, int chosenColumn, byte searchedItem, GameField field)
        {
            int searchingInRow = chosenRow + 1;
            int searchinInCol = chosenColumn;
            if (searchingInRow >= field.NumberOfRows)
            {
                return;
            }

            if (field.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                field.SetFieldCell(searchingInRow, searchinInCol, 0);
                PopBaloonsDown(searchingInRow, searchinInCol, searchedItem, field);
            }
        }
    }
}
