using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes;

internal class RectangleTest
{
    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    public void TryCreateRectangleOneDimensionIsZeroOrLessShouldThrowArgumentException(double width, double height)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Rectangle(new Point(1, 1), width, height);
        });
    }

    [TestCase(0, 1)]
    [TestCase(1, 0)]
    public void RectangleZeroSideShouldPass(double width, double height)
    {
        Assert.DoesNotThrow(() =>
        {
            new Rectangle(new Point(1, 1), width, height);
        });
    }

    [TestCase(5, 10, 50)]
    [TestCase(6, 7, 42)]
    public void RectangleAreaShouldReturnPass(double width, double height, double expectedArea)
    {
        var rectangle = new Rectangle(new Point(1, 1), width, height);
        var area = rectangle.GetArea();
        Assert.That(area, Is.EqualTo(expectedArea));
    }

    [Test]
    public void RectangleBoundingBoxShouldPass()
    {
        var rectangle = new Rectangle(new Point(10, 10), 20, 30);

        var boundingBox = rectangle.GetBoundingBox();

        Assert.That(boundingBox.Width, Is.EqualTo(rectangle.Width));
        Assert.That(boundingBox.Height, Is.EqualTo(rectangle.Height));
        Assert.That(boundingBox.TopLeft.X, Is.EqualTo(rectangle.TopLeft.X));
        Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(rectangle.TopLeft.Y));
    }

    [Test]
    public void GetEdgesShouldReturnInClockwise()
    {
        var rectangle = new Rectangle(new Point(10, 10), 20, 30);

        var edges = rectangle.GetEdges().ToArray();

        Assert.That(AreLinesEqual(edges[0], new Line(rectangle.TopLeft, new Point(rectangle.TopLeft.X + rectangle.Width, rectangle.TopLeft.Y))));
        Assert.That(AreLinesEqual(edges[1], new Line(new Point(rectangle.TopLeft.X + rectangle.Width, rectangle.TopLeft.Y), new Point(rectangle.TopLeft.X + rectangle.Width, rectangle.TopLeft.Y + rectangle.Height))));
        Assert.That(AreLinesEqual(edges[2], new Line(new Point(rectangle.TopLeft.X + rectangle.Width, rectangle.TopLeft.Y + rectangle.Height), new Point(rectangle.TopLeft.X, rectangle.TopLeft.Y + rectangle.Height))));
        Assert.That(AreLinesEqual(edges[3], new Line(new Point(rectangle.TopLeft.X, rectangle.TopLeft.Y + rectangle.Height), rectangle.TopLeft)));
    }

    private bool AreLinesEqual(Line firstLine, Line secondLine)
    {
        return firstLine.StartPoint == secondLine.StartPoint && firstLine.EndPoint == secondLine.EndPoint;
    }
}
