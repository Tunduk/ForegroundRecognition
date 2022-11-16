namespace ForegroundRecognition.Shapes
{
    public class Rectangle : Shape
    {
        public Point TopLeft { get; init; }
        public double Width { get; init; }
        public double Height { get; init; }

        public Rectangle(Point topLeft, double width, double height)
        {
            if (height < 0 || width < 0)
                throw new ArgumentException();

            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        public override Rectangle GetBoundingBox()
        {
            return new Rectangle((Point)TopLeft.Clone(), Width, Height);
        }
    }
}
