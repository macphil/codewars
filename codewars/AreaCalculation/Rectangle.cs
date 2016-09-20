internal class Rectangle : IShape
{
    private readonly double width;
    private readonly double height;

    public Rectangle(double height, double width)
    {
        this.height = height;
        this.width = width;
    }

    public double Area => height * width;
}