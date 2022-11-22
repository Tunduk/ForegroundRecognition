using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class TriangleToTriangleOverlapDetectorTest
{

    [Test]
    public void OneInsideAnotherShoulReturnTrue()
    {
        var firstCircle = new Triangle(new Point(0, 0), new Point(5, 0), new Point(5, 5));
        var secondCircle = new Triangle(new Point(2, 1), new Point(4, 1), new Point(4, 3));

        var result = TriangleToTriangleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void BorderingBySideTriangleshoulReturnTrue()
    {
        var firstCircle = new Triangle(new Point(0, 0), new Point(5, 0), new Point(5, 5));
        var secondCircle = new Triangle(new Point(5, 0), new Point(10, 0), new Point(5, 5));

        var result = TriangleToTriangleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void BorderingByOnePointTriangleShoulReturnTrue()
    {
        var firstCircle = new Triangle(new Point(0, 0), new Point(5, 0), new Point(0, 5));
        var secondCircle = new Triangle(new Point(5, 0), new Point(10, 0), new Point(5, 5));

        var result = TriangleToTriangleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingTrianglesShoulReturnFalse()
    {
        var firstCircle = new Triangle(new Point(0, 0), new Point(0, 5), new Point(5, 0));
        var secondCircle = new Triangle(new Point(0, 6), new Point(6, 5), new Point(1, 5));

        var result = TriangleToTriangleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.False(result);
    }

    [Test]
    public void OverlappingTrianglesThreeSidesShoulReturnTrue()
    {
        var firstCircle = new Triangle(new Point(0, 1), new Point(6, 1), new Point(3, 6));
        var secondCircle = new Triangle(new Point(0, 5), new Point(6, 5), new Point(0, 3));

        var result = TriangleToTriangleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.True(result);
    }
}
