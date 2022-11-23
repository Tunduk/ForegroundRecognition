using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests;

internal class ForegroundDetectorTest
{

    [Test]
    public void SampleTestShouldFindAll()
    {
        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            new Circle(new Point(241.1,224.5), 47.5),
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Rectangle(new Point(293.6,192), 79,40),
            new Line(new Point(296.6,393), new Point(533.6,393)),
            new Circle(new Point(188.6,346.5), 48),
            new Line(new Point(655.6,45), new Point(665.6,557)),
            new Rectangle(new Point(334.6,281),134,134)
        };

        var result = ForegroundDetector.FindForegroundShapes(shapes.ToArray());

        Assert.That(result.Count(), Is.EqualTo(6));
    }

    [TestCase(2)]
    [TestCase(4)]
    [TestCase(0)]
    public void SampleTestRestrictedCountShouldPass(int maxCount)
    {
        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            new Circle(new Point(241.1,224.5), 47.5),
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Rectangle(new Point(293.6,192), 79,40),
            new Line(new Point(296.6,393), new Point(533.6,393)),
            new Circle(new Point(188.6,346.5), 48),
            new Line(new Point(655.6,45), new Point(665.6,557)),
            new Rectangle(new Point(334.6,281),134,134)
        };

        var result = ForegroundDetector.FindForegroundShapes(shapes, maxCount);

        Assert.That(result.Count(), Is.EqualTo(maxCount == 0 ? 6 : maxCount));
    }

    [TestCase(2)]
    [TestCase(4)]
    [TestCase(0)]
    public void SampleTestAreaThresholdShouldPass(double maxArea)
    {
        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            new Circle(new Point(241.1,224.5), 47.5),
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Rectangle(new Point(293.6,192), 79,40),
            new Line(new Point(296.6,393), new Point(533.6,393)),
            new Circle(new Point(188.6,346.5), 48),
            new Line(new Point(655.6,45), new Point(665.6,557)),
            new Rectangle(new Point(334.6,281),134,134)
        };

        var result = ForegroundDetector.FindForegroundShapes(shapes, maxCount);

        Assert.That(result.Count(), Is.EqualTo(maxCount == 0 ? 6 : maxCount));
    }


}
