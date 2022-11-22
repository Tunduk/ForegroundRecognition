

namespace ForegroundRecognition.Shapes;

public abstract class Shape
{
    public abstract Rectangle GetBoundingBox();

    public abstract double Area { get; }

 
}
