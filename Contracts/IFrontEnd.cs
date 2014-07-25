namespace BaloonsPopGame.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BaloonsPopGame.Engine;
    using BaloonsPopGame.RankList;

    public interface IFrontEnd
    {
        Command UserCommand();

        void RenderGameFieldState(byte[,] fieldClone);

        void PublishPrompt(PromptType prompt);

        void PrintTopFive(List<RankListRecord> topFive);

        void PrintCongratulations(bool isInTopFive);

        void Clear();

        RankListRecord Win(int moves);
    }
}
