namespace DISample;

public class ApiClient : IApiClient
{
    private readonly string _baseUrl;
    private readonly int _timeoutSeconds;

    public ApiClient(string baseUrl, int timeoutSeconds)
    {
        _baseUrl = baseUrl;
        _timeoutSeconds = timeoutSeconds;
    }

    public string GetData()
        => $"[{_baseUrl}] からデータ取得（タイムアウト: {_timeoutSeconds}秒）";
}
