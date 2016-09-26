using System;

internal class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Area => Math.Pow(radius, 2) * Math.PI;
}