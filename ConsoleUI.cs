using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class ConsoleUI : IFrontEnd
    {
        public Command UserCommand()
        {
            throw new NotImplementedException();

            string userCommand = String.Empty;
            
            Console.WriteLine("Enter a row and column: ");
            userCommand = Console.ReadLine();
            userCommand = userCommand.ToUpper().Trim();

            switch (userCommand)
            {
                case "RESTART":
                    Console.WriteLine("\nNEW GAME!\n");
                    return new Command(CommandType.Restart);
                case "TOP":
                    return new Command(CommandType.TopFive);
                case "EXIT":
                    //Console.WriteLine("Your moves are: {0}", movesCount); //how do we request this from the Engine
                    Console.WriteLine("Good Bye! ");
                    return new Command(CommandType.Exit);
                default:
                    try
                    {
                        this.RenderUserCommand(userCommand);
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Cannot pop missing baloon!");
                        Console.WriteLine();
                        break;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Wrong input! Try Again! ");
                        Console.WriteLine();
                        break;
                    }

                    if (this.GameField.IsFieldEmpty())
                    {
                        this.Win(movesCount);
                        Console.WriteLine("\nNEW GAME!\n");
                        movesCount = 0;
                    }
                    else
                    {
                        this.GameField.RemovePopedBaloons();
                    }

                    movesCount++;
                    break;
            }
            
        }

        public void RenderGameFieldState()
        {
            throw new NotImplementedException();
        }

        public void PublishPrompt()
        {
            throw new NotImplementedException();
        }

        public void PrintTopFive(List<RankListReccord> topFive)
        {
            if (topFive.Count == 0)
            {
                Console.WriteLine("Top Five Chart is Empty");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\n---------TOP FIVE CHART-----------\n");
                for (int i = 0; i < topFive.Count; i++)
                {
                    Console.Write(i + 1);
                    topFive[i].PrintReccord();
                }

                Console.WriteLine("\n----------------------------------\n");
            }

        }

        public Command RenderUserCommand(string userCommand)
        {
            if (String.IsNullOrWhiteSpace(userCommand))
            {
                throw new ArgumentNullException("Invalid command. Command cannot be empty.");
            }

            int commandRow = 0;
            int commandCol = 0;
            char separator = ' ';

            bool isCommandRowCorrect;
            bool isCommandColCorrect;
            bool isSeparatorCorrect;

            commandRow = int.Parse(userCommand[0].ToString());
            separator = userCommand[1];
            commandCol = int.Parse(userCommand[2].ToString());

            isCommandRowCorrect = commandRow >= 0 && commandRow <= GameConstants.FieldRows;
            isCommandColCorrect = commandCol >= 0 && commandCol <= GameConstants.FieldCols;
            isSeparatorCorrect = separator == ' ' || separator == '.' || separator == ',';

            if ((userCommand.Length == 3) && isCommandRowCorrect && isCommandColCorrect && isSeparatorCorrect)
            {
                if (commandRow >= GameConstants.FieldRows || commandCol >= GameConstants.FieldCols)
                {
                    throw new ArgumentException("This is not valid Input!");
                }

                int[] coordinates = {commandRow, commandCol};

                return new Command(CommandType.PopBalloonAt, coordinates);
            }
            else
            {
                throw new ArgumentException("This is not valid Input!");
            }
        }

        public void Draw(byte[,] fieldClone)
        {
            Console.Write("    ");
            //Print Column numbers
            for (byte column = 0; column < fieldClone.GetLongLength(1); column++)
            {
                Console.Write("{0} ", column);
            }

            Console.Write("\n   ");
            //Print dashes between baloons and indexes
            for (byte column = 0; column < fieldClone.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < fieldClone.GetLongLength(0); i++)
            {
                //Print number of Row
                Console.Write(i + " | ");
                for (byte j = 0; j < fieldClone.GetLongLength(1); j++)
                {
                    if (fieldClone[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(fieldClone[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");
            for (byte column = 0; column < fieldClone.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
    }
}
