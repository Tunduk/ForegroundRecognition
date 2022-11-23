# ForegroundRecognition
## Design approach
I decided to use a simple brute-force algorithm for foreground recognition. Algorithm complexity is not very good, but it works well for a small number of shapes. Immutable classes and no state leads to thread safety. Overlap detectors for each pair of shape is easy to extend for adding new shapes or algorithm swap. 

## Projects in solution
 - ForegroundRecognition - main library with whole alghoritm
 - ForegroundRecognition.Tests - tests for main library
 - ForegroundRecognition.Generator - library for creating random set of shapes
 - ForegroundRecognition.Visualize - Simple WPF application for testing purposes and example of usage. There are some useful features (shapes can be dragged by left mouse hold, buttons for testing sync and async foreground recognition, and a random set of shapes in the amount of 5 could be generated)

## Strong features
- Thread safety
- Easy use of async version
- Pretty simple way to add support for new shapes

## Weak features
- Algorithm complexity. I think I could use something like the Quadtree structure to reduce the number of compartments, but I decided not to overengineer. 
- To add support for the new shape you have to write a lot of new overlap detectors and this number will depend on the current number of the supported shapes. The overlap detectors are pretty simple and could reuse each other but when the number of supported shapes will be 10, for example, it could be a problem. 
- There is a way to reduce the number of overlap detectors using the separating axis theorem but again, I decided not to overengineer
- Parallel version of algorithm could be written

## Example of usage
```cs
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

var result = ForegroundDetector.FindForegroundShapes(shapes);
```

