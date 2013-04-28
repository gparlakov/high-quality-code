using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintStatistics;

namespace PrintStatisticsTests
{
    [TestClass]
    public class AverageUnitTests
    {
        [TestMethod]
        public void IsAverageTwoPointFourThree()
        {
            double[] testArr = new double[] { 1.1, 2.2, 3.3, 4.4, 3.2, 2.1, 1 };
            double expectedAverage = 2.47;
            double actualAverage = Math.Round(Statistics.GetAverage(testArr), 2);

            Assert.AreEqual(expectedAverage, actualAverage);
        }

        [TestMethod]
        public void IsAverageMinusNineteenPointNineOne()
        {
            double[] testArr = new double[] { -11.1, -22.2, -33.3, -6.6, -33.2, -22.1, -11 };
            double expectedAverage = -19.93;
            double actualAverage = Math.Round(Statistics.GetAverage(testArr), 2);

            Assert.AreEqual(expectedAverage, actualAverage);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IsNullReferenceExceptionThrown()
        {
            double[] testArr = null;
            Statistics.GetAverage(testArr);
        }
    }
}
