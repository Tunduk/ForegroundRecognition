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


        // General case 
        if (orientation1 != orientation2 && orientation3 != orientation4)
            return true;

        // Special Cases 
        // p1, q1 and p2 are collinear and p2 lies on segment p1q1 
        if (orientation1 == Orientation.Collinear && PointMath.IsPointOnLine(startPoint2, startPoint1, endPoint1))
            return true;

        // p1, q1 and q2 are collinear and q2 lies on segment p1q1 
        if (orientation2 == Orientation.Collinear && PointMath.IsPointOnLine(endPoint2, startPoint1, endPoint1))
            return true;

        // p2, q2 and p1 are collinear and p1 lies on segment p2q2 
        if (orientation3 == Orientation.Collinear && PointMath.IsPointOnLine(startPoint1, startPoint2, endPoint2))
            return true;

        // p2, q2 and q1 are collinear and q1 lies on segment p2q2 
        if (orientation4 == Orientation.Collinear && PointMath.IsPointOnLine(endPoint1, startPoint2, endPoint2))
            return true;

        return false; // Doesn't fall in any of the above cases 
    }
}
