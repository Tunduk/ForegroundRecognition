using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes
{
    internal class CircleTest
    {

        [Test]
        public void TryCreateCircleRadiusZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => { new Circle(new Point(10, 10), 0); });
        }

        [Test]
        public void TryCreateCircleRadiusBiggerMinimalXShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => { new Circle(new Point(10, 40), 20); });
        }

        [Test]
        public void TryCreateCircleRadiusBiggerMinimalYShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => { new Circle(new Point(40, 10), 20); });
        }

        [Test]
        public void CircleBoundingBoxShouldPass()
        {
            var circle = new Circle(new Point(10, 10), 5);

            var boundingBox = circle.GetBoundingBox();

            Assert.That(boundingBox.Height, Is.EqualTo(10));
            Assert.That(boundingBox.Width, Is.EqualTo(10));
            Assert.That(boundingBox.TopLeft.X, Is.EqualTo(5));
            Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(5));
        }
    }
}
