using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
    }
}
