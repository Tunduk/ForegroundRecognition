using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;


namespace ForegroundRecognition.OverlapDetectors;

internal static class TriangleToRectangleOverlapDetector
{
    public static bool IsOverlap(Triangle triangle, Rectangle rectangle)
    {
        var edges = rectangle.GetEdges();
        if (triangle.GetPoints().Any(x => PointMath.IsPointInRectangle(x, rectangle)) ||
            triangle.GetEdges().Any(x => edges.Any(edge => LineToLineOverlapDetector.IsOverlap(x, edge)))
        )
            return true;

        return false;
    }
}
