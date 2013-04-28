using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace RectangleUnitTests
{
    [TestClass]
    public class GetRotatedFigureUnitTests
    {
        [TestMethod]
        public void AngleHalfPiSizeTwo_IsRotatedSideTwo()
        {
            double width = 2,
                   heigth = 2,
                   angle = Math.PI / 2;

            double expectedWith = 2;
            double expectedHeight = 2;

            Figure testFigure = new Figure(width, heigth);
            Figure testRotatedFigure = Figure.GetRotatedRectangle(testFigure,angle);

            Assert.AreEqual(expectedWith, testRotatedFigure.Width);
            Assert.AreEqual(expectedHeight, testRotatedFigure.Height);
        }


        [TestMethod]
        public void AnglePiSizeTwo_IsRotatedSideTwo()
        {
            double  width = 2,
                    heigth = 2,
                    angle = Math.PI;

            double expectedWith = 2.00;
            double expectedHeight = 2.00;

            Figure testFigure = new Figure(width, heigth);
            Figure testRotatedFigure = Figure.GetRotatedRectangle(testFigure, angle);

            Assert.AreEqual(expectedWith, Math.Round(testRotatedFigure.Width, 2));
            Assert.AreEqual(expectedHeight, Math.Round(testRotatedFigure.Height, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeWidthArgumentOutOfRangeException()
        {
            double  width = -2,
                    heigth = 2;

            Figure testFigure = new Figure(width, heigth);
        }
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeHeightArgumentOutOfRangeException()
        {
            double  width = -2,
                    heigth = 2;

            Figure testFigure = new Figure(width, heigth);
        }
    }
}
