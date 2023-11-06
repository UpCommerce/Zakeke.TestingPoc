using Calculator.Math;

// Replace with the actual namespace of your Calculator class
namespace Zakeke.Testing.Math;
public class CalculatorTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, -2, -3)]
    public void AddTwoNumbers_ValidInputs_ReturnsCorrectResult(int val1, int val2, int expectedResult)
    {

        // Arrange & Act
        var result = Operations.AddTwoNumbers(val1, val2);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, -2, 1)]
    public void SubtractTwoNumbers_ValidInputs_ReturnsCorrectResult(int val1, int val2, int expectedResult)
    {
        // Arrange & Act
        var result = Operations.SubtractTwoNumbers(val1, val2);

        // Assert
        Assert.Equal(expectedResult, result);
    }


    [Fact]
    public void DivideTwoNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int val1 = 10;
        int val2 = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => Operations.DivideTwoNumbers(val1, val2));
    }
}