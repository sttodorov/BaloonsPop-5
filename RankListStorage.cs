using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            if (currentRankList != null)
            {
                currentRankList.Sort((x, y) => x.Value.CompareTo(y.Value));
            }            
            
            for (int i = 0 , j = 1; i < 5; i++, j++)
            {
                if (j> currentRankList.Count)
                {
                    break;
                }
                topFive.Add(new RankListReccord(currentRankList[i].Value,currentRankList[i].Name));
            }
 
            return topFive;            
        }

        public void AddReccord(RankListReccord reccord, bool backUpCurrentList)
        {
            // TODO validate Reccord has credible score value
            if (currentRankList != null)
            {
               currentRankList.Sort((x, y) => x.Value.CompareTo(y.Value));

               for (int i = 0; i < currentRankList.Count; i++)
               {
                   if (currentRankList[i].Value <= reccord.Value && reccord.Value < currentRankList[i + 1].Value)
                   {
                       currentRankList.Insert(i + 1, reccord);
                       break;
                   }
               }
            }
            else
            {
                currentRankList.Add(reccord);
            }
           
            if (backUpCurrentList) 
            {
                SaveReccordsToFile();
            }
        }

        private void LoadReccordsFromFile() 
        {
            StreamReader reader = new StreamReader(FilePath);
            string[] currentLine;

            using (reader)
            {
                while ((currentLine = reader.ReadLine().Split(',')) != null)
                {                    
                    AddReccord(new RankListReccord(int.Parse(currentLine[1].Trim()), currentLine[0].Trim()), false);
                }
                
            }
        }

        private void SaveReccordsToFile() 
        {
            StreamWriter writer = new StreamWriter(FilePath,false);

            using (writer)
            {
                for (int i = 0; i < currentRankList.Count; i++)
                {
                    writer.WriteLine(currentRankList[i].ToString());
                }
            }

            //streamwriter
            //foreach currentRankList {reccord.ToString()}
            //overwrite (not append)
        }
    }
}
