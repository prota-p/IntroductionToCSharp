using CalcApp;

namespace CalcApp.Tests;

public class CalculatorTests
{
    private readonly ITaxRateLoader _taxRateLoader = new TaxRateLoader();

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    [InlineData(100, 200, 300)]
    public void Add_WithVariousInputs_ReturnsExpectedSum(int a, int b, int expected)
    {
        var calculator = new Calculator(_taxRateLoader);
        var result = calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_WithValidInputs_ReturnsQuotient()
    {
        var calculator = new Calculator(_taxRateLoader);
        var result = calculator.Divide(10, 2);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_WithZeroDivisor_ThrowsDivideByZeroException()
    {
        var calculator = new Calculator(_taxRateLoader);
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }

    [Theory]
    [InlineData(1000, 1100)]   // 1000円 → 1100円
    [InlineData(500, 550)]     // 500円 → 550円
    [InlineData(0, 0)]         // 0円 → 0円
    public void CalculateWithTax_WithVariousPrices_ReturnsExpected(
        decimal price, decimal expected)
    {
        var calculator = new Calculator(_taxRateLoader);
        var result = calculator.CalculateWithTax(price);
        Assert.Equal(expected, result);
    }
}