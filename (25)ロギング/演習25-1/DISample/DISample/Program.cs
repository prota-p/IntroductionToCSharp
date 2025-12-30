using Microsoft.Extensions.DependencyInjection;
using Serilog;
using DISample;

// Serilogの設定（この設定がDIで注入される全てのILogger<T>に引き継がれる）
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()  // Informationレベル以上を出力
    .Enrich.WithMachineName()  // ログにマシン名を追加
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/app-.log",
        rollingInterval: RollingInterval.Day,  // 日付ごとにファイルを分割
        outputTemplate:
        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] [Machine: {MachineName}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// DIコンテナの設定
var services = new ServiceCollection();

// ILogger<T>でSerilogが使えるようにDIに登録（Log.Loggerの設定を使用）
services.AddLogging(builder =>
{
    //Dispose:trueでサービスプロバイダDispose時にSerilogもDispose
    builder.AddSerilog(dispose: true);  
});

// サービスの登録
// ここでMockApiClientに変更すれば、実装を簡単に差し替えられる
services.AddSingleton<IApiClient>(sp =>
    new ApiClient("https://api.example.com", 30));

services.AddTransient<DataService>();

// サービスプロバイダーの構築（usingで自動Dispose → Serilogがバッファをフラッシュ）
using var provider = services.BuildServiceProvider();

// サービスの取得と実行
var dataService = provider.GetRequiredService<DataService>();
dataService.Execute();