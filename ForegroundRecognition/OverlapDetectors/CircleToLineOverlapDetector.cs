using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal class CircleToLineOverlapDetector
    {
        public static bool IsOverlap(Circle circle, Line line)
        {
            var x_linear = line.EndPoint.X - line.StartPoint.X;
            var x_constant = line.StartPoint.X - circle.Center.X;
            var y_linear = line.EndPoint.Y - line.StartPoint.Y;
            var y_constant = line.StartPoint.Y - circle.Center.Y;

            var a = x_linear * x_linear + y_linear * y_linear;
            var half_b = x_linear * x_constant + y_linear * y_constant;
            var c = x_constant * x_constant + y_constant * y_constant - circle.Radius * circle.Radius;
            return (
              half_b * half_b >= a * c &&
              (-half_b <= a || c + half_b + half_b + a <= 0) &&
              (half_b <= 0 || c <= 0)
            );
        }
    }
}
