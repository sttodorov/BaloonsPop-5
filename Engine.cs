namespace BaloonsPopGame
{
using System;
using System.Collections.Generic;
using System.Linq;

    public class Engine
    {
        private IFrontEnd frontEnd;
        private IStorage rankList;
        private GameField gameField;

        public Engine(IFrontEnd frontEnd, IStorage reccordStorage)
        {
            this.rankList = reccordStorage;
            this.frontEnd = frontEnd;
            this.GameField = new GameField(5, 10);
        }

        public List<RankListReccord> TopFive
        {
            get
            {
                return this.rankList.TopFive();
            }
        }

        public GameField GameField // * here we have a private field being passed by reference via Property with public get/set
                                   // * we should to talk about how much to encapsulate the gameField field
                                   //since eventually we're going to be passing it to the PopEngine static class
                                   // * also, should validation be done here (in Engine.GameField) or in the GameField class's indexer?
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
            Command userCommand = frontEnd.UserCommand();
            int movesCount = 0;
            while (userCommand.Type != CommandType.Exit)
            {
                this.frontEnd.RenderGameFieldState(this.GameField);

                if (this.GameField.IsFieldEmpty())
                {
                    var newReccord = frontEnd.Win(movesCount);
                    this.rankList.AddReccord(newReccord, true);
                    //this.RestartGame() <-may want to have this as an event to avoid repeating code
                    movesCount = 0;
                }

                userCommand = frontEnd.UserCommand();

                switch (userCommand.Type)
                {
                    case CommandType.Restart:
                        this.GameField = new GameField(5, 10);
                        movesCount = 0;
                        break;

                    case CommandType.TopFive:
                        var topFive = rankList.TopFive();
                        frontEnd.PrintTopFive(topFive);
                        break;
                    
                    case CommandType.Exit:
                        //frontEnd.Exit()?? or just close, and instead have Exit events attached to the frontEnd?
                        break;

                    case CommandType.PopBalloonAt:
                        this.PopEngine(userCommand.Data);
                        break;

                    default:
                        throw new InvalidOperationException("User command is of invalid type.");
                }
            }
        }

        

        public void PopEngine(object data)
        {
            int[] coordinates = data as int[];
            
            //Validate data as coordinates
            //Pass game field and coord to static Class PopEngine
            //*static class PopEngine will contain all the popping logic and recursive calls
            //its PopAt(row, col) method will modify the game field

            var commandRow = coordinates[0];
            var commandCol = coordinates[1];
            
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

        
    }
}