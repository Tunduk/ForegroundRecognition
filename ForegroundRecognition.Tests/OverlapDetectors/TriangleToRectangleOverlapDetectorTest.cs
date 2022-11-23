using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class TriangleToRectangleOverlapDetectorTest
{
    [Test]
    public void TriangleInsideRectangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(2, 2), new Point(2, 4), new Point(4, 3));
        var rectangle = new Rectangle(new Point(0, 0), 10, 10);

        var result = TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void RectangleInsideTriangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(10, 0), new Point(5, 6));
        var rectangle = new Rectangle(new Point(4, 3), 2, 2);

        var result = TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void TriangleBorderingRectangleBySideShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(5, 0), new Point(5, 5));
        var rectangle = new Rectangle(new Point(5, 4), 2, 2);

        var result = TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void TriangleBorderingRectangleByPointShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(5, 0), new Point(5, 5));
        var rectangle = new Rectangle(new Point(5, 5), 1, 1);

        var result = TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingTriangleAndRectangleShouldReturnFalse()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(0, 4), new Point(5, 0));
        var rectangle = new Rectangle(new Point(3, 5), 3, 3);

        var result = TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsFalse(result);
    }

    [Test]
    public void TriangleOneVertexInRectangleRectangleShouldReturnFalse()
    {
        var triangle = new Triangle(new Point(1, 3), new Point(7, 1), new Point(7, 3));
        var rectangle = new Rectangle(new Point(0, 0), 3, 5);

        var result = TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.True(result);
    }
}
