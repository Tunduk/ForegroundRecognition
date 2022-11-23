using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class LineToRectangleOverlapDetectorTest
{
    [Test]
    public void LineInsideRectangleShouldReturnTrue()
    {
        var line = new Line(new Point(1, 1), new Point(6, 1));
        var rectangle = new Rectangle(new Point(0, 10), 10, 10);

        var result = LineToRectangleOverlapDetector.IsOverlap(line, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineIsSideOfRectangleShouldReturnTrue()
    {
        var line = new Line(new Point(0, 0), new Point(0, 5));
        var rectangle = new Rectangle(new Point(0, 0), 10, 10);

        var result = LineToRectangleOverlapDetector.IsOverlap(line, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineCrossRectangleTwoSidesShouldReturnTrue()
    {
        var line = new Line(new Point(2, 3), new Point(9, 3));
        var rectangle = new Rectangle(new Point(3, 2), 5, 2);

        var result = LineToRectangleOverlapDetector.IsOverlap(line, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineCrossRectangleOneSidesShouldReturnTrue()
    {
        var line = new Line(new Point(2, 3), new Point(5, 3));
        var rectangle = new Rectangle(new Point(3, 2), 5, 2);

        var result = LineToRectangleOverlapDetector.IsOverlap(line, rectangle);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingLineAndRectangleShouldReturnFalse()
    {
        var line = new Line(new Point(2, 10), new Point(5, 10));
        var rectangle = new Rectangle(new Point(3, 4), 5, 2);

        var result = LineToRectangleOverlapDetector.IsOverlap(line, rectangle);

        Assert.IsFalse(result);
    }

}
