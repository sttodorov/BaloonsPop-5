using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    class Engine
    {
        private List<RankListReccord> topPlayers;
        private GameField gameField;

        public Engine()
        {
            this.GameField = new GameField(5, 10);
            this.TopPlayers = new List<RankListReccord>();
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
            while (userCommand != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userCommand = Console.ReadLine();
                userCommand = userCommand.ToUpper().Trim();

                switch (userCommand)
                {
                    case "RESTART":
                        Console.WriteLine("\nNEW GAME!\n");

                        this.GameField.Draw();
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
                        Console.WriteLine("Good Bye! ");
                        break;

                    default:
                        RenderUserCommand(userCommand);
                        break;


                }
            }
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
                    return;
                }

                byte selectedBaloon = this.GameField.GetFieldCell(commandRow, commandCol);
                if (selectedBaloon != 0)
                {
                    //Pop Baloon
                    this.GameField.SetFieldCell(commandRow, commandCol, 0);

                    this.PopBaloonsLeft(commandRow, commandCol, selectedBaloon);
                    this.PopBaloonsRight(commandRow, commandCol, selectedBaloon);
                    this.PopBaloonsUp(commandRow, commandCol, selectedBaloon);
                    this.PopBaloonsDown(commandRow, commandCol, selectedBaloon);

                    movesCount++;
                }
                else
                {
                    Console.WriteLine("Cannot pop missing ballon!");
                    return;
                }

                if (this.GameField.IsFieldEmpty())
                {
                    Console.WriteLine("Congratulations! You completed the game in {0} moves.", movesCount);
                    //if (bestPlayers.isSkilled(movesCount))
                    //{
                    this.GameField.Draw();
                    /*}
                    else
                    {
                        Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                    }*/
                    this.GameField = new GameField(5, 10);
                    movesCount = 0;
                }
                else
                {
                    this.GameField.RemovePopedBaloons();
                }

                Console.WriteLine();
                this.GameField.Draw();
                return;
            }
            else
            {
                Console.WriteLine("Wrong input! Try Again!");
                return;
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
                PopBaloonsLeft(searchingInRow, searchinInCol, searchedItem);
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
                PopBaloonsRight(searchingInRow, searchinInCol, searchedItem);
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
            if(this.GameField.GetFieldCell(searchingInRow,searchinInCol)==searchedItem)
            {
                this.GameField.SetFieldCell(searchingInRow, searchinInCol, 0);
                PopBaloonsUp(searchingInRow, searchinInCol, searchedItem);
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
                PopBaloonsDown(searchingInRow, searchinInCol, searchedItem);
            }
        }
    }
}



