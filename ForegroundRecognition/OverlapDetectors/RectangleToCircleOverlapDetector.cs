using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class RectangleToCircleOverlapDetector
{
    public static bool IsOverlap(Rectangle firstShape, Circle secondShape)
    {
        double dx = Math.Abs(secondShape.Center.X - (firstShape.TopLeft.X + firstShape.Width / 2));
        double dy = Math.Abs(secondShape.Center.Y - (firstShape.TopLeft.Y - firstShape.Height / 2));

        if (dx <= 0 || dy <= 0)
            return true;

        return (dx * dx + dy * dy) <= secondShape.Radius * secondShape.Radius;
    }
}
