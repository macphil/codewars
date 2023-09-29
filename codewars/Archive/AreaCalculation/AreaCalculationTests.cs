using NUnit.Framework;

[TestFixture]
public class AreaCalculationTests
{
    private Calculator sut = new Calculator();

    [Test]
    public void AreaOfATriangleIsBaseMultipliedByHeight()
    {
        const double triangleBase = 6;
        const double triangleHeight = 4;

        var triangle = new Triangle(triangleBase, triangleHeight);

        Assert.That(sut.GetTotalArea(triangle), Is.EqualTo(12));
    }

    [Test]
    public void AreaOfASquareIsSquareOfSide()
    {
        const double side = 6;

        var square = new Square(side);

        Assert.That(sut.GetTotalArea(square), Is.EqualTo(36));
    }

    [Test]
    public void AreaOfARectangleIsWidthMultipliedByHeight()
    {
        const double height = 4;
        const double width = 8;

        var rectangle = new Rectangle(height, width);

        Assert.That(sut.GetTotalArea(rectangle), Is.EqualTo(32));
    }

    [Test]
    public void AreaOfACircleIsSquareOfRadiusMulitpliedByPi()
    {
        const double radius = 3;

        var circle = new Circle(radius);

        Assert.That(sut.GetTotalArea(circle), Is.EqualTo(28.27));
    }

    [Test]
    public void TotalAreaIsSumOfAreasOfDifferentShapes()
    {
        Assert.That(sut.GetTotalArea(new Rectangle(4, 2), new Rectangle(3, 4), new Circle(1), new Square(1), new Triangle(10, 5)), Is.EqualTo(49.14));
    }

    [Test]
    public void TotalAreaIsRoundedTo2Decimals()
    {
        Assert.That(sut.GetTotalArea(new Rectangle(1.112, 2), new Rectangle(1.111, 2)), Is.EqualTo(4.45));
    }

    [Test]
    public void TotalAreaIs0WhenThereAreNoShapes()
    {
        Assert.That(sut.GetTotalArea(), Is.EqualTo(0));
    }
}