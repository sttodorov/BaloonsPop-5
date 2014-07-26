namespace BaloonsPopGame.Contracts
{
    using System;
    using System.Linq;

    public interface IFacade
    {
        bool IsWin();

        byte[,] GameFieldClone();

        void CreateNewField(byte numberOfRows, byte numbreofCols);

        void PopAt(object data);

        void Undo();
    }
}
