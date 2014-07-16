/*
namespace BaloonsPopGame
{
    using System;

    static class StringExtensions
    {
        //public override string ToString()
        //{
        //    return string.Format("");
        //}

        public static bool isSkilled(this string[,] Chart, int points)
        {
            bool skilled = false;
            int worstMoves = 0;
            int worstMovesChartPosition = 0;
            for (int i = 0; i < 5; i++)
            { 
                if (Chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string tempUserName = Console.ReadLine();
                    Chart[i, 0] = points.ToString();
                    Chart[i, 1] = tempUserName;
                    skilled = true;
                    break;
                }
            }
            if (skilled == false) 
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(Chart[i, 0]) > worstMoves)
                    {
                        worstMovesChartPosition = i;
                        worstMoves = int.Parse(Chart[i, 0]);
                    }
                }
            }
            if (points < worstMoves && skilled == false) 
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                Chart[worstMovesChartPosition, 0] = points.ToString();
                Chart[worstMovesChartPosition, 1] = tempUserName;
                skilled = true;
            }
            return skilled;
        }
    }
}
*/