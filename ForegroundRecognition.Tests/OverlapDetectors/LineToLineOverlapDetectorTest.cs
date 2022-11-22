using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class LineToLineOverlapDetectorTest
{
    [Test]
    public void EqualLinesOverlapShouldReturnTrue()
    {
        var firstLine = new Line(new Point(0, 0), new Point(5, 0));
        var secondLine = new Line(new Point(0, 0), new Point(5, 0));

        var result = LineToLineOverlapDetector.IsOverlap(firstLine, secondLine);

        Assert.IsTrue(result);
    }

    [Test]
    public void CrossLinesOverlapShouldReturnTrue()
    {
        var firstLine = new Line(new Point(0, 0), new Point(5, 5));
        var secondLine = new Line(new Point(0, 5), new Point(5, 0));

        var result = LineToLineOverlapDetector.IsOverlap(firstLine, secondLine);

        Assert.IsTrue(result);
    }

    [Test]
    public void OneSamePointLinesShouldReturnTrue()
    {
        var firstLine = new Line(new Point(0, 0), new Point(5, 5));
        var secondLine = new Line(new Point(5, 5), new Point(10, 10));

        var result = LineToLineOverlapDetector.IsOverlap(firstLine, secondLine);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingLinesShouldReturnFalse()
    {
        var firstLine = new Line(new Point(0, 0), new Point(5, 5));
        var secondLine = new Line(new Point(6, 6), new Point(10, 10));

        var result = LineToLineOverlapDetector.IsOverlap(firstLine, secondLine);

        Assert.IsFalse(result);
    }
}
