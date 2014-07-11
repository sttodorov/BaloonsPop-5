using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class ConsoleUI : IFrontEnd
    {
        /// <summary>
        /// Prompts the user for a text command and parses it.
        /// </summary>
        /// <returns>Command object with optional data, depending on the command's Type</returns>
        public Command UserCommand()
        {
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
                        return this.RenderUserCommand(userCommand);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Wrong input! Try Again! ");
                        Console.WriteLine();
                        return this.UserCommand();
                    }
            }

        }

        public void RenderGameFieldState(byte[,] fieldClone)
        {
            var fieldAsString = FieldToString.Draw(fieldClone);
            Console.WriteLine(fieldAsString);
        }

        public void PublishPrompt()
        {
            //currently we only have one prompt, if more are needed we will create a PromptType enum
            //set it as a parameter and have a switch-statement in here
            Console.WriteLine("Cannot pop missing baloon!");
            Console.WriteLine();
        }

        /// <summary>
        /// Informs the user that the game is over.
        /// Prompts the user to enter their name
        /// </summary>
        /// <param name="movesCount"></param>
        /// <returns>A RankListReccord with the user's name and movesCount</returns>
        public RankListRecord Win(int movesCount)
        {
            //current implementation creates a reccord for each finished game
            //originally only 5 reccords were kept and a reccord was created only when the new score would be in the top 5

            Console.WriteLine("Congratulations! You completed the game in {0} moves.", movesCount);
            string playerName = String.Empty;

            do
            {
                Console.Write("Enter your name(between 3 and 30 characters): ");
                playerName = Console.ReadLine();
            } while (playerName.Length < 3 || playerName.Length > 30);

            // TO PUT THIS IN A BETTER POSITION!
            // Console.WriteLine("\nNEW GAME!\n"); 
            
            var newReccord = new RankListRecord(movesCount, playerName);
            return newReccord;
        }

        public void PrintCongratulations(bool isInTopFive)
        {
            if (isInTopFive)
            {
                Console.WriteLine("You are skillful and made it to Top 5!");
            }
            else
            {
                Console.WriteLine("I am sorry you are not skillful enough for Top 5 chart!");
            }
        }

        public void PrintTopFive(List<RankListRecord> topFive)
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
                    Console.WriteLine(topFive[i].ToFormattedString());
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

            string[] rowAndCol = userCommand.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int commandRow;
            int commandCol;

            if (rowAndCol.Length <= 1 ||
                !int.TryParse(rowAndCol[0], out commandRow) ||
                !int.TryParse(rowAndCol[1], out commandCol))
            {
                throw new ArgumentException("Invalid command. Input must be numbers!");
            }

            bool isCommandRowCorrect = commandRow >= 0 && commandRow < GameConstants.FieldRows;
            bool isCommandColCorrect = commandCol >= 0 && commandCol < GameConstants.FieldCols;

            if ((userCommand.Length == 3) && isCommandRowCorrect && isCommandColCorrect)
            {
                int[] coordinates = { commandRow, commandCol };

                return new Command(CommandType.PopBalloonAt, coordinates);
            }
            else
            {
                throw new ArgumentException("This is not valid Input!");
            }
        }
    }
}
