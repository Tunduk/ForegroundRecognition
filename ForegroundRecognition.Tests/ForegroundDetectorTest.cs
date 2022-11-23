using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.Tests;

internal class ForegroundDetectorTest
{

    [Test]
    public void SampleTestShouldFindAll()
    {
        var expectedShapes = new Shape[]
        {
            new Rectangle(new Point(334.6,281),134,134),
            new Line(new Point(655.6,45), new Point(665.6,557)),
            new Circle(new Point(188.6,346.5), 48),
            new Rectangle(new Point(293.6,192), 79,40),
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Circle(new Point(241.1,224.5), 47.5),
        };
        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            expectedShapes[5],
            expectedShapes[4],
            expectedShapes[3],
            new Line(new Point(296.6,393), new Point(533.6,393)),
            expectedShapes[2],
            expectedShapes[1],
            expectedShapes[0]
        };

        var result = ForegroundDetector.FindForegroundShapes(shapes);

        CollectionAssert.AreEqual(expectedShapes, result);
    }

    [Test]
    public async Task SampleTestAsyncShouldFindAll()
    {
        var expectedShapes = new Shape[]
        {
            new Rectangle(new Point(334.6,281),134,134),
            new Line(new Point(655.6,45), new Point(665.6,557)),
            new Circle(new Point(188.6,346.5), 48),
            new Rectangle(new Point(293.6,192), 79,40),
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Circle(new Point(241.1,224.5), 47.5),
        };
        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            expectedShapes[5],
            expectedShapes[4],
            expectedShapes[3],
            new Line(new Point(296.6,393), new Point(533.6,393)),
            expectedShapes[2],
            expectedShapes[1],
            expectedShapes[0]
        };

        var resultCollection = new List<Shape>();
        var result = ForegroundDetector.FindForegroundShapesAsync(shapes);
        await foreach (var shape in result)
        {
            resultCollection.Add(shape);
        }

        CollectionAssert.AreEqual(expectedShapes, resultCollection);
    }

    [Test]
    public void SampleTestShouldFindAllMultiThread()
    {
        var expectedShapes = new Shape[]
        {
            new Rectangle(new Point(334.6,281),134,134),
            new Line(new Point(655.6,45), new Point(665.6,557)),
            new Circle(new Point(188.6,346.5), 48),
            new Rectangle(new Point(293.6,192), 79,40),
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Circle(new Point(241.1,224.5), 47.5),
        };
        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            expectedShapes[5],
            expectedShapes[4],
            expectedShapes[3],
            new Line(new Point(296.6,393), new Point(533.6,393)),
            expectedShapes[2],
            expectedShapes[1],
            expectedShapes[0]
        };

        var iterations = 100;

        Thread thread1 = new Thread(new ThreadStart(() =>
        {
            for (int i = 0; i < iterations; i++)
            {
                var result = ForegroundDetector.FindForegroundShapes(shapes);

                CollectionAssert.AreEqual(expectedShapes, result);
            }
        }));
        Thread thread2 = new Thread(new ThreadStart(delegate ()
        {
            for (int i = 0; i < iterations; i++)
            {
                var result = ForegroundDetector.FindForegroundShapes(shapes);

                CollectionAssert.AreEqual(expectedShapes, result);
            }
        }));

        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
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

    [Test]
    public void SampleTestAreaThresholdShouldPass()
    {
        var expectedShapes = new Shape[]
        {
            new Rectangle(new Point(334.6,281),134,134),
            new Circle(new Point(188.6,346.5), 48),
            new Circle(new Point(241.1,224.5), 47.5),

        };

        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            expectedShapes[2],
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Rectangle(new Point(293.6,192), 79,40),
            new Line(new Point(296.6,393), new Point(533.6,393)),
            expectedShapes[1],
            new Line(new Point(655.6,45), new Point(665.6,557)),
            expectedShapes[0]
        };

        var result = ForegroundDetector.FindForegroundShapes(shapes, 6000.0);

        Assert.That(result.Count(), Is.EqualTo(3));
        foreach (var foregroundShape in result)
        {
            Assert.That(expectedShapes.Contains(foregroundShape));
        }
    }

    [TestCase(2)]
    [TestCase(4)]
    [TestCase(0)]
    public async Task SampleTestRestrictedCountAsyncShouldPass(int maxCount)
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

        var resultCollection = new List<Shape>();
        var result = ForegroundDetector.FindForegroundShapesAsync(shapes, maxCount);
        await foreach (var shape in result)
        {
            resultCollection.Add(shape);
        }
        Assert.That(resultCollection.Count(), Is.EqualTo(maxCount == 0 ? 6 : maxCount));
    }

    [Test]
    public async Task SampleTestAreaThresholdAsyncShouldPass()
    {
        var expectedShapes = new Shape[]
        {
            new Rectangle(new Point(334.6,281),134,134),
            new Circle(new Point(188.6,346.5), 48),
            new Circle(new Point(241.1,224.5), 47.5),

        };

        var shapes = new Shape[]
        {
            new Line(new Point(213.6,97), new Point(327.6,154)),
            new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
            new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
            new Rectangle(new Point(58.6,126), 505,348),
            new Rectangle(new Point(78.6,65), 174,118),
            expectedShapes[2],
            new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
            new Rectangle(new Point(293.6,192), 79,40),
            new Line(new Point(296.6,393), new Point(533.6,393)),
            expectedShapes[1],
            new Line(new Point(655.6,45), new Point(665.6,557)),
            expectedShapes[0]
        };
        var resultCollection = new List<Shape>();
        var result = ForegroundDetector.FindForegroundShapesAsync(shapes, 6000.0);
        await foreach (var shape in result)
        {
            resultCollection.Add(shape);
        }

        CollectionAssert.AreEqual(expectedShapes, resultCollection);
    }
}
