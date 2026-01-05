using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using DISample;

// 0. Serilogの設定
// 出力先、フォーマット、ログレベルなどを指定
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    //↓ Hosting.LifetimeのログレベルをWarningに上げて冗長な情報を抑制
    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", Serilog.Events.LogEventLevel.Warning)
    .Enrich.WithMachineName()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/app-.log",
        rollingInterval: RollingInterval.Day,
        outputTemplate:
        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] [Machine: {MachineName}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// 1. HostApplicationBuilderを作成
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// 2. Serilogを使用するように設定（既存のLog.Logger設定を使用）
builder.Logging.ClearProviders(); // 既存のロギングプロバイダーをクリア
builder.Logging.AddSerilog(dispose: true);

// 3. 設定をバインド（appsettings.jsonから自動読み込み）
// これでIOptions<ApiSettings>がDIコンテナに登録される
builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

// 4. サービスを登録
// ここでMockApiClientに変更すれば、実装を簡単に差し替えられる
builder.Services.AddTransient<IApiClient, ApiClient>();

// 5. DataServiceをHostedServiceとして登録
builder.Services.AddHostedService<DataService>();

// 6. ホストをビルドして実行
IHost host = builder.Build();

await host.RunAsync();