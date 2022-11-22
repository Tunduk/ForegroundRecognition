using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class CircleToCircleOverlapDetectorTest
{
    [Test]
    public void EqualsCirclesOverlapShouldReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Circle(new Point(10, 10), 5);

        var result = CircleToCircleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void PartiallyOverlappingCirclesShoulReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Circle(new Point(5, 5), 5);

        var result = CircleToCircleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotOverlappingCirclesShoulReturnFalse()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Circle(new Point(20, 20), 5);

        var result = CircleToCircleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsFalse(result);
    }

    [Test]
    public void BorderingCirclesShoulReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 5);
        var secondCircle = new Circle(new Point(20, 10), 5);

        var result = CircleToCircleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }

    [Test]
    public void OneInsideAnotherShoulReturnTrue()
    {
        var firstCircle = new Circle(new Point(10, 10), 100);
        var secondCircle = new Circle(new Point(10, 10), 5);

        var result = CircleToCircleOverlapDetector.IsOverlap(firstCircle, secondCircle);

        Assert.IsTrue(result);
    }
}
