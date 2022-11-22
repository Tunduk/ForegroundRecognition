using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class TriangleToTriangleOverlapDetector
{
    public static bool IsOverlap(Triangle firstTriangle, Triangle secondTriangle)
    {
        if (LineToLineOverlapDetector.IsOverlap(firstTriangle.FirstPoint, firstTriangle.SecondPoint, secondTriangle.FirstPoint, secondTriangle.SecondPoint) ||
           LineToLineOverlapDetector.IsOverlap(firstTriangle.FirstPoint, firstTriangle.SecondPoint, secondTriangle.SecondPoint, secondTriangle.ThirdPoint) ||
           LineToLineOverlapDetector.IsOverlap(firstTriangle.FirstPoint, firstTriangle.SecondPoint, secondTriangle.ThirdPoint, secondTriangle.FirstPoint) ||
           LineToLineOverlapDetector.IsOverlap(firstTriangle.SecondPoint, firstTriangle.ThirdPoint, secondTriangle.FirstPoint, secondTriangle.SecondPoint) ||
           LineToLineOverlapDetector.IsOverlap(firstTriangle.SecondPoint, firstTriangle.ThirdPoint, secondTriangle.SecondPoint, secondTriangle.ThirdPoint) ||
           LineToLineOverlapDetector.IsOverlap(firstTriangle.SecondPoint, firstTriangle.ThirdPoint, secondTriangle.ThirdPoint, secondTriangle.FirstPoint) ||
           PointMath.IsPointInTriangle(firstTriangle.FirstPoint, secondTriangle) ||
           PointMath.IsPointInTriangle(secondTriangle.FirstPoint, firstTriangle) ||
           PointMath.IsPointInTriangle(secondTriangle.SecondPoint, firstTriangle) ||
           PointMath.IsPointInTriangle(secondTriangle.ThirdPoint, firstTriangle)
        )
            return true;

        return false;
    }


}
