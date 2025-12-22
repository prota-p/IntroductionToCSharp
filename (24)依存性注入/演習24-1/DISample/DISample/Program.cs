using Microsoft.Extensions.DependencyInjection;
using DISample;

// DIコンテナの設定
var services = new ServiceCollection();

// サービスの登録
// ここでMockApiClientに変更すれば、実装を簡単に差し替えられる
services.AddSingleton<IApiClient>(sp =>
    new ApiClient("https://api.example.com", 30));

services.AddTransient<DataService>();

// サービスプロバイダーの構築
using var provider = services.BuildServiceProvider();

// サービスの取得と実行
var dataService = provider.GetRequiredService<DataService>();
dataService.Execute();