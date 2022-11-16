

namespace ForegroundRecognition.Tests.Shapes
{
    internal class PointTest
    {
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [TestCase(-1, -1)]
        public void TryCreatePointAxisLessZeroShouldThrowArgumentException(double x, double y)
        {
            Assert.Throws<ArgumentException>(() => new Point(x, y));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(5, 1)]
        [TestCase(1, 5)]
        public void TryCreatePointShouldPass(double x, double y)
        {
            Assert.DoesNotThrow(() => new Point(x, y));
        }


        [TestCase(1, 1)]
        [TestCase(10, 1)]
        [TestCase(1, 10)]
        public void ClonePointShouldPass(double x, double y)
        {
            var point = new Point(x, y);

            var pointClone = (Point)point.Clone();

            Assert.That(pointClone.X, Is.EqualTo(point.X));
            Assert.That(pointClone.Y, Is.EqualTo(point.Y));
        }
    }
}
