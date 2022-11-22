﻿using ForegroundRecognition.Extensions;
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
        return FindForegroundShapesInternal(shapes, 0, minimalArea);
    }

    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, int maxCount)
    {
        return FindForegroundShapesInternal(shapes, maxCount, 0);
    }

    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        return FindForegroundShapesInternal(shapes, maxCount, minimalArea);
    }

    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes)
    {
        return FindForegroundShapesAsync(shapes, 0, 0);
    }

    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes, double minimalArea)
    {
        return FindForegroundShapesAsync(shapes, 0, minimalArea);
    }

    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes, int maxCount)
    {
        return FindForegroundShapesAsync(shapes, maxCount, 0);
    }

    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        return FindForegroundShapes(shapes, maxCount, minimalArea).ToAsyncEnumerable();
    }

    private static IEnumerable<Shape> FindForegroundShapesInternal(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        var boundingBoxes = shapes.ToDictionary(x => x, x => x.GetBoundingBox());

        yield return shapes[0];
        var foundCount = 1;
        for (var i = 1; i < shapes.Count; i++)
        {
            if (foundCount == maxCount)
                yield break;

            var shape = shapes[i];

            if (minimalArea != 0 && minimalArea >= shape.GetArea())
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
            if (RectangleToRectangleOverlapDetector.IsOverlap(shapeBoundingBox, upShapeBoundingBox))
                if (ShapeToShapeOverlapDetector.IsOverlap(shape, upShape))
                    return false;
        }
        return true;
    }
}
