namespace BaloonsPopGame.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BaloonsPopGame.RankList;

    public interface IStorage
    {
        List<RankListRecord> TopFive();
        
        void AddReccord(RankListRecord reccord, bool backUpCurrentList);
    }
}
