using ForegroundRecognition.GeometryMath;

namespace ForegroundRecognition.Shapes;

public class Line : Shape
{
    public Point StartPoint { get; init; }
    public Point EndPoint { get; init; }

    public override double GetArea() => PointMath.DistanceBeetweenPoints(StartPoint, EndPoint);

    public double Length => PointMath.DistanceBeetweenPoints(StartPoint, EndPoint);

    public Line(Point startPoint, Point endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public override Rectangle GetBoundingBox()
    {
        var minX = Math.Min(StartPoint.X, EndPoint.X);
        var maxX = Math.Max(StartPoint.X, EndPoint.X);
        var minY = Math.Min(StartPoint.Y, EndPoint.Y);
        var maxY = Math.Max(StartPoint.Y, EndPoint.Y);

        var topLeft = new Point(minX, minY);
        var width = maxX - minX;
        var height = maxY - minY;

        return new Rectangle(topLeft, width, height);
    }
}
