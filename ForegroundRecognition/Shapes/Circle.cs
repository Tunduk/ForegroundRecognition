namespace ForegroundRecognition.Shapes;

public class Circle : Shape
{
    public double Radius { get; init; }
    public Point Center { get; init; }

    public override double GetArea() => Math.PI * Radius * Radius;

    public Circle(Point center, double radius)
    {
        Radius = radius;
        Center = center;
    }


    public override Rectangle GetBoundingBox()
    {
        var leftTopPoint = new Point(Center.X - Radius, Center.Y - Radius);
        var squareLenght = Radius * 2;
        return new Rectangle(leftTopPoint, squareLenght, squareLenght);
    }
}
