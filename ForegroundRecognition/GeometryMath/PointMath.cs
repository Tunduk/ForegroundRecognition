namespace ForegroundRecognition.GeometryMath
{
    internal static class PointMath
    {
        public static Orientation CalcOrientation(Point point1, Point point2, Point point3)
        {
            var val = (point2.Y - point1.Y) * (point3.X - point2.X) - (point2.X - point1.X) * (point3.Y - point2.Y);

            if (val == 0) return Orientation.Collinear;

            return (val > 0) ? Orientation.Clockwise : Orientation.CounterClockwise;
        }
    }
}
