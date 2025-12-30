using Microsoft.Extensions.Logging;

namespace DISample;

public class DataService
{
    private readonly IApiClient _client;
    private readonly ILogger<DataService> _logger;

    // DIでIApiClientとILoggerを受け取る
    public DataService(IApiClient client, ILogger<DataService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation("データ取得処理を開始します");

        try
        {
            var data = _client.GetData();
            _logger.LogDebug("APIからのレスポンス: {Response}", data);

            // 実際のアプリでは、取得したデータを加工・保存・表示などする
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 取得結果: {data}");

            _logger.LogInformation("データ取得処理が正常に完了しました");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "データ取得処理でエラーが発生しました");
            throw;
        }
    }
}
