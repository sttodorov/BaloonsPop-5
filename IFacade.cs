namespace BaloonsPopGame
{
    using System;
    using System.Linq;

    interface IFacade
    {
        bool IsWin();

        byte[,] GameFieldClone();

        void CreateNewField(byte numberOfRows, byte numbreofCols);

        void PopAt(object data);
    }
}
