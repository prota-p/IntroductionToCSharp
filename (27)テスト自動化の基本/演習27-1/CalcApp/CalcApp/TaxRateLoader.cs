namespace CalcApp;

public class TaxRateLoader : ITaxRateLoader
{
    private readonly string _filePath;

    public TaxRateLoader(string filePath = "taxrate.txt")
    {
        _filePath = filePath;
    }

    public int GetTaxRatePercent()
    {
        var text = File.ReadAllText(_filePath);
        return int.Parse(text.Trim());
    }
}