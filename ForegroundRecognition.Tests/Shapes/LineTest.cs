using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes
{
    internal class LineTest
    {
        [Test]
        public void GetBoundingBoxVerticalLine()
        {
            var line = new Line(new Point(1,1), new Point(1,10));

            var boundingBox = line.GetBoundingBox();

            Assert.That(boundingBox.TopLeft.X, Is.EqualTo(1));
            Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(1));
            Assert.That(boundingBox.Width, Is.EqualTo(1));
            Assert.That(boundingBox.Height, Is.EqualTo(9));
        }
        
        [Test]
        public void GetBoundingBoxHorizontalLine()
        {
            var line = new Line(new Point(1, 1), new Point(10, 1));

            var boundingBox = line.GetBoundingBox();

            Assert.That(boundingBox.TopLeft.X, Is.EqualTo(1));
            Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(1));
            Assert.That(boundingBox.Width, Is.EqualTo(9));
            Assert.That(boundingBox.Height, Is.EqualTo(1));
        }

        [Test]
        public void GetBoundingBoxLine()
        {
            var line = new Line(new Point(1, 1), new Point(10, 10));

            var boundingBox = line.GetBoundingBox();

            Assert.That(boundingBox.TopLeft.X, Is.EqualTo(1));
            Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(1));
            Assert.That(boundingBox.Width, Is.EqualTo(9));
            Assert.That(boundingBox.Height, Is.EqualTo(9));
        }
    }
}
