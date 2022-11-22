using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes;

internal class TriangleTest
{
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
                new Point(10, 5),
                new Point(20, 5),
                new Point(15, 40)
            );

        Assert.That(triangle.GetArea(), Is.EqualTo(175));
    }

    [Test]
    public void GetTriangleEdgesShouldPass()
    {
        var firstPoint = new Point(10, 5);
        var secondPoint = new Point(20, 5);
        var thirdPoint = new Point(15, 40);

        var triangle = new Triangle(
                firstPoint,
                secondPoint,
                thirdPoint
            );
        var lines = triangle.GetEdges().ToArray();

        Assert.That(AreLinesEqual(lines[0], new Line(firstPoint, secondPoint)));
        Assert.That(AreLinesEqual(lines[1], new Line(secondPoint, thirdPoint)));
        Assert.That(AreLinesEqual(lines[2], new Line(thirdPoint, firstPoint)));
    }

    [Test]
    public void GetTrianglePointsShouldPass()
    {
        var firstPoint = new Point(10, 5);
        var secondPoint = new Point(20, 5);
        var thirdPoint = new Point(15, 40);

        var triangle = new Triangle(
                firstPoint,
                secondPoint,
                thirdPoint
            );

        var points = triangle.GetPoints().ToArray();

        Assert.That(points[0], Is.EqualTo(firstPoint));
        Assert.That(points[1], Is.EqualTo(secondPoint));
        Assert.That(points[2], Is.EqualTo(thirdPoint));
    }

    private bool AreLinesEqual(Line firstLine, Line secondLine)
    {
        return firstLine.StartPoint == secondLine.StartPoint && firstLine.EndPoint == secondLine.EndPoint;
    }
}
