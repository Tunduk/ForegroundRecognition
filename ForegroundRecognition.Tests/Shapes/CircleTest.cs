using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes;

internal class CircleTest
{
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

    [Test]
    public void CircleAreaShouldPass()
    {
        var circle = new Circle(new Point(10, 10), 5);

        var area = circle.GetArea();

        Assert.That(Math.Round(area, 2), Is.EqualTo(78.54));

    }
}
