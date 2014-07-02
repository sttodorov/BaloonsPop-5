using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPopGame.Tests
{
    [TestClass]
    public class RankListReccordTests
    {
        [TestMethod]
        public void RankListReccordToString()
        {
            var reccord = new RankListRecord(15, "A happy name");

            var actual = reccord.ToString();

            var expected = "A happy name, 15";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RankListReccordToFormattedString()
        {
            var reccord = new RankListRecord(15, "A happy name");

            var actual = reccord.ToFormattedString();

            var expected = ".    A happy name with 15 moves.";

            Assert.AreEqual(expected, actual);
        }
    }
}
