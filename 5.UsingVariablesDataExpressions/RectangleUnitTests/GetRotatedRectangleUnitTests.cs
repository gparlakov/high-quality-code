using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace RectangleUnitTests
{
    [TestClass]
    public class GetRotatedRectangleUnitTests
    {
        [TestMethod]
        public void AngleHalfPiSizeTwo_IsRotatedSideTwo()
        {
            double width = 2,
                   heigth = 2,
                   angle = Math.PI / 2;

            double expectedWith = 2;
            double expectedHeight = 2;

            Rectangle testRectangle = new Rectangle(width, heigth);
            Rectangle testRotatedRectangle = Rectangle.GetRotatedRectangle(testRectangle,angle);

            Assert.AreEqual(expectedWith, testRotatedRectangle.Width);
            Assert.AreEqual(expectedHeight, testRotatedRectangle.Height);
        }


        [TestMethod]
        public void AnglePiSizeTwo_IsRotatedSideTwo()
        {
            double  width = 2,
                    heigth = 2,
                    angle = Math.PI;

            double expectedWith = 2.00;
            double expectedHeight = 2.00;

            Rectangle testRectangle = new Rectangle(width, heigth);
            Rectangle testRotatedRectangle = Rectangle.GetRotatedRectangle(testRectangle, angle);

            Assert.AreEqual(expectedWith, Math.Round(testRotatedRectangle.Width, 2));
            Assert.AreEqual(expectedHeight, Math.Round(testRotatedRectangle.Height, 2));
        }
    }
}
