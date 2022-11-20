using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal static class LineToRectangleOverlapDetector
    {
        public static bool IsOverlap(Line line, Rectangle rectangle)
        {
            if (PointMath.IsPointInRectangle(line.StartPoint, rectangle) ||
                PointMath.IsPointInRectangle(line.EndPoint, rectangle) ||
                rectangle.GetEdges().Any(x => LineToLineOverlapDetector.IsOverlap(x, line))
            )
                return true;
            return false;
        }


    }
}
