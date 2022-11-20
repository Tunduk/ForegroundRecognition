using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition
{
    public class ForegroundDetector
    {
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
                var isForeground = true;
                foreach (var foregoundShape in foregroundShapes.Values)
                {
                    if (ShapeToShapeOverlapDetector.IsOverlap(shapeBoundingBox, foregoundShape.GetBoundingBox()))
                        if (ShapeToShapeOverlapDetector.IsOverlap(shape, foregoundShape))
                        {
                            isForeground = false;
                            break;
                        }
                }

                //all top and not foreground
                if (isForeground)
                    foreach (var position in allPositions.Except(foregroundShapes.Keys).Except(Enumerable.Range(i, shapesArray.Length)))
                    {
                        if (ShapeToShapeOverlapDetector.IsOverlap(shapeBoundingBox, shapesArray[position].GetBoundingBox()))
                            if (ShapeToShapeOverlapDetector.IsOverlap(shape, shapesArray[position]))
                            {
                                isForeground = false;
                                break;
                            }
                    }

                if (isForeground)
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
