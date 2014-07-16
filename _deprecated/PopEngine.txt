using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    /// <summary>
    /// All contents moved to GameField class.
    /// </summary>
    public static class PopEngine
    {
        //public static void PopAt(int commandRow, int commandCol, GameField field)
        //{
        //    if (field == null)
        //    {
        //        throw new ArgumentNullException("Field cannot be null when popping a baloon!");
        //    }

        //    if (commandRow < 0 || commandRow >= field.NumberOfRows)
        //    {
        //        throw new IndexOutOfRangeException("Command Row is outside field.");
        //    }

        //    if (commandCol < 0 || commandCol >= field.NumberOfColumns)
        //    {
        //        throw new IndexOutOfRangeException("Command Col is outside field.");
        //    }

        //    byte selectedBaloon = field[commandRow, commandCol];
        //    if (selectedBaloon != 0)
        //    {
        //        //Pop Baloon
        //        field[commandRow, commandCol] = 0;

        //        PopBaloons(commandRow, commandCol, selectedBaloon, field, PoppingDirection.Left);
        //        PopBaloons(commandRow, commandCol, selectedBaloon, field, PoppingDirection.Right);
        //        PopBaloons(commandRow, commandCol, selectedBaloon, field, PoppingDirection.Up);
        //        PopBaloons(commandRow, commandCol, selectedBaloon, field, PoppingDirection.Down);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Cannot pop missing baloon!");
        //    }
        //}

        //public static void PopBaloons(int chosenRow, int chosenColumn, byte searchedItem, GameField field, PoppingDirection direction)
        //{
        //    int rowDirection = 0;
        //    int colDirection = 0;

        //    switch (direction)
        //    {
        //        case PoppingDirection.Left: colDirection = -1; break;
        //        case PoppingDirection.Right: colDirection = 1; break;
        //        case PoppingDirection.Up: rowDirection = -1; break;
        //        case PoppingDirection.Down: rowDirection = 1; break;
        //        default: throw new ArgumentException("Invalid direction!");
        //    }

        //    int currentRow = chosenRow + rowDirection;
        //    int currentCol = chosenColumn + colDirection;

        //    while (0 <= currentRow && currentRow < field.NumberOfRows &&
        //        0 <= currentCol && currentCol < field.NumberOfColumns &&
        //        field[currentRow, currentCol] == searchedItem)
        //    {
        //        field[currentRow, currentCol] = 0;
        //        currentRow += rowDirection;
        //        currentCol += colDirection;
        //    }
        //}
    }
}
