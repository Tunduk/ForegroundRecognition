using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
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
                _ => throw new NotImplementedException()
            };
        }
    }
}
