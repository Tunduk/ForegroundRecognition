using ForegroundRecognition.Shapes;
using ForegroundRecognition.GeometryMath;

namespace ForegroundRecognition.OverlapDetectors;

internal static class LineToLineOverlapDetector
{
    public static bool IsOverlap(Line firstShape, Line secondShape)
    {
        return IsOverlap(firstShape.StartPoint, firstShape.EndPoint, secondShape.StartPoint, secondShape.EndPoint);
    }

    public static bool IsOverlap(Point startPoint1, Point endPoint1, Point startPoint2, Point endPoint2)
    {
        var orientation1 = PointMath.CalcOrientation(startPoint1, endPoint1, startPoint2);
        var orientation2 = PointMath.CalcOrientation(startPoint1, endPoint1, endPoint2);
        var orientation3 = PointMath.CalcOrientation(startPoint2, endPoint2, startPoint1);
        var orientation4 = PointMath.CalcOrientation(startPoint2, endPoint2, endPoint1);

        if (orientation1 != orientation2 && orientation3 != orientation4)
            return true;

        if (orientation1 == Orientation.Collinear && PointMath.IsPointOnLine(startPoint2, startPoint1, endPoint1))
            return true;

        if (orientation2 == Orientation.Collinear && PointMath.IsPointOnLine(endPoint2, startPoint1, endPoint1))
            return true;

        if (orientation3 == Orientation.Collinear && PointMath.IsPointOnLine(startPoint1, startPoint2, endPoint2))
            return true;

        if (orientation4 == Orientation.Collinear && PointMath.IsPointOnLine(endPoint1, startPoint2, endPoint2))
            return true;

        return false; 
    }
}
