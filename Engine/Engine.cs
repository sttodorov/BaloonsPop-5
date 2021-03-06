﻿namespace BaloonsPopGame.Engine
{
    using System;
    using System.Collections.Generic;

    using BaloonsPopGame.Contracts;
    using BaloonsPopGame.GameField;
    using BaloonsPopGame.RankList;

    public class Engine
    {
        private static Engine engineInstance;

        private IFrontEnd frontEnd;
        private IStorage rankList;
        private IFacade facade;
        private Command userCommand;

        private Engine(IFrontEnd frontEnd, IStorage reccordStorage, IFacade facade, Command userCommand)
        {
            this.rankList = reccordStorage;
            this.frontEnd = frontEnd;
            this.facade = facade;
            this.UserCommand = userCommand;
        }

        private Engine(IFrontEnd frontEnd, IStorage reccordStorage)
            : this(frontEnd, reccordStorage, new GameFieldFacade(GameConstants.FieldRows, GameConstants.FieldCols), new Command(CommandType.Restart))
        {
        }

        private List<RankListRecord> TopFive
        {
            get
            {
                return this.rankList.TopFive();
            }
        }

        private IFacade Facade // * here we have a private field being passed by reference via Property with public get/set
        // * we should to talk about how much to encapsulate the gameField field
        // since eventually we're going to be passing it to the PopEngine static class
        // * also, should validation be done here (in Engine.GameField) or in the GameField class's indexer?
        {
            get
            {
                return this.facade;
            }

            set
            {
                this.facade = value;
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
            ////this.UserCommand = new Command(CommandType.Restart);
            int movesCount = 0;
            while (this.UserCommand.Type != CommandType.Exit)
            {
                this.frontEnd.RenderGameFieldState(this.Facade.GameFieldClone());

                if (this.Facade.IsWin())
                {
                    var newReccord = this.frontEnd.Win(movesCount);
                    var topFive = this.TopFive;
                    bool isInTopFive = topFive[topFive.Count - 1].Value > newReccord.Value;
                    this.rankList.AddReccord(newReccord, true);
                    this.frontEnd.PrintCongratulations(isInTopFive);
                    this.frontEnd.PrintTopFive(this.TopFive);
                    this.Facade.CreateNewField(GameConstants.FieldRows, GameConstants.FieldCols);
                    continue;
                }

                this.UserCommand = this.frontEnd.UserCommand();

                this.frontEnd.Clear();

                switch (this.UserCommand.Type)
                {
                    case CommandType.Restart:
                        this.Facade.CreateNewField(GameConstants.FieldRows, GameConstants.FieldCols);
                        movesCount = 0;
                        break;

                    case CommandType.TopFive:
                        var topFive = this.TopFive;
                        this.frontEnd.PrintTopFive(topFive);
                        break;

                    case CommandType.Exit:
                        // frontEnd.Exit()?? or just close, and instead have Exit events attached to the frontEnd?
                        break;

                    case CommandType.Undo:
                        try
                        {
                            this.facade.Undo();
                            movesCount--;
                        }
                        catch (InvalidOperationException)
                        {
                            frontEnd.PublishPrompt(PromptType.UnableToUndo);
                        }

                        break;

                    case CommandType.PopBalloonAt:
                        try
                        {
                            this.Facade.PopAt(this.UserCommand.Data);
                            movesCount++;
                        }
                        catch (InvalidOperationException)
                        {
                            frontEnd.PublishPrompt(PromptType.MissingBalloon);
                        }

                        break;

                    default:
                        throw new InvalidOperationException("User command is of invalid type.");
                }
            }
        }
    }
}