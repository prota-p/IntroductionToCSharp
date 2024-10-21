using Restaurant.Menus;

namespace Restaurant
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Menu> menus = GenerateMenuList();
            using (var cancellationTokenSource = new CancellationTokenSource())
            {

                Console.WriteLine("メニュー画像生成を開始します。'e'キーを押すと終了します。");

                // 非同期で画像生成とユーザー入力の監視を開始
                Task generationTask = GenerateImagesAsync(menus, cancellationTokenSource.Token);
                Task inputTask = MonitorUserInputAsync(cancellationTokenSource);

                // 画像生成の完了を待機
                await generationTask;

                // ユーザー入力の監視をキャンセル
                // (ユーザ入力タスクが完了していない場合にはキャンセルされる)
                cancellationTokenSource.Cancel();
                await inputTask;

                Console.WriteLine("アプリケーションを終了します。");
            }
        }

        static List<Menu> GenerateMenuList()
        {
            return new List<Menu>
            {
                new MainMenu("黒毛和牛ステーキ", "ジューシーで柔らかなステーキです。", 2500, false),
                new MainMenu("ベジタブルカレー", "野菜をたっぷりと使った、スパイシーなカレーです。", 1500, true),
                new DrinkMenu("ホットコーヒー", "丁寧に焙煎されたコーヒー豆を使用しています。", 300, false)
            };
        }

        static async Task GenerateImagesAsync(List<Menu> menus, CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < menus.Count; i++)
                {
                    var menu = menus[i];
                    cancellationToken.ThrowIfCancellationRequested();

                    Console.WriteLine($"{i}: AI画像生成を開始: {menu.Name}");
                    // ダミーでウェイト、実際の画像生成APIを呼び出す
                    await Task.Delay(2000, cancellationToken);
                    Console.WriteLine($"{i}: AI画像生成を完了: {menu.Name}");

                    // ダミーでウェイト、ここで実際にファイルを保存する
                    Console.WriteLine($"{i}: 画像保存を開始: {menu.Name}.jpg");
                    await Task.Delay(1000, cancellationToken);
                    Console.WriteLine($"{i}: 画像保存を完了: {menu.Name}.jpg");
                }

                Console.WriteLine("すべてのメニュー項目の画像生成が完了しました。");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("画像生成処理がキャンセルされました。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
        }

        static async Task MonitorUserInputAsync(CancellationTokenSource cancellationTokenSource)
        {
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (char.ToLower(key.KeyChar) == 'e')
                    {
                        cancellationTokenSource.Cancel();
                        Console.WriteLine("キャンセル要求が送信されました。処理を停止します...");
                        break;
                    }
                }
                await Task.Delay(100);
            }
            Console.WriteLine("ユーザー入力の監視を終了します。");
        }
    }
}