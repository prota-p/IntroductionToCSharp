namespace CalcApp.Tests;

using CalcApp;
using NSubstitute;

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

    [Fact]
    public void CalculateWithTax_WithMockedTaxRate10Percent_ReturnsCorrectPrice()
    {
        // Arrange - モックを作成し、税率10%を返すように設定
        var taxRateLoader = Substitute.For<ITaxRateLoader>();
        taxRateLoader.GetTaxRatePercent().Returns(10);

        var calculator = new Calculator(taxRateLoader);

        // Act
        var result = calculator.CalculateWithTax(1000m);

        // Assert
        Assert.Equal(1100m, result);
    }

    [Theory]
    [InlineData(1000, 5, 1050)]    // 税率5%: 1000 → 1050
    [InlineData(1000, 8, 1080)]    // 税率8%: 1000 → 1080
    [InlineData(1000, 10, 1100)]   // 税率10%: 1000 → 1100
    [InlineData(500, 10, 550)]     // 税率10%: 500 → 550
    [InlineData(0, 10, 0)]         // 税率10%: 0 → 0
    public void CalculateWithTax_WithVariousTaxRates_ReturnsExpected(
    decimal price, int taxRate, decimal expected)
    {
        // Arrange
        var taxRateLoader = Substitute.For<ITaxRateLoader>();
        taxRateLoader.GetTaxRatePercent().Returns(taxRate);

        var calculator = new Calculator(taxRateLoader);

        // Act
        var result = calculator.CalculateWithTax(price);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateWithTax_WhenTaxRateLoadingFails_ThrowsException()
    {
        // Arrange - 例外をスローするモックを設定
        var taxRateLoader = Substitute.For<ITaxRateLoader>();
        taxRateLoader.GetTaxRatePercent().Returns(x => throw new IOException("ファイル読み込みエラー"));

        var calculator = new Calculator(taxRateLoader);

        // Act & Assert
        Assert.Throws<IOException>(() => calculator.CalculateWithTax(1000m));
    }
}