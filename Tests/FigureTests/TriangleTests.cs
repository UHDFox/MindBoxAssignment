using System;
using FluentAssertions;
using MindBoxAssignment.Figures;
using Xunit;

namespace Tests.FigureTests;

public sealed class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5, 6)] // Прямоугольный треугольник с площадью 6
    [InlineData(6, 8, 10, 24)] // Прямоугольный треугольник с площадью 24
    [InlineData(7, 8, 9, 26.832)] // Общий треугольник с площадью 26.832
    public void TriangleArea_WithDifferentSides_ShouldReturnCorrectArea(double a, double b, double c,
        double expectedArea)
    {
        // Arrange
        var triangle = Triangle.Create(a, b, c);

        // Act
        var area = triangle.Area;

        // Assert
        area.Should().BeApproximately(expectedArea, 0.001);
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 8, 10, true)]
    [InlineData(9, 40, 41, true)]
    [InlineData(11, 60, 61, true)]
    [InlineData(3, 4, 6, false)]
    [InlineData(3, 3, 3, false)]
    public void TriangleIsRightTriangle_ShouldReturnExpectedResult(double a, double b, double c, bool result)
    {
        // Arrange
        var triangle = Triangle.Create(a, b, c);

        // Act
        var isRight = triangle.IsRightTriangle();

        // Assert
        isRight.Should().Be(result);
    }

    [Fact]
    public void TriangleConstructor_ShouldThrowArgumentExceptionForInvalidSides()
    {
        // Act
        Action act = () => Triangle.Create(1, 2, 3); // Such sides cannot form a triangle

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Triangle with such sides cannot exist");
    }
}