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
        public void TopFiveNormalTest()
        {
            string filePath = @"..\..\TestFiles\ranklist1.txt";
            IStorage storage = new RankListStorage(filePath);
            var topFive = new List<RankListRecord>(5);

            var resultTopFive = storage.TopFive();

            var expectedCount = 0;
            var resultCount = resultTopFive.Count;
            Assert.AreEqual(expectedCount, resultCount);
        }
    }
}
