namespace DISample;

public class MockApiClient : IApiClient
{
    public string GetData() => "モックデータ";
}
