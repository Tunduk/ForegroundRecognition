using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal static class CircleToCircleOverlapDetector 
    {
        public static bool IsOverlap(Circle firstShape, Circle secondShape)
        {
            var distanceBeetwenCenters = firstShape.Center.CalculateDistance(secondShape.Center);
            if (distanceBeetwenCenters < firstShape.Radius + secondShape.Radius)
                return true;

            return false;
        }
    }
}
