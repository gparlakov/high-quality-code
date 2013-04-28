using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintStatistics;

namespace PrintStatisticsTests
{
    [TestClass]
    public class MaxUnitTests
    {
        [TestMethod]
        public void IsMaxFourPointFour()
        {
            double[] testArr = new double[] { 1.1, 2.2, 3.3, 4.4, 3.2, 2.1, 1 };
            double expectedMax = 4.4;
            double actualMax = Statistics.GetMax(testArr);

            Assert.AreEqual(expectedMax, actualMax);
        }

        [TestMethod]
        public void IsMaxMinusSixPointSix()
        {
            double[] testArr = new double[] { -11.1, -22.2, -33.3, -6.6, -33.2, -22.1, -11 };
            double expectedMax = -6.6;
            double actualMax = Statistics.GetMax(testArr);

            Assert.AreEqual(expectedMax, actualMax);
        } 

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IsNullReferenceExceptionThrown()
        {
            double[] testArr = null;
            Statistics.GetMax(testArr);
        }
    }
}
