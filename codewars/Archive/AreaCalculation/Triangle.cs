internal class Triangle : IShape
{
    private double triangleBase;
    private double triangleHeight;

    public Triangle(double triangleBase, double triangleHeight)
    {
        this.triangleBase = triangleBase;
        this.triangleHeight = triangleHeight;
    }

    public double Area => (triangleBase * triangleHeight) / 2;
}