using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class TriangleToCircleOverlapDetector
{
    public static bool IsOverlap(Triangle triangle, Circle circle)
    {
        if (PointMath.IsPointInTriangle(circle.Center, triangle) ||
            triangle.GetEdges().Any(x => CircleToLineOverlapDetector.IsOverlap(circle, x))
        )
            return true;
        return false;
    }
}
