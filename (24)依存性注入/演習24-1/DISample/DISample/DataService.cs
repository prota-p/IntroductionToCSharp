namespace DISample;

public class DataService
{
    private readonly IApiClient _client;

    public DataService(IApiClient client)
    {
        _client = client;
    }

    public void Execute()
    {
        var data = _client.GetData();
        // 実際のアプリでは、取得したデータを加工・保存・表示などする
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 取得結果: {data}");
    }
}
