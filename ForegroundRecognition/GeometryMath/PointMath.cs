using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.GeometryMath;

internal static class PointMath
{
    public static Orientation CalcOrientation(Point point1, Point point2, Point point3)
    {
        var val = (point2.Y - point1.Y) * (point3.X - point2.X) - (point2.X - point1.X) * (point3.Y - point2.Y);

        if (val == 0) return Orientation.Collinear;

        return (val > 0) ? Orientation.Clockwise : Orientation.CounterClockwise;
    }

    public static double DistanceBeetweenPoints(Point point1, Point point2)
    {
        var xCoordinate = Math.Abs(point1.X - point2.X);
        var yCoordinate = Math.Abs(point1.Y - point2.Y);
        return Math.Sqrt(xCoordinate * xCoordinate + yCoordinate * yCoordinate);
    }

    public static bool IsPointInTriangle(Point point, Triangle triangle)
    {
        var s = (triangle.FirstPoint.X - triangle.ThirdPoint.X) * (point.Y - triangle.ThirdPoint.Y) - (triangle.FirstPoint.Y - triangle.ThirdPoint.Y) * (point.X - triangle.ThirdPoint.X);
        var t = (triangle.SecondPoint.X - triangle.FirstPoint.X) * (point.Y - triangle.FirstPoint.Y) - (triangle.SecondPoint.Y - triangle.FirstPoint.Y) * (point.X - triangle.FirstPoint.X);

        if ((s < 0) != (t < 0) && s != 0 && t != 0)
            return false;

        var d = (triangle.ThirdPoint.X - triangle.SecondPoint.X) * (point.Y - triangle.SecondPoint.Y) - (triangle.ThirdPoint.Y - triangle.SecondPoint.Y) * (point.X - triangle.SecondPoint.X);
        return d == 0 || (d < 0) == (s + t <= 0);
    }

    public static bool IsPointOnLine(Point point, Line line)
    {
        return IsPointOnLine(point, line.StartPoint, line.EndPoint);
    }

    public static bool IsPointOnLine(Point point, Point startPoint, Point endPoint)
    {
        if (point.X <= Math.Max(startPoint.X, endPoint.X) &&
            point.X >= Math.Min(startPoint.X, endPoint.X) &&
            point.Y <= Math.Max(startPoint.Y, endPoint.Y) &&
            point.Y >= Math.Min(startPoint.Y, endPoint.Y)
        )
            return true;

        return false;
    }

    public static bool IsPointInRectangle(Point point, Rectangle rectangle)
    {
        if (point.X >= rectangle.TopLeft.X &&
            point.X <= rectangle.TopLeft.X + rectangle.Width &&
            point.Y >= rectangle.TopLeft.Y &&
            point.Y <= rectangle.TopLeft.Y + rectangle.Height
        )
            return true;
        return false;
    }
}
