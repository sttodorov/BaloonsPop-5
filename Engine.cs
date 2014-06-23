namespace BaloonsPopGame
{
using System;
using System.Collections.Generic;
using System.Linq;

    public class Engine
    {
        private List<RankListReccord> topPlayers; //change to private RankListStorage rankList;
        private GameField gameField;

        public Engine()
        {
            this.GameField = new GameField(5, 10);
            this.TopPlayers = new List<RankListReccord>(); // initialize rankList with @"..\..\ranklist.txt"
        }

        public List<RankListReccord> TopPlayers
        {
            get
            {
                return this.topPlayers;
            }

            set
            {
                this.topPlayers = value;
            }
        }

        public GameField GameField
        {
            get
            {
                return this.gameField;
            }

            set
            {
                this.gameField = value;
            }
        }

        public void Start()
        {
            string userCommand = String.Empty;
            int movesCount = 0;
            while (userCommand != "EXIT")
            {
                this.GameField.Draw();

                Console.WriteLine("Enter a row and column: ");
                userCommand = Console.ReadLine();
                userCommand = userCommand.ToUpper().Trim();

                switch (userCommand)
                {
                    case "RESTART":
                        Console.WriteLine("\nNEW GAME!\n");
                        this.GameField = new GameField(5, 10);
                        movesCount = 0;
                        break;

                    case "TOP":
                        this.TopPlayers.Sort();
                        if (this.TopPlayers.Count == 0)
                        {
                            Console.WriteLine("Top Five Chart is Empty");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("\n---------TOP FIVE CHART-----------\n");
                            for (int i = 0; i < this.TopPlayers.Count; i++)
                            {
                                Console.Write(i + 1);
                                this.TopPlayers[i].PrintReccord();
                            }

                            Console.WriteLine("\n----------------------------------\n");
                        }

                        break;
                    case "EXIT":
                        Console.WriteLine("Your moves are: {0}", movesCount);
                        Console.WriteLine("Good Bye! ");
                        break;
                    default:
                        try
                        {
                            this.RenderUserCommand(userCommand);
                        }
                        catch(InvalidOperationException)
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
        }

        public void RenderUserCommand(string userCommand)
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

            isCommandRowCorrect = commandRow >= 0 && commandRow <= this.GameField.NumberOfRows;
            isCommandColCorrect = commandCol >= 0 && commandCol <= this.GameField.NumberOfColumns;
            isSeparatorCorrect = separator == ' ' || separator == '.' || separator == ',';

            if ((userCommand.Length == 3) && isCommandRowCorrect && isCommandColCorrect && isSeparatorCorrect)
            {   
                if (commandRow >= this.GameField.NumberOfRows || commandCol >= this.GameField.NumberOfColumns)
                {
                    throw new ArgumentException("This is not valid Input!");
                }

                this.PopEngine(commandRow, commandCol);
            }
            else
            {
                throw new ArgumentException("This is not valid Input!");
            }
        }

        public void PopEngine(int commandRow, int commandCol)
        {
            byte selectedBaloon = this.GameField.GetFieldCell(commandRow, commandCol);
            if (selectedBaloon != 0)
            {
                //Pop Baloon
                this.GameField.SetFieldCell(commandRow, commandCol, 0);

                this.PopBaloonsLeft(commandRow, commandCol, selectedBaloon);
                this.PopBaloonsRight(commandRow, commandCol, selectedBaloon);
                this.PopBaloonsUp(commandRow, commandCol, selectedBaloon);
                this.PopBaloonsDown(commandRow, commandCol, selectedBaloon);
            }
            else
            {
                throw new InvalidOperationException("Cannot pop missing baloon!");
            }
        }

        public void PopBaloonsLeft(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn - 1;
            if (searchinInCol < 0)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsLeft(searchingInRow, searchinInCol, searchedItem);
            }
        }

        public void PopBaloonsRight(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn + 1;
            if (searchinInCol >= this.GameField.NumberOfColumns)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsRight(searchingInRow, searchinInCol, searchedItem);
            }
            }

        public void PopBaloonsUp(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow - 1;
            int searchinInCol = chosenColumn;
            if (searchingInRow < 0)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsUp(searchingInRow, searchinInCol, searchedItem);
            }
        }

        public void PopBaloonsDown(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow + 1;
            int searchinInCol = chosenColumn;
            if (searchingInRow >= this.GameField.NumberOfRows)
            {
                return;
            }

            if (this.GameField.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                this.PopBaloonsDown(searchingInRow, searchinInCol, searchedItem);
            }
        }

        public void Win(int movesCount)
        {
            Console.WriteLine("Congratulations! You completed the game in {0} moves.", movesCount);
            int playersCount = this.TopPlayers.Count;
            this.TopPlayers.Sort();
            string playerName = String.Empty;
            if (playersCount < 5 || (playersCount >= 5 && movesCount < this.TopPlayers[4].Value))
            {
                Console.WriteLine("You are skillful!");
                Console.Write("Enter your name: ");
                playerName = Console.ReadLine();
                RankListReccord playerRecord = new RankListReccord(movesCount, playerName);
                this.TopPlayers.Add(playerRecord);
            }
            else
            {
                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
            }

            this.GameField = new GameField(5, 10);
        }
    }
}