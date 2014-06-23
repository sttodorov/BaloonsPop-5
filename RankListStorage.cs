using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class RankListStorage
    {
        private List<RankListReccord> currentRankList;

        public RankListStorage(string path)
        {
            this.FilePath = path;
            this.LoadReccordsFromFile();
        }

        public string FilePath { get; private set; }

        public List<RankListReccord> TopFive
        {
            get
            {
                var topFive = new List<RankListReccord>(5);
                
                //clone (not by ref) first 5 elements from currentRankList
                
                return topFive;
            }
        }

        public void AddReccord(RankListReccord reccord)
        {
            //validate Reccord has credible score value

            //insert at sorted position
        }

        private void LoadReccordsFromFile() 
        {
            //streamreader
            
            //while(...) {AddReccord}
        }

        private void SaveReccordsToFile() 
        {
            //streamwriter
            //foreach currentRankList {reccord.ToString()}
            //overwrite (not append)
        }
    }
}
