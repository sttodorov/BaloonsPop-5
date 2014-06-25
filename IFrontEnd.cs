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

        void PublishPrompt(); //Not entirely sure we need this

        void PrintTopFive(List<RankListReccord> topFive);

        RankListReccord Win(int moves);

    }
}
