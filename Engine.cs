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
            Command userCommand = new Command(CommandType.Restart);
            int movesCount = 0;
            while (userCommand.Type != CommandType.Exit)
            {

                this.frontEnd.RenderGameFieldState(this.GameField.Clone());

                if (this.GameField.IsFieldEmpty())
                {
                    var newReccord = frontEnd.Win(movesCount);
                    this.rankList.AddReccord(newReccord, true);
                    //this.RestartGame() <-may want to have this as an event to avoid repeating code
                    this.GameField = new GameField(5, 10);
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
                        try
                        {
                            this.PopAt(userCommand.Data);
                            this.GameField.RemovePopedBaloons();
                            movesCount++;
                        }
                        catch (InvalidOperationException)
                        {

                            frontEnd.PublishPrompt();
                        }
                        
                        break;

                    default:
                        throw new InvalidOperationException("User command is of invalid type.");
                }
            }
        }

        public void PopAt(object data)
        {
            int[] coordinates = data as int[];
            
            //Validate data as coordinates
            //Pass game field and coord to static Class PopEngine
            //*static class PopEngine will contain all the popping logic and recursive calls
            //its PopAt(row, col) method will modify the game field

            var commandRow = coordinates[0];
            var commandCol = coordinates[1];

            try
            {
                PopEngine.PopAt(commandRow, commandCol, this.GameField); // !---here we pass the whole gameField to popEngine---!
            }
            catch (InvalidOperationException)
            {

                throw new InvalidOperationException("Attempted to pop missing balloon.");
            }
            
        }
    }
}