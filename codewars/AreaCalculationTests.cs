using System;
using System.Linq;
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

        Assert.AreEqual(12, sut.GetTotalArea(triangle));
    }

    [Test]
    public void AreaOfASquareIsSquareOfSide()
    {
        const double side = 6;

        var square = new Square(side);

        Assert.AreEqual(36, sut.GetTotalArea(square));
    }

    [Test]
    public void AreaOfARectangleIsWidthMultipliedByHeight()
    {
        const double height = 4;
        const double width = 8;

        var rectangle = new Rectangle(height, width);

        Assert.AreEqual(32, sut.GetTotalArea(rectangle));
    }

    [Test]
    public void AreaOfACircleIsSquareOfRadiusMulitpliedByPi()
    {
        const double radius = 3;

        var circle = new Circle(radius);

        Assert.AreEqual(28.27, sut.GetTotalArea(circle));
    }

    [Test]
    public void TotalAreaIsSumOfAreasOfDifferentShapes()
    {
        Assert.AreEqual(49.14, sut.GetTotalArea(new Rectangle(4, 2), new Rectangle(3, 4), new Circle(1), new Square(1), new Triangle(10, 5)));
    }

    [Test]
    public void TotalAreaIsRoundedTo2Decimals()
    {
        Assert.AreEqual(4.45, sut.GetTotalArea(new Rectangle(1.112, 2), new Rectangle(1.111, 2)));
    }

    [Test]
    public void TotalAreaIs0WhenThereAreNoShapes()
    {
        Assert.AreEqual(0, sut.GetTotalArea());
    }
}

internal class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
    }
}

internal class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetTotalArea()
    {
        return Math.Pow(radius, 2) * Math.PI;
    }
}

internal class Rectangle : Shape
{
    private readonly double width;
    private readonly double height;

    public Rectangle(double height, double width)
    {
        this.height = height;
        this.width = width;
    }

    public override double GetTotalArea()
    {
        return height * width;
    }
}

internal class Triangle : Shape
{
    private double triangleBase;
    private double triangleHeight;

    public Triangle(double triangleBase, double triangleHeight)
    {
        this.triangleBase = triangleBase;
        this.triangleHeight = triangleHeight;
    }

    public override double GetTotalArea()
    {
        return (triangleBase * triangleHeight) / 2;
    }
}

internal abstract class Shape
{
    public abstract double GetTotalArea();
}

internal class Calculator
{
    internal double GetTotalArea(params Shape[] shapes)
    {
        return Math.Round(shapes.Sum(s => s.GetTotalArea()), 2);
    }
}