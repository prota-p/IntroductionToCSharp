
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

                // メニュー一覧をHTMLコードとして生成する
                MenuTableGenerator generator = new MenuTableGenerator(menus.ToArray());
                string tableHtml = generator.GenerateTable();

                // メニュー表をHTMLページとして生成する
                MenuPageGenerator htmlGenerator = new MenuPageGenerator(tableHtml);
                string html = htmlGenerator.GenerateHtml();

                // 生成されたHTMLをファイルへ出力する
                const string outputHtmlFilePath = "menu.html";
                File.WriteAllText(outputHtmlFilePath, html);
            }
            catch (Exception e)
            {
                // その他の予期せぬエラーが発生した場合のエラーメッセージを表示する
                Console.WriteLine($"予期せぬエラーが発生しました: {e.Message}");
            }
        }
    }
}
