using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal class CircleToCircleOverlapDetector : IOverlapDetector<Circle, Circle>
    {
        public bool IsOverlap(Circle firstShape, Circle secondShape)
        {
            var distanceBeetwenCenters = firstShape.Center.CalculateDistance(secondShape.Center);
            if (distanceBeetwenCenters < firstShape.Radius + secondShape.Radius)
                return true;

            return false;
        }
    }
}
