using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class ShapeToShapeOverlapDetector
{
    public static bool IsOverlap(Shape firstShape, Shape secondShape)
    {
        return (firstShape, secondShape) switch
        {
            (Rectangle firstRectanlge, Rectangle secondRectangle) => RectangleToRectangleOverlapDetector.IsOverlap(firstRectanlge, secondRectangle),
            (Circle firstCircle, Circle secondCircle) => CircleToCircleOverlapDetector.IsOverlap(firstCircle, secondCircle),
            (Line firstLine, Line secondLine) => LineToLineOverlapDetector.IsOverlap(firstLine, secondLine),
            (Rectangle rectangle, Circle circle) => RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle),
            (Circle circle, Rectangle rectangle) => RectangleToCircleOverlapDetector.IsOverlap(rectangle, circle),
            (Circle circle, Line line) => CircleToLineOverlapDetector.IsOverlap(circle, line),
            (Line line, Circle circle) => CircleToLineOverlapDetector.IsOverlap(circle, line),
            (Triangle triangle, Line line) => TriangleToLineOverlapDetector.IsOverlap(triangle, line),
            (Line line, Triangle triangle) => TriangleToLineOverlapDetector.IsOverlap(triangle, line),
            (Triangle firstTriangle, Triangle secondTriangle) => TriangleToTriangleOverlapDetector.IsOverlap(firstTriangle, secondTriangle),
            (Rectangle rectangle, Line line) => LineToRectangleOverlapDetector.IsOverlap(line, rectangle),
            (Line line, Rectangle rectangle) => LineToRectangleOverlapDetector.IsOverlap(line, rectangle),
            (Triangle triangle, Circle circle) => TriangleToCircleOverlapDetector.IsOverlap(triangle, circle),
            (Circle circle, Triangle triangle) => TriangleToCircleOverlapDetector.IsOverlap(triangle, circle),
            (Triangle triangle, Rectangle rectangle) => TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle),
            (Rectangle rectangle, Triangle triangle) => TriangleToRectangleOverlapDetector.IsOverlap(triangle, rectangle),
            _ => throw new ArgumentException("Not supported shapes")
        };
    }
}
