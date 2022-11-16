using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.OverlapDetectors
{
    internal interface IOverlapDetector<T, U> where T : Shape where U : Shape
    {
        bool IsOverlap(T firstShape, U secondShape);
    }
}
