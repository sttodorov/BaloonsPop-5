using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaloonsPopGame
{
    public class RankListStorage : IStorage
    {
        private List<RankListReccord> currentRankList = new List<RankListReccord>();

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

            for (int i = 0, j = 1; i < 5; i++, j++)
            {
                if (j > currentRankList.Count)
                {
                    break;
                }
                topFive.Add(new RankListReccord(currentRankList[i].Value, currentRankList[i].Name));
            }

            return topFive;
        }

        public void AddReccord(RankListReccord reccord, bool backUpCurrentList)
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
                        AddReccord(new RankListReccord(int.Parse(currLineArgs[1].Trim()), currLineArgs[0].Trim()), false);
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
