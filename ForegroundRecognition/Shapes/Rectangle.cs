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
