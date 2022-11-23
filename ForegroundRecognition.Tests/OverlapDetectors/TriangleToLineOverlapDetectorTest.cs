using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class TriangleToLineOverlapDetectorTest
{
    [Test]
    public void LineInsideRectangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 0));
        var rectangle = new Line(new Point(2, 2), new Point(3, 3));

        var result = TriangleToLineOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineCrossTwoSidesOfTriangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(3, 4), new Point(6, 0));
        var rectangle = new Line(new Point(0, 2), new Point(6, 2));

        var result = TriangleToLineOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineCrossOneSideOfTriangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(3, 4), new Point(6, 0));
        var rectangle = new Line(new Point(0, 2), new Point(3, 2));

        var result = TriangleToLineOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineBorderingTriangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(3, 4), new Point(6, 0));
        var rectangle = new Line(new Point(0, 0), new Point(3, 4));

        var result = TriangleToLineOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineOnePointIsVertexOfTriangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(3, 4), new Point(6, 0));
        var rectangle = new Line(new Point(0, 2), new Point(3, 4));

        var result = TriangleToLineOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingLineAndTriangleShouldReturnFalse()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(3, 4), new Point(6, 0));
        var rectangle = new Line(new Point(0, 2), new Point(3, 6));

        var result = TriangleToLineOverlapDetector.IsOverlap(triangle, rectangle);

        Assert.IsFalse(result);
    }
}
