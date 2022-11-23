using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.GeometryMath;

internal class PointMathTest
{
    [Test]
    public void IsPointInRectangleShouldReturnTrue()
    {
        var point = new Point(5, 5);
        var rectangle = new Rectangle(new Point(0, 0), 10, 10);

        var result = PointMath.IsPointInRectangle(point, rectangle);

        Assert.True(result);
    }

    [TestCaseSource(nameof(OrientationTestData))]
    public void CalcOrientationShouldPass(Point point1, Point point2, Point point3, Orientation expectedResult)
    {
        var result = PointMath.CalcOrientation(point1, point2, point3);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    private static IEnumerable<TestCaseData> OrientationTestData()
    {
        yield return new TestCaseData(new Point(0, 0), new Point(5, 5), new Point(3, 3), Orientation.Collinear);
        yield return new TestCaseData(new Point(3, 3), new Point(5, 5), new Point(0, 0), Orientation.Collinear);
        yield return new TestCaseData(new Point(0, 0), new Point(3, 3), new Point(5, 5), Orientation.Collinear);
        yield return new TestCaseData(new Point(0, 0), new Point(0, 3), new Point(0, 5), Orientation.Collinear);
        yield return new TestCaseData(new Point(0, 5), new Point(0, 0), new Point(0, 3), Orientation.Collinear);
        yield return new TestCaseData(new Point(0, 3), new Point(0, 5), new Point(0, 0), Orientation.Collinear);
        yield return new TestCaseData(new Point(0, 0), new Point(3, 0), new Point(5, 0), Orientation.Collinear);
        yield return new TestCaseData(new Point(5, 0), new Point(0, 0), new Point(3, 0), Orientation.Collinear);
        yield return new TestCaseData(new Point(3, 0), new Point(5, 0), new Point(0, 0), Orientation.Collinear);

        yield return new TestCaseData(new Point(0, 0), new Point(1, 0), new Point(1, 1), Orientation.CounterClockwise);
        yield return new TestCaseData(new Point(0, 0), new Point(4, 4), new Point(1, 2), Orientation.CounterClockwise);

        yield return new TestCaseData(new Point(1, 2), new Point(4, 4), new Point(0, 0), Orientation.Clockwise);
        yield return new TestCaseData(new Point(0, 0), new Point(0, 1), new Point(1, 1), Orientation.Clockwise);
    }
}

