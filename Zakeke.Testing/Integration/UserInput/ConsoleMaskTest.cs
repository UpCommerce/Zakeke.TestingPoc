﻿using Xunit;
using Calculator.Math;
using Calculator.UserInput;
using System;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Zakeke.Testing.Integration.UserInput.Fixture;

namespace Zakeke.Testing.Integration.UserInput;

public class ConsoleMaskTests : IClassFixture<ConsoleMaskTestBed>
{

    private readonly ConsoleMask _mask;
    public ConsoleMaskTests(ConsoleMaskTestBed testBed, ITestOutputHelper helper)
    {
        //Esempio di dependency injection
        var provider = testBed.GetServiceProvider(helper);
        _mask = provider.GetRequiredService<ConsoleMask>();


        if (_mask.isInjected())
        {
            Console.WriteLine("success");
        }
    }


    [Theory]
    [InlineData("1", typeof(Func<int, int, int>))] // Test addition mapping
    [InlineData("2", typeof(Func<int, int, int>))] // Test subtraction mapping
    [InlineData("3", typeof(Func<int, int, int>))] // Test multiplication mapping
    [InlineData("4", typeof(Func<int, int, int>))] // Test division mapping
    public void DetermineUserOperation_ValidOperation_ReturnsDelegate(string operation, Type expectedType)
    {
        // Act
        var result = _mask.DetermineUserOperation(operation);

        // Assert
        Assert.IsType(expectedType, result);
    }

    [Fact]
    public void DetermineUserOperation_InvalidOperation_ThrowsNotImplementedException()
    {
        // Arrange
        string operation = "invalid_operation";

        // Act & Assert
        var exception = Assert.Throws<NotImplementedException>(() => _mask.DetermineUserOperation(operation));
        Assert.Equal("Invalid Operation requested", exception.Message);
    }

    [Theory]
    [InlineData("10", "20", 10, 20)] // Test valid input parsing
    [InlineData("-10", "-20", -10, -20)] // Test valid negative numbers
    [InlineData("0", "0", 0, 0)] // Test parsing zeros
    public void DetermineUserInput_ValidInput_ParsesValuesCorrectly(string x, string y, int expectedValx, int expectedValy)
    {
        // Act
        _mask.DetermineUserInput(x, y, out int valx, out int valy);

        // Assert
        Assert.Equal(expectedValx, valx);
        Assert.Equal(expectedValy, valy);
    }

    [Theory]
    [InlineData("invalid_number", "20")] // Test invalid first input
    [InlineData("10", "invalid_number")] // Test invalid second input
    public void DetermineUserInput_InvalidInput_ThrowsInvalidDataException(string x, string y)
    {
        // Act & Assert
        Assert.Throws<InvalidDataException>(() => _mask.DetermineUserInput(x, y, out int valx, out int valy));
    }
}