namespace BaloonsPopGame
{
    using System;
    using System.Linq;

    public class StartGame
    {
        public static void Main(string[] args)
        {
            Engine startGame = new Engine();

            //for test only, delete when RenderingClass is created
            Console.WriteLine("NEW GAME!\n");

            startGame.Start();
        }
    }
}
