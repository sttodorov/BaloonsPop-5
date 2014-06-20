﻿namespace BaloonsPopGame
{
    using System;

    class StartGame
    {
        static void Main(string[] args)
        {
            BaloonsPop game = new BaloonsPop();
            string[,] bestPlayers = new string[5, 2];
            byte[,] gameField = game.GenerateField(GameConstants.fieldRows, GameConstants.fieldCols);
            Console.WriteLine("NEW GAME!\n");
            game.DrawGameField(gameField);

            string userCommand = String.Empty;
            int movesCount = 0;
            int commandRow = 0;
            int commandCol = 0;
            char separator = ' ';
            bool isCommandRowCorrect;
            bool isCommandColCorrect;
            bool isSeparatorCorrect;

            while (userCommand != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userCommand = Console.ReadLine();
                userCommand = userCommand.ToUpper().Trim();

                switch (userCommand)
                {
                    case "RESTART":
                        Console.WriteLine("\nNEW GAME!\n");
                        gameField = game.GenerateField(GameConstants.fieldRows, GameConstants.fieldRows);
                        game.DrawGameField(gameField);
                        movesCount = 0;
                        break;

                    case "TOP":
                        game.PrintRankList(bestPlayers);
                        break;

                    case "EXIT":
                        break;

                    default:
                        commandRow = userCommand[0];
                        separator = userCommand[1];
                        commandCol = userCommand[2];
                        isCommandRowCorrect = commandRow >= '0' && commandRow <= '9';
                        isCommandColCorrect = commandCol >= '0' && commandCol <= '9';
                        isSeparatorCorrect = separator == ' ' || separator == '.' || separator == ',';

                        if ((userCommand.Length == 3) && isCommandRowCorrect && isCommandColCorrect && isSeparatorCorrect)
                        {
                            commandRow = int.Parse(userCommand[0].ToString());
                            separator = userCommand[1];
                            commandCol = int.Parse(userCommand[2].ToString());
                            if (commandRow > 4)
                            {
                                Console.WriteLine("Wrong input! Try Again! ");
                                continue;
                            }

                            if (game.PopBaloon(gameField, commandRow, commandCol))
                            {
                                Console.WriteLine("Cannot pop missing ballon!");
                                continue;
                            }
                            movesCount++;
                            if (game.IsGameOver(gameField))
                            {
                                Console.WriteLine("Congratulations! You completed the game in {0} moves.", movesCount);
                                if (bestPlayers.isSkilled(movesCount))
                                {
                                    game.PrintRankList(bestPlayers);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                gameField = game.GenerateField(5, 10);
                                movesCount = 0;
                            }

                            Console.WriteLine();
                            game.DrawGameField(gameField);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try Again!");
                            break;
                        }


                }
            }
            Console.WriteLine("Good Bye! ");

        }
    }
}
