using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    interface IStorage
    {
        public List<RankListReccord> TopFive;
        
        public void AddReccord(RankListReccord reccord, bool backUpCurrentList);
    }
}
