using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaloonsPopGame
{
    public class RankListStorage : IStorage
    {
        private List<RankListRecord> currentRankList = new List<RankListRecord>();

        public RankListStorage(string path)
        {
            this.FilePath = path;
            this.LoadReccordsFromFile();
        }

        public string FilePath { get; private set; }

        public List<RankListRecord> TopFive()
        {
            var topFive = new List<RankListRecord>(5);
            if (currentRankList != null)
            {
                currentRankList.Sort((x, y) => x.Value.CompareTo(y.Value));
            }

            for (int topFiveCount = 0; topFiveCount < 5; topFiveCount++)
            {
                if (topFiveCount + 1 > currentRankList.Count)
                {
                    break;
                }
                topFive.Add(new RankListRecord(currentRankList[topFiveCount].Value, currentRankList[topFiveCount].Name));
            }

            return topFive;
        }

        public void AddReccord(RankListRecord reccord, bool backUpCurrentList)
        {
            if (currentRankList.Count > 1)
            {
                currentRankList.Sort((x, y) => x.Value.CompareTo(y.Value));

                for (int i = 1; i < currentRankList.Count; i++)
                {
                    if (currentRankList[0].Value > reccord.Value)
                    {
                        currentRankList.Insert(0, reccord);
                        break;
                    }
                    else if (currentRankList[i - 1].Value <= reccord.Value && reccord.Value < currentRankList[i].Value)
                    {
                        currentRankList.Insert(i, reccord);
                        break;
                    }
                    else if (currentRankList[currentRankList.Count - 1].Value < reccord.Value)
                    {
                        currentRankList.Add(reccord);
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
            string currentLine;
            string[] currLineArgs;

            using (reader)
            {
                currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    currLineArgs = currentLine.Split(',');
                    if (int.Parse(currLineArgs[1].Trim()) > 1 && int.Parse(currLineArgs[1].Trim()) < (GameConstants.FieldCols * GameConstants.FieldRows))
                    {
                        AddReccord(new RankListRecord(int.Parse(currLineArgs[1].Trim()), currLineArgs[0].Trim()), false);
                    }
                    currentLine = reader.ReadLine();
                }
            }
        }

        private void SaveReccordsToFile()
        {
            StreamWriter writer = new StreamWriter(FilePath, false);

            using (writer)
            {
                for (int i = 0; i < currentRankList.Count; i++)
                {
                    writer.WriteLine(currentRankList[i].ToString());
                }
            }
        }
    }
}
