using ForegroundRecognition.Shapes;
using ForegroundRecognition.GeometryMath;

namespace ForegroundRecognition.OverlapDetectors
{
    internal static class LineToLineOverlapDetector
    {
        public static bool IsOverlap(Line firstShape, Line secondShape)
        {
            var orientation1 = PointMath.CalcOrientation(firstShape.StartPoint, firstShape.EndPoint, secondShape.StartPoint);
            var orientation2 = PointMath.CalcOrientation(firstShape.StartPoint, firstShape.EndPoint, secondShape.EndPoint);
            var orientation3 = PointMath.CalcOrientation(secondShape.StartPoint, secondShape.EndPoint, firstShape.StartPoint);
            var orientation4 = PointMath.CalcOrientation(secondShape.StartPoint, secondShape.EndPoint, firstShape.EndPoint);


            // General case 
            if (orientation1 != orientation2 && orientation3 != orientation4)
                return true;

            // Special Cases 
            // p1, q1 and p2 are collinear and p2 lies on segment p1q1 
            if (orientation1 == Orientation.Collinear && secondShape.StartPoint.IsOnLine(firstShape))
                return true;

            // p1, q1 and q2 are collinear and q2 lies on segment p1q1 
            if (orientation2 == Orientation.Collinear && secondShape.EndPoint.IsOnLine(firstShape))
                return true;

            // p2, q2 and p1 are collinear and p1 lies on segment p2q2 
            if (orientation3 == Orientation.Collinear && firstShape.StartPoint.IsOnLine(secondShape))
                return true;

            // p2, q2 and q1 are collinear and q1 lies on segment p2q2 
            if (orientation4 == Orientation.Collinear && firstShape.EndPoint.IsOnLine(secondShape))
                return true;

            return false; // Doesn't fall in any of the above cases 
        }
    }
}
