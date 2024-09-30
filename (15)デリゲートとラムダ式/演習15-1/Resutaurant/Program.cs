
using Restaurant.Generators;
using Restaurant.Menus;
using Restaurant.Readers;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // CSVからメニュー一覧を読み込む
                string inputCsvFilePath = "menu.csv";
                var csvReader = new CsvMenuReader(inputCsvFilePath);
                List<Menu> menus = csvReader.ReadMenus();

                // 0. 通常のメニュー表を出力
                GenerateHtmlFile(menus, "menu.html");

                // 1. 価格の安い順にメニューを並べ替えて出力
                var sortedMenus = menus.OrderBy(menu => menu.Price).ToList();
                GenerateHtmlFile(sortedMenus, "sorted_menu.html");

                // 2. ベジタリアン向けの主菜メニューを抽出して出力
                var vegetarianMenus = menus.Where(menu => menu is MainMenu mainMenu && mainMenu.IsVegetarian).ToList();
                GenerateHtmlFile(vegetarianMenus, "vegetarian_menu.html");
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
            MenuTableGenerator generator = new MenuTableGenerator(menus.ToArray());
            string tableHtml = generator.GenerateTable();

            // メニュー表をHTMLページとして生成する
            MenuPageGenerator htmlGenerator = new MenuPageGenerator(tableHtml);
            string html = htmlGenerator.GenerateHtml();

            // 生成されたHTMLをファイルへ出力する
            File.WriteAllText(fileName, html);
        }
    }    
}
