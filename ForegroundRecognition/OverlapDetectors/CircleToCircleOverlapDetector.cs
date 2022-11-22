using ForegroundRecognition.GeometryMath;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors;

internal static class CircleToCircleOverlapDetector
{
    public static bool IsOverlap(Circle firstShape, Circle secondShape)
    {
        var distanceBeetwenCenters = PointMath.DistanceBeetweenPoints(firstShape.Center, secondShape.Center);
        if (distanceBeetwenCenters <= firstShape.Radius + secondShape.Radius)
            return true;

        return false;
    }
}
