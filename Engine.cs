using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    class Engine
    {
        //private string userCommand;
        private List<RankListReccord> topPlayers;
        private GameField gameField1;
        //private int movesCount;

        /*public string UserCommand
        {
            get
            {
                return this.userCommand;
            }
            set
            {
                this.userCommand=value;
            }
        }*/

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

        public GameField GameField1
        {
            get
            {
                return this.gameField1;
            }
            set
            {
                this.gameField1 = value;
            }
        }

        public Engine()
        {
            GameField1 = new GameField(5, 10);
            this.TopPlayers = new List<RankListReccord>();
        }

        public void Start()
        {
            string userCommand = String.Empty;
            while (userCommand != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userCommand = Console.ReadLine();
                userCommand = userCommand.ToUpper().Trim();

                switch (userCommand)
                {
                    case "RESTART":
                        Console.WriteLine("\nNEW GAME!\n");

                        this.GameField1.Draw();
                        //movesCount = 0;
                        break;

                    case "TOP":
                        TopPlayers.Sort();
                        foreach (var player in TopPlayers)
                        {
                            //TODO: PRint indexes of players
                            player.PrintReccord();
                        }
                        break;

                    case "EXIT":
                        break;

                    default:
                        RenderUserCommand(userCommand);
                        break;


                }
            }
            Console.WriteLine("Good Bye! ");


        }

        public void RenderUserCommand(string userCommand)
        {
            int movesCount = 0;
            int commandRow = 0;
            int commandCol = 0;
            char separator = ' ';
            bool isCommandRowCorrect;
            bool isCommandColCorrect;
            bool isSeparatorCorrect;
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
                    //continue;
                    return;
                }
                byte selectedBaloon = this.GameField1.GetFieldCell(commandRow, commandCol);
                if (selectedBaloon != 0)
                {
                    //Pop Baloon
                    this.GameField1.SetFieldCell(commandRow, commandCol, 0);

                    this.PopBaloonsLeft(commandRow, commandRow, selectedBaloon);
                    this.PopBaloonsRight(commandRow, commandRow, selectedBaloon);
                    this.PopBaloonsUp(commandRow, commandRow, selectedBaloon);
                    this.PopBaloonsDown(commandRow, commandRow, selectedBaloon);
                    movesCount++;
                }
                else
                {
                    Console.WriteLine("Cannot pop missing ballon!");
                    //continue;
                    return;
                }
                if (this.GameField1.IsFieldEmpty())
                {
                    Console.WriteLine("Congratulations! You completed the game in {0} moves.", movesCount);
                    //if (bestPlayers.isSkilled(movesCount))
                    // {
                    this.GameField1.Draw();
                    /*}
                    else
                    {
                        Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                    }*/
                    this.GameField1 = new GameField(5, 10);
                    movesCount = 0;
                }
                else
                {
                    this.GameField1.RemovePopedBaloons();
                }

                Console.WriteLine();
                this.GameField1.Draw();
                //break;
                return;
            }
            else
            {
                Console.WriteLine("Wrong input! Try Again!");
                //break;
                return;
            }

        }
        public void PopBaloonsLeft(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn - 1;
            char direcrtion = 'l';
            this.PopEngine(searchingInRow, searchinInCol, searchedItem, direcrtion);

        }

        public void PopBaloonsRight(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow;
            int searchinInCol = chosenColumn + 1;
            char direcrtion = 'r';
            this.PopEngine(searchingInRow, searchinInCol, searchedItem, direcrtion);

        }
        public void PopBaloonsUp(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow - 1;
            int searchinInCol = chosenColumn;
            char direcrtion = 'u';
            this.PopEngine(searchingInRow, searchinInCol, searchedItem, direcrtion);

        }

        public void PopBaloonsDown(int chosenRow, int chosenColumn, byte searchedItem)
        {
            int searchingInRow = chosenRow + 1;
            int searchinInCol = chosenColumn;
            char direcrtion = 'd';
            this.PopEngine(searchingInRow, searchinInCol, searchedItem, direcrtion);

        }

        public void PopEngine(int searchingInRow, int searchinInCol, byte searchedItem, char direction)
        {
            try
            {
                if (this.GameField1.GetFieldCell(searchingInRow, searchinInCol) == searchedItem)
                {
                    this.GameField1.SetFieldCell(searchingInRow, searchinInCol, 0);
                    switch (direction)
                    {
                        case 'l':
                            this.PopBaloonsLeft(searchingInRow, searchinInCol, searchedItem);
                            break;
                        case 'r':
                            this.PopBaloonsRight(searchingInRow, searchinInCol, searchedItem);
                            break;
                        case 'u':
                            this.PopBaloonsUp(searchingInRow, searchinInCol, searchedItem);
                            break;
                        case 'd':
                            this.PopBaloonsDown(searchingInRow, searchinInCol, searchedItem);
                            break;
                        default:
                            throw new ArgumentException("NOT Valid direction");
                    }
                }
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out of range");
                return;
            }
        }
    }
}



