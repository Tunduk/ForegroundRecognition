

using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class RectangleToCircleOverlapDetector
{
    public static bool IsOverlap(Rectangle firstShape, Circle secondShape)
    {
        var Xn = Math.Max(firstShape.TopLeft.X, Math.Min(secondShape.Center.X, firstShape.TopLeft.X + firstShape.Width));
        var Yn = Math.Max(firstShape.TopLeft.Y, Math.Min(secondShape.Center.Y, firstShape.TopLeft.Y + firstShape.Height));

        var Dx = Xn - secondShape.Center.X;
        var Dy = Yn - secondShape.Center.Y;
        return (Dx * Dx + Dy * Dy) <= secondShape.Radius * secondShape.Radius;
    }
}
