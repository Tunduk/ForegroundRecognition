using ForegroundRecognition.Extensions;
using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.Shapes;

namespace ForegroundRecognition;

public static class ForegroundDetector
{
    /// <summary>
    /// Finds all foreground shapes
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <returns>Collection of foreground shapes in order from top to bottom</returns>
    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes)
    {
        return FindForegroundShapesInternal(shapes, 0, 0);
    }

    /// <summary>
    /// Finds all foreground shapes whose area is bigger that the minimal threshold
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <param name="minimalArea">Minimal area threshold</param>
    /// <returns>Collection of foreground shapes in order from top to bottom</returns>
    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, double minimalArea)
    {
        return FindForegroundShapesInternal(shapes, 0, minimalArea);
    }

    /// <summary>
    /// Finds foreground shapes in the amount of no more than maxCount
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <param name="maxCount">Maximum number of recognized shapes</param>
    /// <returns>Collection of foreground shapes in order from top to bottom</returns>
    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, int maxCount)
    {
        return FindForegroundShapesInternal(shapes, maxCount, 0);
    }

    /// <summary>
    /// Finds foreground shapes in the amount of no more than maxCount and bigger that minimal threshold  
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <param name="maxCount">Maximum number of recognized shapes</param>
    /// <param name="minimalArea">Minimal area threshold</param>
    /// <returns>Collection of foreground shapes in order from top to bottom</returns>
    public static IEnumerable<Shape> FindForegroundShapes(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        return FindForegroundShapesInternal(shapes, maxCount, minimalArea);
    }

    /// <summary>
    /// Finds foreground shapes in the amount of no more than maxCount and bigger that minimal threshold  
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <returns>IAsyncEnumerable of foreground shapes in order from top to bottom</returns>
    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes)
    {
        return FindForegroundShapesAsync(shapes, 0, 0);
    }

    /// <summary>
    /// Finds foreground shapes in the amount of no more than maxCount and bigger that minimal threshold  
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <param name="minimalArea">Minimal area threshold</param>
    /// <returns>IAsyncEnumerable of foreground shapes in order from top to bottom</returns>
    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes, double minimalArea)
    {
        return FindForegroundShapesAsync(shapes, 0, minimalArea);
    }

    /// <summary>
    /// Finds foreground shapes in the amount of no more than maxCount and bigger that minimal threshold  
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <param name="maxCount">Maximum number of recognized shapes</param>
    /// <returns>IAsyncEnumerable of foreground shapes in order from top to bottom</returns>
    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes, int maxCount)
    {
        return FindForegroundShapesAsync(shapes, maxCount, 0);
    }

    /// <summary>
    /// Finds foreground shapes in the amount of no more than maxCount and bigger that minimal threshold  
    /// </summary>
    /// <param name="shapes">Collection of shapes in order from botton to top</param>
    /// <param name="maxCount">Maximum number of recognized shapes</param>
    /// <param name="minimalArea">Minimal area threshold</param>
    /// <returns>IAsyncEnumerable of foreground shapes in order from top to bottom</returns>
    public static IAsyncEnumerable<Shape> FindForegroundShapesAsync(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        return FindForegroundShapes(shapes, maxCount, minimalArea).ToAsyncEnumerable();
    }

    private static IEnumerable<Shape> FindForegroundShapesInternal(IList<Shape> shapes, int maxCount, double minimalArea)
    {
        var reversedShapes = shapes.Reverse().ToArray();
        var boundingBoxes = reversedShapes.ToDictionary(x => x, x => x.GetBoundingBox());

        var foundCount = 0;
        for (var i = 0; i < reversedShapes.Length; i++)
        {
            if (maxCount != 0 && foundCount == maxCount)
                yield break;

            var shape = reversedShapes[i];

            if (minimalArea != 0 && minimalArea >= shape.GetArea())
                continue;

            if (IsForeground(shape, boundingBoxes, reversedShapes.Take(i)))
            {
                foundCount++;
                yield return shape;
            }

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
