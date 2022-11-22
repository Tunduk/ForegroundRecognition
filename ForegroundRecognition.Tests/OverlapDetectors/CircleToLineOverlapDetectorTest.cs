using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class CircleToLineOverlapDetectorTest
{
    [Test]
    public void TangentLineShouldReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Line(new Point(5, 15), new Point(15, 15));

        var result = CircleToLineOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingLineShouldReturnFalse()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Line(new Point(5, 20), new Point(15, 20));

        var result = CircleToLineOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsFalse(result);
    }

    [Test]
    public void OneCoordinateInsideCircleShouldReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Line(new Point(7, 10), new Point(7, 0));

        var result = CircleToLineOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineInsideCircleShouldReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Line(new Point(7, 10), new Point(12, 6));

        var result = CircleToLineOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void LineOverlapCoordinatesOutsideCircleShouldReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Line(new Point(0, 0), new Point(15, 15));

        var result = CircleToLineOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }
}
