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

        public object Clone()
        {
            return new Point(X, Y);
        }
    }
}
