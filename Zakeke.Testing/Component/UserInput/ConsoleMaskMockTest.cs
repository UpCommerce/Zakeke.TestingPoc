using Xunit;
using Calculator.Math;
using Calculator.UserInput;
using System;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Zakeke.Testing.Integration.UserInput.Fixture;
using NSubstitute;

namespace Zakeke.Testing.Component.UserInput;

public class ConsoleMaskMockTests
{

    private readonly IConsoleMask _mask;
    public ConsoleMaskMockTests()
    {
        //Esempio di dependency injection
        _mask = Substitute.For<IConsoleMask>();

        _mask.DetermineUserOperation("1").Returns(Operations.AddTwoNumbers);
        _mask.DetermineUserOperation("2").Returns(Operations.SubtractTwoNumbers);
        _mask.DetermineUserOperation("3").Returns(Operations.MultiplyTwoNumbers);
        _mask.DetermineUserOperation("4").Returns(Operations.DivideTwoNumbers);

    }


    [Theory]
    [InlineData("1", typeof(Func<int, int, int>))] // Test addition mapping
    [InlineData("2", typeof(Func<int, int, int>))] // Test subtraction mapping
    [InlineData("3", typeof(Func<int, int, int>))] // Test multiplication mapping
    [InlineData("4", typeof(Func<int, int, int>))] // Test division mapping
    public void DetermineMocUserOperation_MockedOperation_ReturnsDelegate(string operation, Type expectedType)
    {
        // Act
        var result = _mask.DetermineUserOperation(operation);

        // Assert
        Assert.IsType(expectedType, result);
    }




}


