using ForegroundRecognition.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForegroundRecognition.Visualize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Point? dragStart = null;
        private readonly Dictionary<System.Windows.Shapes.Shape, Shapes.Shape> _shapes = new Dictionary<System.Windows.Shapes.Shape, Shapes.Shape>();
        public MainWindow()
        {

            InitializeComponent();

            var shapes = new Shapes.Shape[]
            {
                new Shapes.Line(new Point(213.6,97), new Point(327.6,154)),
                new Triangle(new Point(250.3, 300.1), new Point(400.34,200.34), new Point(100.56, 150.78)),
                new Triangle(new Point(340.1,500.1), new Point(500.4, 600.34), new Point(400.56, 450.78)),
                new Shapes.Rectangle(new Point(58.6,126), 505,348),
                new Shapes.Rectangle(new Point(78.6,65), 174,118),
                new Circle(new Point(241.1,224.5), 47.5),
                new Triangle(new Point(50.3, 86.1), new Point(100.34, 82.34), new Point(34.56, 56.78)),
                new Shapes.Rectangle(new Point(293.6,192), 79,40),
                new Shapes.Line(new Point(296.6,393), new Point(533.6,280)),
                new Circle(new Point(188.6,346.5), 48),
                new Shapes.Line(new Point(655.6,45), new Point(665.6,557)),
                new Shapes.Rectangle(new Point(334.6,281),134,134)
            };

            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Shapes.Rectangle:
                        {
                            DrawRectangle((Shapes.Rectangle)shape, MainCanvas);
                            break;
                        }
                    case Shapes.Line:
                        {
                            DrawLine((Shapes.Line)shape, MainCanvas);
                            break;
                        }
                    case Shapes.Triangle:
                        {
                            DrawTriange((Shapes.Triangle)shape, MainCanvas);
                            break;
                        }
                    case Shapes.Circle:
                        {
                            DrawCircle((Circle)shape, MainCanvas);
                            break;
                        }
                }
            }
        }

        private void MouseDown(object sender, MouseEventArgs args)
        {
            var element = (UIElement)sender;
            dragStart = args.GetPosition(element);
            element.CaptureMouse();
        }

        private void MouseMove(object sender, MouseEventArgs args)
        {

            if (dragStart != null && args.LeftButton == MouseButtonState.Pressed)
            {
                var element = (UIElement)sender;
                var p2 = args.GetPosition(MainCanvas);
                Canvas.SetLeft(element, p2.X - dragStart.Value.X);
                Canvas.SetTop(element, p2.Y - dragStart.Value.Y);
            }

        }
        private void EnableDrag(UIElement element)
        {

            element.MouseDown += MouseDown;
            element.MouseMove += MouseMove;
            element.MouseUp += MouseUp;

        }

        private void MouseUp(object sender, MouseEventArgs args)
        {
            var element = (UIElement)sender;
            dragStart = null;
            UpdateShape((System.Windows.Shapes.Shape)sender);
            element.ReleaseMouseCapture();
        }

        private void DrawTriange(Triangle triangle, Canvas canvas)
        {
            var points = new PointCollection
            {
                new System.Windows.Point(triangle.FirstPoint.X, triangle.FirstPoint.Y),
                new System.Windows.Point(triangle.SecondPoint.X, triangle.SecondPoint.Y),
                new System.Windows.Point(triangle.ThirdPoint.X, triangle.ThirdPoint.Y),
            };
            var uiTriangle = new System.Windows.Shapes.Polygon
            {

                Fill = Brushes.White,
                Stroke = Brushes.Red,
                StrokeThickness = 1,
                Cursor = Cursors.Hand,
                Points = points
            };
            EnableDrag(uiTriangle);
            _shapes.Add(uiTriangle, triangle);
            canvas.Children.Add(uiTriangle);

        }
        private void DrawCircle(Circle circle, Canvas canvas)
        {
            var ellipse = new Ellipse
            {
                Width = circle.Radius * 2,
                Height = circle.Radius * 2,
                Fill = Brushes.White,
                Stroke = Brushes.Red,
                StrokeThickness = 1,
                Cursor = Cursors.Hand,

            };
            EnableDrag(ellipse);
            canvas.Children.Add(ellipse);
            _shapes.Add(ellipse, circle);
            Canvas.SetLeft(ellipse, circle.Center.X - circle.Radius);
            Canvas.SetTop(ellipse, circle.Center.Y - circle.Radius);
        }

        private void DrawRectangle(Shapes.Rectangle rectangle, Canvas canvas)
        {
            var rect = new System.Windows.Shapes.Rectangle
            {
                Width = rectangle.Width,
                Height = rectangle.Height,
                Fill = Brushes.White,
                Stroke = Brushes.Red,
                StrokeThickness = 1,
                Cursor = Cursors.Hand,

            };
            EnableDrag(rect);
            canvas.Children.Add(rect);
            _shapes.Add(rect, rectangle);
            Canvas.SetLeft(rect, rectangle.TopLeft.X);
            Canvas.SetTop(rect, rectangle.TopLeft.Y);
        }

        private void DrawLine(Shapes.Line line, Canvas canvas)
        {
            var rect = new System.Windows.Shapes.Line
            {
                X1 = line.StartPoint.X,
                X2 = line.EndPoint.X,
                Y1 = line.StartPoint.Y,
                Y2 = line.EndPoint.Y,
                Fill = Brushes.White,
                Stroke = Brushes.Red,
                StrokeThickness = 1,
                Cursor = Cursors.Hand,

            };
            EnableDrag(rect);
            _shapes.Add(rect, line);
            canvas.Children.Add(rect);
        }

        private void UpdateShape(System.Windows.Shapes.Shape uiShape)
        {
            //TODO Fix double access
            var shape = _shapes[uiShape];
            switch (shape)
            {
                case Shapes.Rectangle:
                    {
                        _shapes[uiShape] = CreateRectangleFromUi((System.Windows.Shapes.Rectangle)uiShape);
                        break;
                    }
                case Shapes.Line:
                    {
                        _shapes[uiShape] = CreateLineFromUi((System.Windows.Shapes.Line)uiShape);
                        break;
                    }
                case Shapes.Triangle:
                    {
                        _shapes[uiShape] = CreateTriangleFromUi((Polygon)uiShape);
                        break;
                    }
                case Shapes.Circle:
                    {
                        _shapes[uiShape] = CreateCircleFromUi((Ellipse)uiShape);
                        break;
                    }
            }
        }

        private Triangle CreateTriangleFromUi(Polygon uiTriangle)
        {
            var offsetX = Canvas.GetLeft(uiTriangle);
            var offsetY = Canvas.GetTop(uiTriangle);
            var points = uiTriangle.Points;
            return new Triangle(
                new Point(points[0].X+offsetX, points[0].Y+offsetY),
                new Point(points[1].X+offsetX, points[1].Y+offsetY),
                new Point(points[2].X+offsetX, points[2].Y+offsetY)
            );
        }
        private Circle CreateCircleFromUi(Ellipse uiCircle)
        {
            return new Circle(
                new Point(Canvas.GetLeft(uiCircle) + uiCircle.Height / 2, Canvas.GetTop(uiCircle) + uiCircle.Height / 2),
                uiCircle.Height/2
            );
        }
        private Shapes.Rectangle CreateRectangleFromUi(System.Windows.Shapes.Rectangle uiRectangle)
        {
            return new Shapes.Rectangle(new Point(Canvas.GetLeft(uiRectangle), Canvas.GetTop(uiRectangle)),

                uiRectangle.Width,
                uiRectangle.Height
                );

        }
        private Shapes.Line CreateLineFromUi(System.Windows.Shapes.Line uiLine)
        {
            return new Shapes.Line(new Point(uiLine.X1, uiLine.Y1), new Point(uiLine.X2, uiLine.Y2));
        }

        private void CheckForegroundClick(object sender, RoutedEventArgs e)
        {
            var foregroundDetector = new ForegroundDetector();
            var foregroundShapes = foregroundDetector.FindForegroundShapes(_shapes.Values.Reverse().ToArray());
            var reversed = _shapes.ToDictionary(x => x.Value, x => x.Key);
            foreach(var shape in _shapes.Keys)
            {
                shape.Fill = Brushes.White;
            }
            foreach(var foregroundShape in foregroundShapes ) 
            {
                reversed[foregroundShape].Fill = Brushes.Green;
            }
        }
    }
}
