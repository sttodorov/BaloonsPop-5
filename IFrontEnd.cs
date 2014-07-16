using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public interface IFrontEnd
    {
        Command UserCommand();

        void RenderGameFieldState(byte[,] fieldClone);

        void PublishPrompt();

        void PrintTopFive(List<RankListRecord> topFive);

        void PrintCongratulations(bool isInTopFive);

        void Clear();

        RankListRecord Win(int moves);
    }
}
