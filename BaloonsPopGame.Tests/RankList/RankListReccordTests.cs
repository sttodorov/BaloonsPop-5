namespace BaloonsPopGame.RankList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RankListReccordTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RankListRecordCreateWithInvalidValue()
        {
            var record = new RankListRecord(0, "pesho");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RankListRecordCreateWithInvalidName()
        {
            var record = new RankListRecord(6, " ");
        }

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

            var expected = ".    A happy name                   -  15 moves.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareToHigherResult()
        {
            var recordWithHigherScore = new RankListRecord(10, "pesho");
            var recordWithLowerScore = new RankListRecord(3, "gosho");
            int result = recordWithHigherScore.CompareTo(recordWithLowerScore);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CompareToEqualResult()
        {
            var record1 = new RankListRecord(10, "pesho");
            var record2 = new RankListRecord(10, "gosho");
            int result = record1.CompareTo(record2);

            Assert.AreEqual(result, 0);
        }
    }
}
