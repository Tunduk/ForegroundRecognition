using ForegroundRecognition.Shapes;

namespace ForegroundRecognition
{
    public class Point : ICloneable
    {
        public double X { get; init; }
        public double Y { get; init; }
        public Point(double x, double y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentException();
            X = x;
            Y = y;
        }

        public double CalculateDistance(Point p)
        {
            var xCoordinate = Math.Abs(X - p.X);
            var yCoordinate = Math.Abs(Y - p.Y);
            return Math.Sqrt(xCoordinate * xCoordinate + yCoordinate * yCoordinate);
        }

        // Given three collinear points p, q, r, the function checks if 
        // point q lies on line segment 'pr' 
        //Point p, Point q, Point r
        public bool IsOnLine(Line line)
        {
            if (X <= Math.Max(line.StartPoint.X, line.EndPoint.X) &&
                X >= Math.Min(line.StartPoint.X, line.EndPoint.X) &&
                Y <= Math.Max(line.StartPoint.Y, line.EndPoint.Y) &&
                Y >= Math.Min(line.StartPoint.Y, line.EndPoint.Y)
            )
                return true;

            return false;
        }

        public object Clone()
        {
            return new Point(X, Y);
        }
    }
}
