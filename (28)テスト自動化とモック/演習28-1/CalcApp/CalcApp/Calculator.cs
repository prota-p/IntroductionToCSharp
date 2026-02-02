namespace CalcApp;

public class Calculator
{
    private readonly ITaxRateLoader _taxRateLoader;

    public Calculator(ITaxRateLoader taxRateLoader)
    {
        _taxRateLoader = taxRateLoader;
    }

    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException();
        return a / b;
    }

    public decimal CalculateWithTax(decimal price)
    {
        var taxRate = _taxRateLoader.GetTaxRatePercent();
        return price * (100 + taxRate) / 100;
    }
}