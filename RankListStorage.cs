using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class RankListStorage : IStorage
    {
        private List<RankListReccord> currentRankList;

        public RankListStorage(string path)
        {
            this.FilePath = path;
            this.LoadReccordsFromFile();
        }

        public string FilePath { get; private set; }

        public List<RankListReccord> TopFive()
        {
            var topFive = new List<RankListReccord>(5);

            throw new NotImplementedException("TopFive getter");
            //clone (not by ref) first 5 elements from currentRankList
                
            return topFive;
            
        }

        public void AddReccord(RankListReccord reccord, bool backUpCurrentList)
        {
            throw new NotImplementedException();
            //validate Reccord has credible score value

            //insert at sorted position

            //if(backUpCurrentList) SaveReccordsToFile()
        }

        private void LoadReccordsFromFile() 
        {
            throw new NotImplementedException();
            //streamreader
            
            //while(...) {AddReccord(reccord, false)}
        }

        private void SaveReccordsToFile() 
        {
            throw new NotImplementedException();
            //streamwriter
            //foreach currentRankList {reccord.ToString()}
            //overwrite (not append)
        }
    }
}
