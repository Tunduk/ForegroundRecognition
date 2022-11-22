using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class RectangleToRectangleOverlapDetectorTest
{
    [Test]
    public void EqualsRectanglesOverlapShouldReturnTrue()
    {
        var rectangle1 = new Rectangle(new Point(1, 1), 10, 10);
        var rectangle2 = new Rectangle(new Point(1, 1), 10, 10);

        var result = RectangleToRectangleOverlapDetector.IsOverlap(rectangle1, rectangle2);

        Assert.IsTrue(result);
    }

    [Test]
    public void PartiallyOverlappingRectanglesShoulReturnTrue()
    {
        var rectangle1 = new Rectangle(new Point(1, 1), 10, 10);
        var rectangle2 = new Rectangle(new Point(5, 5), 10, 10);

        var result = RectangleToRectangleOverlapDetector.IsOverlap(rectangle1, rectangle2);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingRectanglesShoulReturnFalse()
    {
        var rectangle1 = new Rectangle(new Point(1, 1), 10, 10);
        var rectangle2 = new Rectangle(new Point(20, 20), 10, 10);

        var result = RectangleToRectangleOverlapDetector.IsOverlap(rectangle1, rectangle2);

        Assert.IsFalse(result);
    }

    [Test]
    public void BorderingRectanglesShoulReturnFalse()
    {
        var rectangle1 = new Rectangle(new Point(1, 1), 10, 10);
        var rectangle2 = new Rectangle(new Point(11, 1), 10, 10);

        var result = RectangleToRectangleOverlapDetector.IsOverlap(rectangle1, rectangle2);

        Assert.IsFalse(result);
    }

    [Test]
    public void OneInsideAnotherShoulReturnFalse()
    {
        var rectangle1 = new Rectangle(new Point(1, 1), 100, 100);
        var rectangle2 = new Rectangle(new Point(11, 1), 10, 10);

        var result = RectangleToRectangleOverlapDetector.IsOverlap(rectangle1, rectangle2);

        Assert.IsTrue(result);
    }
}
