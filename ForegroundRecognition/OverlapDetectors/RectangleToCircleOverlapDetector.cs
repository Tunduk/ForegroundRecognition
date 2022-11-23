using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class RectangleToCircleOverlapDetector
{
    public static bool IsOverlap(Rectangle firstShape, Circle secondShape)
    {
        var DeltaX = secondShape.Center.X - Math.Max(firstShape.TopLeft.X, Math.Min(secondShape.Center.X, firstShape.TopLeft.X + firstShape.Width));
        var DeltaY = secondShape.Center.Y - Math.Max(firstShape.TopLeft.Y, Math.Min(secondShape.Center.Y, firstShape.TopLeft.Y + firstShape.Height));
        return (DeltaX * DeltaX + DeltaY * DeltaY) <= (secondShape.Radius * secondShape.Radius);
    }
}
