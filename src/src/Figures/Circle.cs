namespace MindBoxAssignment.Figures;

public sealed class Circle : Figure
{
    private Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Radius should be a positive number");

        Radius = radius;
    }
    public double Radius { get; }
    
    public override double Area
    {
        // Formula for cirlce area: Pi * R ^ 2
        get => Math.PI * Math.Pow(Radius, 2);
    }
    
    public static Circle Create(double radius) // static
    {
        return new Circle(radius);
    }
}