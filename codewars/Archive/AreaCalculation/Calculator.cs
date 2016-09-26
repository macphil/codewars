using System;
using System.Linq;

public class Calculator
{
    public double GetTotalArea(params IShape[] shapes)
    {
        return Math.Round(shapes.Sum(s => s.Area), 2);
    }
}