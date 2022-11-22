using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes;

internal class TriangleTest
{
    //TODO Write more tests
    [Test]
    public void GetBoundingBoxShouldPass()
    {
        var triangle = new Triangle(
            new Point(0, 0),
            new Point(0, 10),
            new Point(20, 10)
        );

        var boundingBox = triangle.GetBoundingBox();

        Assert.That(boundingBox.TopLeft.X, Is.EqualTo(0));
        Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(0));
        Assert.That(boundingBox.Width, Is.EqualTo(20));
        Assert.That(boundingBox.Height, Is.EqualTo(10));
    }

    [Test]
    public void CalculateAreaShouldPass()
    {
        var triangle = new Triangle(
                new Point(10,5),
                new Point(20,5),
                new Point(15,40)
            );

        Assert.That(triangle.Area, Is.EqualTo(175));
    }
}
