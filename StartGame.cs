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

            //for test only, delete when RenderingClass is created
            Console.WriteLine("NEW GAME!\n");

            engine.Start();
        }
    }
}
