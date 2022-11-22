using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests.Shapes;

internal class RectangleTest
{
    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    public void TryCreateRectangleOneDimensionIsZeroOrLessShouldThrowArgumentException(double width, double height)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Rectangle(new Point(1, 1), width, height);
        });
    }

    [TestCase(0, 1)]
    [TestCase(1, 0)]
    public void RectangleZeroSideShouldPass(double width, double height)
    {
        Assert.DoesNotThrow(() =>
        {
            new Rectangle(new Point(1, 1), width, height);
        });
    }

    [TestCase(5, 10, 50)]
    [TestCase(6, 7, 42)]
    public void RectangleAreaShouldReturnPass(double width, double height, double expectedArea)
    {
        var rectangle = new Rectangle(new Point(1, 1), width, height);
        var area = rectangle.GetArea();
        Assert.That(area, Is.EqualTo(expectedArea));
    }

    [Test]
    public void RectangleBoundingBoxShouldPass()
    {
        var rectangle = new Rectangle(new Point(10, 10), 20, 30);

        var boundingBox = rectangle.GetBoundingBox();

        Assert.That(boundingBox.Width, Is.EqualTo(rectangle.Width));
        Assert.That(boundingBox.Height, Is.EqualTo(rectangle.Height));
        Assert.That(boundingBox.TopLeft.X, Is.EqualTo(rectangle.TopLeft.X));
        Assert.That(boundingBox.TopLeft.Y, Is.EqualTo(rectangle.TopLeft.Y));
    }
}
