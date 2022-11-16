namespace ForegroundRecognition.Shapes
{
    public class Triangle : Shape
    {
        public Point FirstPoint { get; init; }
        public Point SecondPoint { get; init; }
        public Point ThirdPoint { get; init; }

        public override double Area => CalculateArea();

        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
        }

        public override Rectangle GetBoundingBox()
        {
            var minX = Math.Min(Math.Min(FirstPoint.X, SecondPoint.X), ThirdPoint.X);
            var minY = Math.Min(Math.Min(FirstPoint.Y, SecondPoint.Y), ThirdPoint.Y);
            var maxX = Math.Max(Math.Max(FirstPoint.X, SecondPoint.X), ThirdPoint.X);
            var maxY = Math.Max(Math.Max(FirstPoint.Y, SecondPoint.Y), ThirdPoint.Y);

            var topLeft = new Point(minX, minY);
            var width = maxX - minX;
            var height = maxY - minY;

            return new Rectangle(topLeft, width, height);
        }

        private double CalculateArea()
        {
            return 0.5 * Math.Abs(
                FirstPoint.X * (SecondPoint.Y - ThirdPoint.Y) +
                SecondPoint.X * (ThirdPoint.Y - FirstPoint.Y) +
                ThirdPoint.X * (FirstPoint.Y - SecondPoint.Y)
            );
        }
    }
}
