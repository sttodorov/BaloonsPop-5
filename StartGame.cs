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
            var engine = new Engine(frontEnd, rankListStorage);

            
            Console.WriteLine("WELCOME TO BALLOONS-POP VERSION 5.0!\n");

            engine.Start();
        }
    }
}
