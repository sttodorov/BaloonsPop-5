using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public interface IStorage
    {
        List<RankListReccord> TopFive();
        
        void AddReccord(RankListReccord reccord, bool backUpCurrentList);
    }
}
