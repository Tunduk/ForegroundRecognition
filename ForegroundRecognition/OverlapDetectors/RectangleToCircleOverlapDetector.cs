

using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal static class RectangleToCircleOverlapDetector
    {
        public static bool IsOverlap(Rectangle firstShape, Circle secondShape)
        {
            if (IsPointInRectangle(secondShape.Center, firstShape) ||
                firstShape.TopLeft.CalculateDistance(secondShape.Center) <= secondShape.Radius ||
                new Point(firstShape.TopLeft.X + firstShape.Width, firstShape.TopLeft.Y).CalculateDistance(secondShape.Center) <= secondShape.Radius ||
                new Point(firstShape.TopLeft.X + firstShape.Width, firstShape.TopLeft.Y + firstShape.Height).CalculateDistance(secondShape.Center) <= secondShape.Radius ||
                new Point(firstShape.TopLeft.X, firstShape.TopLeft.Y + firstShape.Height).CalculateDistance(secondShape.Center) <= secondShape.Radius
            )
                return true;
            return false;
        }

        private static bool IsPointInRectangle(Point point, Rectangle rectange)
        {
            if (point.X > rectange.TopLeft.X &&
                point.X < rectange.TopLeft.X + rectange.Width &&
                point.Y > rectange.TopLeft.Y &&
                point.Y < rectange.TopLeft.Y + rectange.Height
            )
                return true;

            return false;
        }
    }
}
