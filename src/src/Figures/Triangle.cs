namespace MindBoxAssignment.Figures;

public sealed class Triangle : Figure
{
    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Triangle sides must be positive");

        A = a;
        B = b;
        C = c;

        if (!IsValidTriangle())
            throw new ArgumentException("Triangle with such sides cannot exist");
    }

    public double A { get; }
    public double B { get; }
    public double C { get; }

    public override double Area
    {
        // use Heron's formula for area of triangle
        get
        {
            // half-perimeter used in formula
            var hPerim = (A + B + C) / 2;
            //the formula itself
            return Math.Sqrt(hPerim * (hPerim - A) * (hPerim - B) * (hPerim - C));
        }
    }

    public bool IsRightTriangle()
    {
        // Pro tip: we can avoid multiple comparison by finding the hypotenuse using sorted array
        var triangleSides = new[] { A, B, C };
        Array.Sort(triangleSides);

        // Pythagorean theorem
        // We compare floating point numbers with some precision. 0.01 for example
        return Math.Abs(triangleSides[2] * triangleSides[2] -
                        (triangleSides[1] * triangleSides[1] + triangleSides[0] * triangleSides[0])) < 0.01;
    }

    public bool IsValidTriangle()
    {
        return A + B > C && A + C > B && B + C > A;
    }
}