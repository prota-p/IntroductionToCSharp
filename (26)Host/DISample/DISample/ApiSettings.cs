namespace DISample;

public class ApiSettings
{
    // デフォルト値は設定漏れ時のフォールバック
    public string BaseUrl { get; set; } = "";
    public int TimeoutSeconds { get; set; } = 30;
}
