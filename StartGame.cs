namespace BaloonsPopGame
{
    using System;
    using BaloonsPopGame.Contracts;
    using BaloonsPopGame.RankList;
    using BaloonsPopGame.UI;

    public class StartGame
    {
        public static void Main(string[] args)
        {
            IFrontEnd frontEnd = new ConsoleUIWithColors();
            var storageFilePath = @"..\..\ranklist.txt";
            var rankListStorage = new RankListStorage(storageFilePath);
            Engine.Engine.GetInstance(frontEnd, rankListStorage);
            Engine.Engine.GetInstance().Start();   
        }
    }
}
