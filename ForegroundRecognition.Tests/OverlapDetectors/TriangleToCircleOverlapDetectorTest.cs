using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class TriangleToCircleOverlapDetectorTest
{
    [Test]
    public void TriangleInsideCircleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(0, 0), new Point(10, 0), new Point(0, 10));
        var circle = new Circle(new Point(2, 2), 1);

        var result = TriangleToCircleOverlapDetector.IsOverlap(triangle, circle);

        Assert.True(result);
    }

    [Test]
    public void CircleInsideTriangleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(5, 2), new Point(7, 2), new Point(6, 4));
        var circle = new Circle(new Point(6, 3), 3);

        var result = TriangleToCircleOverlapDetector.IsOverlap(triangle, circle);

        Assert.True(result);
    }

    [Test]
    public void TriangleBorderingCircleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(3, 1), new Point(3, 5), new Point(0, 3));
        var circle = new Circle(new Point(6, 3), 3);

        var result = TriangleToCircleOverlapDetector.IsOverlap(triangle, circle);

        Assert.True(result);
    }

    [Test]
    public void TriangleCrossCircleShouldReturnTrue()
    {
        var triangle = new Triangle(new Point(1, 5), new Point(11, 5), new Point(6, 10));
        var circle = new Circle(new Point(6, 3), 3);

        var result = TriangleToCircleOverlapDetector.IsOverlap(triangle, circle);

        Assert.True(result);
    }

    [Test]
    public void TriangleNotOverlapCircleShouldReturnFalse()
    {
        var triangle = new Triangle(new Point(1, 5), new Point(11, 5), new Point(6, 10));
        var circle = new Circle(new Point(6, 3), 3);

        var result = TriangleToCircleOverlapDetector.IsOverlap(triangle, circle);

        Assert.True(result);
    }
}
