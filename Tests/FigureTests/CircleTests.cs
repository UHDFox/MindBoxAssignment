using System;
using FluentAssertions;
using MindBoxAssignment.Figures;
using Xunit;

namespace Tests.FigureTests;

public sealed class CircleTests
{
    [Theory]
    [InlineData(10, 100)]
    [InlineData(5, 25)]
    [InlineData(2, 4)]
    [InlineData(1, 1)]
    public void CircleArea_PositiveRadius_ShouldReturnCorrectArea(double radius, double expectedAreaMultiplier)
    {
        // Arrange
        var circle = Circle.Create(radius);

        // Act
        var area = circle.Area;

        // Assert
        area.Should().BeApproximately(expectedAreaMultiplier * Math.PI, 0.001);
    }

    [Fact]
    public void CircleConstructor_NegativeRadius_ShouldThrowArgumentException()
    {
        //Act
        Action act = () => Circle.Create(-1);

        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Radius should be a positive number");
    }

    [Fact]
    public void CircleConstructor_RadiusParamIsPositive_FieldShouldBeSetCorrectly()
    {
        // Arrange
        var radius = 7;
        var circle = Circle.Create(radius);

        // Act
        var actualRadius = circle.Radius;

        // Assert
        actualRadius.Should().Be(radius); // Check if radius has been set correctly
    }
}