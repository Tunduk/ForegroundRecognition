using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class TriangleToLineOverlapDetector
{
    public static bool IsOverlap(Triangle triangle, Line line)
    {
        var edges = triangle.GetEdges();
        foreach (var edge in edges)
        {
            if (LineToLineOverlapDetector.IsOverlap(edge, line))
                return true;
        }

        if (PointMath.IsPointInTriangle(line.StartPoint, triangle) || PointMath.IsPointInTriangle(line.EndPoint, triangle))
            return true;

        return false;
    }
}
