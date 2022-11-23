using ForegroundRecognition.Shapes;

namespace ForegroundRecognition.RandomGenerator;

public static class ShapesRandomGenerator
{
    private static readonly Random Random = new Random();

    public static IEnumerable<Shape> GetRandomSet(int maxCount)
    {
        for (var i = 0; i < maxCount; i++)
        {
            yield return GetRandomShape();
        }
    }

    private static Shape GetRandomShape()
    {
        var number = Random.Next(0, 4);
        return number switch
        {
            0 => GetRandomCircle(),
            1 => GetRandomTriangle(),
            2 => GetRandomRectangle(),
            3 => GetRandomLine(),
            _ => throw new NotImplementedException()
        };
    }

    public static Triangle GetRandomTriangle()
    {
        return new Triangle(GetRandomPoint(), GetRandomPoint(), GetRandomPoint());
    }

    public static Circle GetRandomCircle()
    {
        return new Circle(GetRandomPoint(), GetRandomNumber());
    }
    public static Rectangle GetRandomRectangle()
    {
        return new Rectangle(GetRandomPoint(), GetRandomNumber(), GetRandomNumber());
    }
    public static Line GetRandomLine()
    {
        return new Line(GetRandomPoint(), GetRandomPoint());
    }

    private static double GetRandomNumber()
    {
        return Random.Next(1, 500);
    }

    private static Point GetRandomPoint()
    {
        return new Point(GetRandomNumber(), GetRandomNumber());
    }
}






