using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class RankListStorageTests
    {
        [TestMethod]
        public void TopFiveNullTest()
        {
            string filePath = @"..\..\TestFiles\ranklist.txt";
            IStorage storage = new RankListStorage(filePath);
            
            var resultTopFive = storage.TopFive();

            var expectedCount = 0;
            var resultCount = resultTopFive.Count;
            Assert.AreEqual(expectedCount, resultCount);
        }

        [TestMethod]
        public void TopFiveHalfTest()
        {
            string filePath = @"..\..\TestFiles\ranklist1.txt";
            IStorage storage = new RankListStorage(filePath);
            var topFive = new List<RankListRecord>(5);
            topFive.Add(new RankListRecord(9, "super cheater"));
            topFive.Add(new RankListRecord(15, "someplayer with very long name"));
            topFive.Add(new RankListRecord(16, "Todor"));

            bool areEqual = true;
            var resultTopFive = storage.TopFive();

            for (int i = 0; i < resultTopFive.Count; i++)
            {
                if (resultTopFive[i].Name != topFive[i].Name || resultTopFive[i].Value != topFive[i].Value)
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual, "The result from TopFive() is incorrect");
        }

        [TestMethod]
        public void TopFiveNormalTest()
        {
            string filePath = @"..\..\TestFiles\ranklist2.txt";
            IStorage storage = new RankListStorage(filePath);
            var topFive = new List<RankListRecord>(5);

            topFive.Add(new RankListRecord(9, "super cheater"));
            topFive.Add(new RankListRecord(12, "Pesho"));
            topFive.Add(new RankListRecord(15, "someplayer with very long name"));
            topFive.Add(new RankListRecord(16, "Todor"));
            topFive.Add(new RankListRecord(19, "Jhon"));

            bool areEqual = true;
            var resultTopFive = storage.TopFive();

            for (int i = 0; i < resultTopFive.Count; i++)
            {
                if (resultTopFive[i].Name != topFive[i].Name || resultTopFive[i].Value != topFive[i].Value)
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual, "The result from TopFive() is incorrect");
        }

        [TestMethod]
        public void AddRecordTest()
        {
            string filePath = @"..\..\TestFiles\ranklistForAddRecord.txt";
            RankListStorage storage = new RankListStorage(filePath);
            List < RankListRecord > expectedCurrList = new List<RankListRecord>();
            expectedCurrList.Add(new RankListRecord(12, "Pesho"));

            var actualCurrList = storage.CurrentRankList;
            storage.AddReccord(new RankListRecord(12, "Pesho"), false);

            bool areEqual = true;

            for (int i = 0; i < actualCurrList.Count; i++)
            {
                if (actualCurrList[i].Name != expectedCurrList[i].Name || actualCurrList[i].Value != expectedCurrList[i].Value)
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual, "The result from AddRecord() is incorrect");
        }

        [TestMethod]
        public void AddRecordTwoSameValuesTest()
        {
            string filePath = @"..\..\TestFiles\ranklistForAddRecord.txt";
            RankListStorage storage = new RankListStorage(filePath);
            List<RankListRecord> expectedCurrList = new List<RankListRecord>();
            expectedCurrList.Add(new RankListRecord(12, "Pesho"));
            expectedCurrList.Add(new RankListRecord(12, "Ivan"));
            expectedCurrList.Add(new RankListRecord(14, "Todor"));

            var actualCurrList = storage.CurrentRankList;
            storage.AddReccord(new RankListRecord(12, "Pesho"), false);
            storage.AddReccord(new RankListRecord(14, "Todor"), false);
            storage.AddReccord(new RankListRecord(12, "Ivan"), false);

            bool areEqual = true;

            for (int i = 0; i < actualCurrList.Count; i++)
            {
                if (actualCurrList[i].Name != expectedCurrList[i].Name || actualCurrList[i].Value != expectedCurrList[i].Value)
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual, "The result from AddRecord() is incorrect");
        }

        [TestMethod]
        public void AddRecordSortTest()
        {
            string filePath = @"..\..\TestFiles\ranklistForAddRecord.txt";
            RankListStorage storage = new RankListStorage(filePath);
            List<RankListRecord> expectedCurrList = new List<RankListRecord>();
            expectedCurrList.Add(new RankListRecord(12, "Pesho"));
            expectedCurrList.Add(new RankListRecord(13, "Ivan"));
            expectedCurrList.Add(new RankListRecord(16, "somePlayer"));
            expectedCurrList.Add(new RankListRecord(19, "otherPlayer"));
            expectedCurrList.Add(new RankListRecord(20, "PlayerThree"));

            var actualCurrList = storage.CurrentRankList;
            storage.AddReccord(new RankListRecord(20, "PlayerThree"), false);
            storage.AddReccord(new RankListRecord(12, "Pesho"), false);
            storage.AddReccord(new RankListRecord(19, "otherPlayer"),false);
            storage.AddReccord(new RankListRecord(13, "Ivan"), false);
            storage.AddReccord(new RankListRecord(16, "somePlayer"), false);

            bool areEqual = true;

            for (int i = 0; i < actualCurrList.Count; i++)
            {
                if (actualCurrList[i].Name != expectedCurrList[i].Name || actualCurrList[i].Value != expectedCurrList[i].Value)
                {
                    areEqual = false;
                }
            }
            Assert.IsTrue(areEqual, "The result from AddRecord() is incorrect");
        }

        [TestMethod]
        public void AddRecordBackupTest()
        {
            string filePath = @"..\..\TestFiles\ranklistForAddRecord.txt";
            RankListStorage storage = new RankListStorage(filePath);           
            storage.AddReccord(new RankListRecord(20, "PlayerThree"), false);
            storage.AddReccord(new RankListRecord(12, "Pesho"), false);
            storage.AddReccord(new RankListRecord(19, "otherPlayer"), true);

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Pesho, 12");
            expectedOutput.AppendLine("otherPlayer, 19");
            expectedOutput.AppendLine("PlayerThree, 20");            

            StreamReader reader = new StreamReader(filePath);
            string currentLine;

            using (reader)
            {
                currentLine = reader.ReadToEnd();                
            }

            bool areEqual = true;

            if (currentLine != expectedOutput.ToString())
            {
                areEqual = false;
            }
            Assert.IsTrue(areEqual, "The result from AddRecord() is incorrect");
        }

    }
}
