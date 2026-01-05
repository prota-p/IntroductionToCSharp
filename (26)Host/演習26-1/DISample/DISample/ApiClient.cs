using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DISample;

public class ApiClient : IApiClient
{
    private readonly ApiSettings _settings;
    private readonly ILogger<ApiClient> _logger;

    public ApiClient(IOptions<ApiSettings> options, ILogger<ApiClient> logger)
    {
        _settings = options.Value;
        _logger = logger;
    }

    public string GetData()
    {
        _logger.LogDebug("APIリクエスト開始: {BaseUrl}", _settings.BaseUrl);
        
        // 実際のアプリではHttpClientを使ってAPI呼び出し
        return $"[{_settings.BaseUrl}] からデータ取得（タイムアウト: {_settings.TimeoutSeconds}秒）";
    }
}
