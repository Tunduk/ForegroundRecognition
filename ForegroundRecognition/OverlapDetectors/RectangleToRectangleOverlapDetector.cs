using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal static class RectangleToRectangleOverlapDetector
    {
        public static bool IsOverlap(Rectangle firstShape, Rectangle secondShape)
        {
            return firstShape.TopLeft.X < (secondShape.TopLeft.X + secondShape.Width) &&
                   (firstShape.TopLeft.X + firstShape.Width) > secondShape.TopLeft.X &&
                   firstShape.TopLeft.Y < (secondShape.TopLeft.Y + secondShape.Height) &&
                   (firstShape.TopLeft.Y + firstShape.Height) > secondShape.TopLeft.Y;
        }
    }
}
