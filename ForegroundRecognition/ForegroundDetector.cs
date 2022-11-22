using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition;

public static class ForegroundDetector
{
    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes)
    {
        return FindForegroundShapesInternal(shapes, 0, 0);
    }

    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, double minimalArea)
    {
        return FindForegroundShapesInternal(shapes, 0, 0);
    }

    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, int maxCount)
    {
        return FindForegroundShapesInternal(shapes, maxCount, 0);
    }

    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        return FindForegroundShapesInternal(shapes, maxCount, minimalArea);
    }

    public static async Task<IEnumerable<Shape>> FindForegroundShapesAsync(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        return await Task.Run(() => { return FindForegroundShapes(shapes, maxCount, minimalArea); });
    }

    private static IEnumerable<Shape> FindForegroundShapesInternal(IList<Shape> shapes, int maxCount = 0, double minimalArea = 0)
    {
        var boundingBoxes = shapes.ToDictionary(x => x, x => x.GetBoundingBox());

        yield return shapes[0];
        var foundCount = 1;
        for (var i = 1; i < shapes.Count; i++)
        {
            if (foundCount == maxCount)
                yield break;

            var shape = shapes[i];

            if (minimalArea != 0 && minimalArea >= shape.Area)
                continue;

            if (IsForeground(shape, boundingBoxes, shapes.Take(i)))
                yield return shape;
        }
    }

    private static bool IsForeground(Shape shape, Dictionary<Shape, Rectangle> boundingBoxes, IEnumerable<Shape> upShapes)
    {
        var shapeBoundingBox = boundingBoxes[shape];
        foreach (var upShape in upShapes)
        {
            var upShapeBoundingBox = boundingBoxes[upShape];
            if (ShapeToShapeOverlapDetector.IsOverlap(shapeBoundingBox, upShapeBoundingBox))
                if (ShapeToShapeOverlapDetector.IsOverlap(shape, upShape))
                    return false;
        }
        return true;
    }
}
