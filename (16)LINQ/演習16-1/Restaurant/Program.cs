using Restaurant.Generators;
using Restaurant.Menus;
using Restaurant.Readers;
using System.Linq;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // メニューを読み込む
                var menus = LoadMenus();

                // 通常のメニュー表を出力
                GenerateHtmlFile(menus, "menu.html");

                // メニューを分析
                AnalyzeMenus(menus);
            }
            catch (MenuLoadException e)
            {
                // メニューの読み込みに失敗した場合のエラーメッセージを表示する
                Console.WriteLine($"メニューの読み込みに失敗しました: {e.Message}");
            }
            catch (Exception e)
            {
                // その他の予期せぬエラーが発生した場合のエラーメッセージを表示する
                Console.WriteLine($"予期せぬエラーが発生しました: {e.Message}");
            }
        }

        static void GenerateHtmlFile(List<Menu> menus, string fileName)
        {
            // メニュー一覧をHTMLコードとして生成する
            var generator = new MenuTableGenerator(menus.ToArray());
            var tableHtml = generator.GenerateTable();

            // メニュー表をHTMLページとして生成する
            var htmlGenerator = new MenuPageGenerator(tableHtml);
            var html = htmlGenerator.GenerateHtml();

            // 生成されたHTMLをファイルへ出力する
            File.WriteAllText(fileName, html);
        }

        static List<Menu> LoadMenus()
        {
            // CSVからメニュー一覧を読み込む
            string inputCsvFilePath = "menu.csv";
            var csvReader = new CsvMenuReader(inputCsvFilePath);
            return csvReader.ReadMenus();
        }

        static void AnalyzeMenus(List<Menu> menus)
        {
            // (1)ベジタリアンメニューの割合を計算
            CalculateVegetarianPercentage(menus);

            // (2)メニューごとの売上を計算
            JoinMenuWithSalesData(menus);

            // (3)カテゴリ別の平均価格を計算
            CalculateAveragePriceByCategory(menus);
        }

        static void CalculateVegetarianPercentage(List<Menu> menus)
        {
            var mainMenus = from menu in menus
                            where menu is MainMenu
                            select menu as MainMenu;

            var vegetarianCount = (from menu in mainMenus
                                   where menu.IsVegetarian
                                   select menu).Count();

            var totalCount = mainMenus.Count();
            var vegetarianPercentage = (double)vegetarianCount / totalCount * 100;

            Console.WriteLine($"\nベジタリアンメニューの割合: {vegetarianPercentage:F2}%");
        }

        static void JoinMenuWithSalesData(List<Menu> menus)
        {
            //メニューごとの販売数量（本来はCSVファイルから読み込むが、ここではサンプルデータを直接定義）
            var salesData = new List<(string MenuName, int Quantity)>
            {
                ("黒毛和牛ステーキ", 50),
                ("ベジタブルカレー", 30),
                ("グリルチキン", 40),
                ("ベジタリアンパスタ", 25),
                ("ホットコーヒー", 100),
                ("メロンソーダ", 80)
            };

            var menuSales =
                from menu in menus
                join sale in salesData
                on menu.Name equals sale.MenuName
                select new
                {
                    MenuName = menu.Name,
                    Price = menu.Price,
                    QuantitySold = sale.Quantity
                };

            Console.WriteLine("\nメニューと販売数量の結合結果:");
            foreach (var item in menuSales)
            {
                Console.WriteLine($"{item.MenuName}: 価格 {item.Price:#,0}円, 販売数 {item.QuantitySold}, 売上 {item.Price * item.QuantitySold:#,0}円");
            }
        }

        static void CalculateAveragePriceByCategory(List<Menu> menus)
        {
            var averagePriceByCategory =
                from menu in menus
                group menu by menu.GetType().Name into categoryGroup
                select new
                {
                    Category = categoryGroup.Key,
                    AveragePrice = categoryGroup.Average(m => m.Price)
                };

            Console.WriteLine("\nカテゴリ別の平均価格:");
            foreach (var item in averagePriceByCategory)
            {
                Console.WriteLine($"{item.Category}: {item.AveragePrice:#,0}円");
            }
        }
    }
}