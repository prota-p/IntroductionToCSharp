using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DISample;

public class DataService : BackgroundService
{
    private readonly IApiClient _client;
    private readonly ILogger<DataService> _logger;

    public DataService(IApiClient client, ILogger<DataService> logger)
    {
        _client = client;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("データ取得処理を実行します");

        var data = _client.GetData();
        _logger.LogDebug("APIからのレスポンス: {Response}", data);

        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 取得結果: {data}");

        _logger.LogInformation("データ取得処理が正常に完了しました");

        await Task.CompletedTask;
    }
}
