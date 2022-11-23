using ForegroundRecognition.OverlapDetectors;
using ForegroundRecognition.RandomGenerator;
using ForegroundRecognition.Shapes;
using System.Reflection;

namespace ForegroundRecognition.Tests.OverlapDetectors;

internal class ShapeToShapeOverlapDetectorTest
{
    private readonly Random _random = new Random();

    [Test]
    public void AllCombinationsOfShapesCheckedShouldNotThrowException()
    {
        var assemblyName = "ForegroundRecognition";
        var nameSpace = "ForegroundRecognition.Shapes";

        var asm = Assembly.Load(assemblyName);
        var classes = asm.GetTypes().Where(p =>
             p.Namespace == nameSpace &&
             p.IsAbstract == false &&
             p.IsPublic == true
        ).ToList();

        var cartesianProduct = from class1 in classes
                               from class2 in classes
                               select new { class1, class2 };

        foreach (var classPair in cartesianProduct)
        {
            Assert.DoesNotThrow(() =>
            {
                var firstShape = GetRandomShape(classPair.class1);
                var secondShape = GetRandomShape(classPair.class2);
                ShapeToShapeOverlapDetector.IsOverlap(firstShape, secondShape);
            });
        }
    }

    private Shape GetRandomShape(Type concreteType)
    {
        return concreteType.Name switch
        {
            nameof(Triangle) => ShapesRandomGenerator.GetRandomTriangle(),
            nameof(Rectangle) => ShapesRandomGenerator.GetRandomRectangle(),
            nameof(Circle) => ShapesRandomGenerator.GetRandomCircle(),
            nameof(Line) => ShapesRandomGenerator.GetRandomLine(),
            _ => throw new ArgumentException("Not supported type"),
        };
    }


}
