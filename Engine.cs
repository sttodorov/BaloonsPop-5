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
        private Command userCommand;

        private Engine(IFrontEnd frontEnd, IStorage reccordStorage, GameField gameField = null, Command userCommand = null)// Added GameField and Command. When you create engine you should know it depend on them- SOLID
        {
            this.rankList = reccordStorage;
            this.frontEnd = frontEnd;
            this.GameField = new GameField(GameConstants.FieldRows, GameConstants.FieldCols);
            this.UserCommand = new Command(CommandType.Restart);
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

        private Command UserCommand
        {
            get
            {
                return this.userCommand;
            }
            set
            {
                //validation
                this.userCommand = value;
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
            this.UserCommand = new Command(CommandType.Restart);
            int movesCount = 0;
            while (this.UserCommand.Type != CommandType.Exit)
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

                this.UserCommand = this.frontEnd.UserCommand();

                switch (this.UserCommand.Type)
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
                            this.GameField.PopAt(this.UserCommand.Data);
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

    }
}