using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public interface IStorage
    {
        List<RankListRecord> TopFive();
        
        void AddReccord(RankListRecord reccord, bool backUpCurrentList);
    }
}
