namespace ForegroundRecognition.Shapes
{
    public class Rectangle : Shape
    {
        public Point TopLeft { get; init; }
        public double Width { get; init; }
        public double Height { get; init; }

        public override double Area => Width * Height;

        public Rectangle(Point topLeft, double width, double height)
        {
            if (height < 0 || width < 0)
                throw new ArgumentException();

            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        public IEnumerable<Line> GetEdges()
        {
            var topRight = new Point(TopLeft.X, TopLeft.Y + Width);
            var bottomRight = new Point(TopLeft.X + Width, TopLeft.Y + Height);
            var bottomLeft = new Point(TopLeft.X, TopLeft.Y + Height);
            yield return new Line(TopLeft, topRight);
            yield return new Line(topRight, bottomRight);
            yield return new Line(bottomRight, bottomLeft);
            yield return new Line(bottomLeft, TopLeft);
        }

        //public override Point GetCenter()
        //{
        //    var centerX = TopLeft.X + Width / 2;
        //    var centerY = TopLeft.Y + Height / 2;
        //    return new Point(centerX, centerY);
        //}

        public override Rectangle GetBoundingBox()
        {
            return new Rectangle((Point)TopLeft.Clone(), Width, Height);
        }
    }
}
