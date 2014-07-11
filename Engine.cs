namespace BaloonsPopGame
{
using System;
using System.Collections.Generic;
using System.Linq;

    public class Engine
    {
        private static Engine engineInstance;
        private IFrontEnd frontEnd;
        private IStorage rankList;
        private GameField gameField;

        private Engine(IFrontEnd frontEnd, IStorage reccordStorage)
        {
            this.rankList = reccordStorage;
            this.frontEnd = frontEnd;
            this.GameField = new GameField(GameConstants.FieldRows, GameConstants.FieldCols);
        }
        
        private List<RankListRecord> TopFive
        {
            get
            {
                return this.rankList.TopFive();
            }
        }

        private GameField GameField // * here we have a private field being passed by reference via Property with public get/set
                                   // * we should to talk about how much to encapsulate the gameField field
                                   // since eventually we're going to be passing it to the PopEngine static class
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

        public static Engine GetInstance(IFrontEnd frontEnd, IStorage reccordStorage)
        {
            if (engineInstance != null)
            {
                throw new InvalidOperationException("Engine already created - use getinstance()");
            }

            engineInstance = new Engine(frontEnd, reccordStorage);
            return engineInstance;
        }

        public static Engine GetInstance()
        {
            if (engineInstance == null)
            {
                throw new InvalidOperationException("Engine not created - use Engine(IFrontEnd frontEnd, IStorage reccordStorage)");
            }

            return engineInstance;
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
                    var newReccord = this.frontEnd.Win(movesCount);
                    var topFive = this.TopFive;
                    bool isInTopFive = topFive[topFive.Count - 1].Value > newReccord.Value;
                    this.rankList.AddReccord(newReccord, true);
                    this.frontEnd.PrintCongratulations(isInTopFive);
                    this.frontEnd.PrintTopFive(this.TopFive);
                    this.RestartGame(ref movesCount);
                    continue;
                }

                userCommand = this.frontEnd.UserCommand();

                switch (userCommand.Type)
                {
                    case CommandType.Restart:
                        this.RestartGame(ref movesCount);
                        break;

                    case CommandType.TopFive:
                        var topFive = this.TopFive;
                        this.frontEnd.PrintTopFive(topFive);
                        break;
                    
                    case CommandType.Exit:
                        // frontEnd.Exit()?? or just close, and instead have Exit events attached to the frontEnd?
                        break;

                    case CommandType.PopBalloonAt:
                        try
                        {
                            this.PopAt(userCommand.Data);
                            this.GameField.RemovePoppedBaloons();
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

        private void RestartGame(ref int count)
        {
            this.GameField = new GameField(GameConstants.FieldRows, GameConstants.FieldCols);
            count = 0;
        }

        private void PopAt(object data)
        {
            int[] coordinates = data as int[];
            
            // Validate data as coordinates
            // Pass game field and coord to static Class PopEngine
            // *static class PopEngine will contain all the popping logic and recursive calls
            // its PopAt(row, col) method will modify the game field

            var commandRow = coordinates[0];
            var commandCol = coordinates[1];

            try
            {
                this.GameField.PopAt(commandRow, commandCol); // !---here we pass the whole gameField to popEngine---!
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Attempted to pop missing balloon.");
            }
        }
    }
}