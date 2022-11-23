using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class RectangleToCircleOverlapDetectorTest
{
    [Test]
    public void RectangleInsideCircleShouldReturnTrue()
    {
        var rectangle = new Rectangle(new Point(5, 4), 2, 2);
        var circle = new Circle(new Point(6, 3), 3);

        var result = RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle);

        Assert.IsTrue(result);
    }

    [Test]
    public void CircleInsideRectanleShouldReturnTrue()
    {
        var rectangle = new Rectangle(new Point(3, 0), 6, 6);
        var circle = new Circle(new Point(6, 3), 2);

        var result = RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle);

        Assert.IsTrue(result);
    }

    [Test]
    public void CircleCenterOnSideOfRectanleShouldReturnTrue()
    {
        var rectangle = new Rectangle(new Point(5, 4), 2, 2);
        var circle = new Circle(new Point(5, 3), 1);

        var result = RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle);

        Assert.IsTrue(result);
    }

    [Test]
    public void CircleBorderingRectanleShouldReturnTrue()
    {
        var rectangle = new Rectangle(new Point(5, 2), 2, 2);
        var circle = new Circle(new Point(4, 3), 1);

        var result = RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle);

        Assert.IsTrue(result);
    }

    [Test]
    public void CircleNotOverlapRectanleShouldReturnFalse()
    {
        var rectangle = new Rectangle(new Point(5, 5), 3, 3);
        var circle = new Circle(new Point(2, 4), 2);

        var result = RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle);

        Assert.IsFalse(result);
    }

    [Test]
    public void RandomOverlapRectanleShouldReturnFalse()
    {
        var rectangle = new Rectangle(new Point(443, 472), 432, 341);
        var circle = new Circle(new Point(186, 393), 288);

        var result = RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle);

        Assert.IsTrue(result);
    }
}
