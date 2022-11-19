using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition
{
    public class ForegroundDetector
    {
        private readonly static IOverlapDetector<Rectangle, Rectangle> _boundingBoxDetector = new RectangleToRectangleOverlapDetector();
        public IEnumerable<Shape> FindForegroundShapes(IReadOnlyCollection<Shape> shapes)
        {
            return FindForegroundShapesInternal(shapes, int.MaxValue, 0);
        }

        public IEnumerable<Shape> FindForegroundShapes(IReadOnlyCollection<Shape> shapes, double minimalArea)
        {
            return FindForegroundShapesInternal(shapes, int.MaxValue, 0);
        }

        public IEnumerable<Shape> FindForegroundShapes(IReadOnlyCollection<Shape> shapes, int maxCount)
        {
            return FindForegroundShapesInternal(shapes, maxCount, 0);
        }

        public IEnumerable<Shape> FindForegroundShapes(IReadOnlyCollection<Shape> shapes, int maxCount, double minimalArea)
        {
            return FindForegroundShapesInternal(shapes, maxCount, minimalArea);
        }

        private IEnumerable<Shape> FindForegroundShapesInternal(IReadOnlyCollection<Shape> shapes, int maxCount, double minimalArea)
        {
            var foregroundShapes = new Dictionary<int, Shape>();

            var shapesArray = shapes.ToArray();
            foregroundShapes.Add(0, shapesArray[0]);
            var allPositions = Enumerable.Range(0, shapesArray.Length);
            for (var i = 1; i < shapesArray.Length; i++)
            {
                var shape = shapesArray[i];
                var shapeBoundingBox = shape.GetBoundingBox();
                var isForegound = true;
                foreach (var foregoundShape in foregroundShapes.Values)
                {
                    if (_boundingBoxDetector.IsOverlap(shapeBoundingBox, foregoundShape.GetBoundingBox()))
                    {
                        if (shape is Circle && foregoundShape is Circle)
                        {
                            var circleToCircle = new CircleToCircleOverlapDetector();
                            if (circleToCircle.IsOverlap((Circle)shape, (Circle)foregoundShape))
                            {
                                isForegound = false;
                            }
                        }
                        else if (shape is Rectangle && foregoundShape is Circle)
                        {
                            var rectangleToCircleDetector = new RectangleToCircleOverlapDetector();
                            if (rectangleToCircleDetector.IsOverlap((Rectangle)shape, (Circle)foregoundShape))
                            {
                                isForegound = false;
                            }
                        }
                        else if (shape is Circle && foregoundShape is Rectangle)
                        {
                            var rectangleToCircleDetector = new RectangleToCircleOverlapDetector();
                            if (rectangleToCircleDetector.IsOverlap((Rectangle)foregoundShape, (Circle)shape))
                            {
                                isForegound = false;
                            }
                        }
                        else
                        {
                            isForegound = false;
                        }
                        break;
                        //TODO add precise
                    }
                }
                if (isForegound)
                    //all top and not foreground
                    foreach (var position in allPositions.Except(foregroundShapes.Keys).Except(Enumerable.Range(i, shapesArray.Length)))
                    {
                        if (_boundingBoxDetector.IsOverlap(shapeBoundingBox, shapesArray[position].GetBoundingBox()))
                        {
                            if (shape is Circle && shapesArray[position] is Circle)
                            {
                                var circleToCircle = new CircleToCircleOverlapDetector();
                                if (circleToCircle.IsOverlap((Circle)shape, (Circle)shapesArray[position]))
                                {
                                    isForegound = false;
                                }
                            }
                            else if (shape is Rectangle && shapesArray[position] is Circle)
                            {
                                var rectangleToCircleDetector = new RectangleToCircleOverlapDetector();
                                if (rectangleToCircleDetector.IsOverlap((Rectangle)shape, (Circle)shapesArray[position]))
                                {
                                    isForegound = false;
                                }
                            }
                            else if (shape is Circle && shapesArray[position] is Rectangle)
                            {
                                var rectangleToCircleDetector = new RectangleToCircleOverlapDetector();
                                if (rectangleToCircleDetector.IsOverlap((Rectangle)shapesArray[position], (Circle)shape))
                                {
                                    isForegound = false;
                                }
                            }
                            else
                            {
                                isForegound = false;
                            }
                            break;
                            //TODO add precise
                        }
                    }





                if (isForegound)
                {
                    foregroundShapes.Add(i, shape);
                }
                if (maxCount == foregroundShapes.Count)
                    break;
            }

            return foregroundShapes.Values;
        }
    }
}
