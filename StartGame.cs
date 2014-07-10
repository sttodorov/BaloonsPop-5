namespace BaloonsPopGame
{
    using System;
    using System.Linq;

    public class StartGame
    {
        public static void Main(string[] args)
        {
            IFrontEnd frontEnd = new ConsoleUI();
            var storageFilePath = @"..\..\ranklist.txt";
            var rankListStorage = new RankListStorage(storageFilePath);
            Engine.GetInstance(frontEnd, rankListStorage);
            Engine.GetInstance().Start();
            
            Console.WriteLine("WELCOME TO BALLOONS-POP VERSION 5.1!\n");
        }
    }
}
