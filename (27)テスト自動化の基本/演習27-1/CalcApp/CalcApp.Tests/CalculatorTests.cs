namespace CalcApp.Tests;

using CalcApp;

public class CalculatorTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    [InlineData(100, 200, 300)]
    public void Add_WithVariousInputs_ReturnsExpectedSum(
    int a, int b, int expected)
    {
        // Arrange
        var taxRateLoader = new TaxRateLoader();
        var calculator = new Calculator(taxRateLoader);

        // Act
        var result = calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_WithValidInputs_ReturnsQuotient()
    {
        // Arrange
        var taxRateLoader = new TaxRateLoader();
        var calculator = new Calculator(taxRateLoader);

        // Act
        var result = calculator.Divide(10, 2);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_WithZeroDivisor_ThrowsDivideByZeroException()
    {
        // Arrange
        var taxRateLoader = new TaxRateLoader();
        var calculator = new Calculator(taxRateLoader);

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }

    [Theory]
    [InlineData(1000, 1100)]   // 1000円 → 1100円
    [InlineData(500, 550)]     // 500円 → 550円
    [InlineData(0, 0)]         // 0円 → 0円
    public void CalculateWithTax_WithVariousPrices_ReturnsExpected(
    decimal price, decimal expected)
    {
        // Arrange
        var taxRateLoader = new TaxRateLoader();
        var calculator = new Calculator(taxRateLoader);

        // Act
        var result = calculator.CalculateWithTax(price);

        // Assert
        Assert.Equal(expected, result);
    }
}
